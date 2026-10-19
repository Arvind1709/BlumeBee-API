using BlumeBee.Data;
using BlumeBee.IRepository;
using BlumeBee.Model;
using BlumeBee.ModelDTO;
using Npgsql;
using System.Data;

namespace BlumeBee.Repositories
{
    public class ParentRepository : IParentRepository
    {
        private readonly PostgresDbHelper _db;

        public ParentRepository(PostgresDbHelper db)
        {
            _db = db;
        }

        // 🔹 GET ALL
        public List<ParentModel> GetAll()
        {
            var dt = _db.ExecuteQuery("SELECT * FROM blumebee.parent ORDER BY id DESC");

            var list = new List<ParentModel>();

            foreach (DataRow row in dt.Rows)
            {
                list.Add(Map(row));
            }

            return list;
        }

        // 🔹 GET BY ID
        public ParentModel? GetById(long id)
        {
            var dt = _db.ExecuteQuery(
                "SELECT * FROM blumebee.parent WHERE id = @id",
                new[] { new NpgsqlParameter("@id", id) });

            if (dt.Rows.Count == 0)
                return null;

            return Map(dt.Rows[0]);
        }

        // 🔹 INSERT
        public long Insert(ParentModelDTO model)
        {
            var sql = @"
                INSERT INTO blumebee.parent
                (
                    full_name,
                    relationship_master_id,
                    phone_primary,
                    phone_whatsapp,
                    email,
                    occupation,
                    address_line1,
                    address_line2,
                    city,
                    state,
                    pincode,
                    aadhaar_ref,
                    is_active
                )
                VALUES
                (
                    @full_name,
                    @relationship_master_id,
                    @phone_primary,
                    @phone_whatsapp,
                    @email,
                    @occupation,
                    @address_line1,
                    @address_line2,
                    @city,
                    @state,
                    @pincode,
                    @aadhaar_ref,
                    @is_active
                )
                RETURNING id;
            ";

            var result = _db.ExecuteScalar(sql, new[]
            {
                new NpgsqlParameter("@full_name", model.FullName),
                new NpgsqlParameter("@relationship_master_id", (object?)model.RelationshipMasterId ?? DBNull.Value),
                new NpgsqlParameter("@phone_primary", (object?)model.PhonePrimary ?? DBNull.Value),
                new NpgsqlParameter("@phone_whatsapp", (object?)model.PhoneWhatsapp ?? DBNull.Value),
                new NpgsqlParameter("@email", (object?)model.Email ?? DBNull.Value),
                new NpgsqlParameter("@occupation", (object?)model.Occupation ?? DBNull.Value),
                new NpgsqlParameter("@address_line1", (object?)model.AddressLine1 ?? DBNull.Value),
                new NpgsqlParameter("@address_line2", (object?)model.AddressLine2 ?? DBNull.Value),
                new NpgsqlParameter("@city", (object?)model.City ?? DBNull.Value),
                new NpgsqlParameter("@state", (object?)model.State ?? DBNull.Value),
                new NpgsqlParameter("@pincode", (object?)model.Pincode ?? DBNull.Value),
                new NpgsqlParameter("@aadhaar_ref", (object?)model.AadhaarRef ?? DBNull.Value),
                new NpgsqlParameter("@is_active", model.IsActive)
            });

            return Convert.ToInt64(result);
        }

        // 🔹 UPDATE
        public bool Update(long id, ParentModelDTO model)
        {
            var sql = @"
                UPDATE blumebee.parent
                SET
                    full_name = @full_name,
                    relationship_master_id = @relationship_master_id,
                    phone_primary = @phone_primary,
                    phone_whatsapp = @phone_whatsapp,
                    email = @email,
                    occupation = @occupation,
                    address_line1 = @address_line1,
                    address_line2 = @address_line2,
                    city = @city,
                    state = @state,
                    pincode = @pincode,
                    aadhaar_ref = @aadhaar_ref,
                    is_active = @is_active,
                    updated_at = NOW()
                WHERE id = @id;
            ";

            var affected = _db.ExecuteNonQuery(sql, new[]
            {
                new NpgsqlParameter("@full_name", model.FullName),
                new NpgsqlParameter("@relationship_master_id", (object?)model.RelationshipMasterId ?? DBNull.Value),
                new NpgsqlParameter("@phone_primary", (object?)model.PhonePrimary ?? DBNull.Value),
                new NpgsqlParameter("@phone_whatsapp", (object?)model.PhoneWhatsapp ?? DBNull.Value),
                new NpgsqlParameter("@email", (object?)model.Email ?? DBNull.Value),
                new NpgsqlParameter("@occupation", (object?)model.Occupation ?? DBNull.Value),
                new NpgsqlParameter("@address_line1", (object?)model.AddressLine1 ?? DBNull.Value),
                new NpgsqlParameter("@address_line2", (object?)model.AddressLine2 ?? DBNull.Value),
                new NpgsqlParameter("@city", (object?)model.City ?? DBNull.Value),
                new NpgsqlParameter("@state", (object?)model.State ?? DBNull.Value),
                new NpgsqlParameter("@pincode", (object?)model.Pincode ?? DBNull.Value),
                new NpgsqlParameter("@aadhaar_ref", (object?)model.AadhaarRef ?? DBNull.Value),
                new NpgsqlParameter("@is_active", model.IsActive),
                new NpgsqlParameter("@id", id)
            });

            return affected > 0;
        }

        // 🔹 DELETE
        public bool Delete(long id)
        {
            var affected = _db.ExecuteNonQuery(
                "DELETE FROM blumebee.parent WHERE id = @id",
                new[] { new NpgsqlParameter("@id", id) });

            return affected > 0;
        }

        // 🔹 MAPPER
        private ParentModel Map(DataRow row)
        {
            return new ParentModel
            {
                Id = Convert.ToInt64(row["id"]),
                FullName = row["full_name"].ToString(),
                RelationshipMasterId = row["relationship_master_id"] == DBNull.Value
                    ? null
                    : Convert.ToInt32(row["relationship_master_id"]),

                PhonePrimary = row["phone_primary"] == DBNull.Value ? null : row["phone_primary"].ToString(),
                PhoneWhatsapp = row["phone_whatsapp"] == DBNull.Value ? null : row["phone_whatsapp"].ToString(),
                Email = row["email"] == DBNull.Value ? null : row["email"].ToString(),
                Occupation = row["occupation"] == DBNull.Value ? null : row["occupation"].ToString(),

                AddressLine1 = row["address_line1"] == DBNull.Value ? null : row["address_line1"].ToString(),
                AddressLine2 = row["address_line2"] == DBNull.Value ? null : row["address_line2"].ToString(),
                City = row["city"] == DBNull.Value ? null : row["city"].ToString(),
                State = row["state"] == DBNull.Value ? null : row["state"].ToString(),
                Pincode = row["pincode"] == DBNull.Value ? null : row["pincode"].ToString(),

                AadhaarRef = row["aadhaar_ref"] == DBNull.Value ? null : row["aadhaar_ref"].ToString(),

                IsActive = Convert.ToBoolean(row["is_active"]),
                CreatedAt = Convert.ToDateTime(row["created_at"]),
                UpdatedAt = Convert.ToDateTime(row["updated_at"])
            };
        }
    }
}
