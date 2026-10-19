using BlumeBee.Data;
using BlumeBee.IRepository;
using BlumeBee.Model;
using Npgsql;
using System.Data;

namespace BlumeBee.Repositories
{
    public class CenterRepository : ICenterRepository
    {
        private readonly PostgresDbHelper _db;

        public CenterRepository(PostgresDbHelper db)
        {
            _db = db;
        }

        public IEnumerable<CenterModel> GetAllActive()
        {
            //string query = "SELECT * FROM blumebee.center";
            string query = "SELECT * FROM blumebee.center WHERE is_active = true";

            var dt = _db.ExecuteQuery(query);
            var list = new List<CenterModel>();

            foreach (DataRow row in dt.Rows)
            {
                list.Add(MapCenter(row));
            }

            return list;
        }
        public IEnumerable<CenterModel> GetAllNonActive()
        {
            //string query = "SELECT * FROM blumebee.center";
            string query = "SELECT * FROM blumebee.center WHERE is_active = false";

            var dt = _db.ExecuteQuery(query);
            var list = new List<CenterModel>();

            foreach (DataRow row in dt.Rows)
            {
                list.Add(MapCenter(row));
            }

            return list;
        }

        public CenterModel GetById(int id)
        {
            string query = "SELECT * FROM blumebee.center WHERE id = @id";

            var parameters = new[]
            {
            new NpgsqlParameter("@id", id)
        };

            var dt = _db.ExecuteQuery(query, parameters);

            if (dt.Rows.Count == 0)
                return null;

            return MapCenter(dt.Rows[0]);
        }

        public int Create(CenterModel center)
        {
            string query = @"
            INSERT INTO blumebee.center
            (code, name, address_line1, city, state, country, pincode, phone, email, is_active)
            VALUES
            (@code, @name, @address, @city, @state, @country, @pincode, @phone, @email, @isActive)";

            var parameters = new[]
            {
            new NpgsqlParameter("@code", center.Code),
            new NpgsqlParameter("@name", center.Name),
            new NpgsqlParameter("@address", (object?)center.AddressLine1 ?? DBNull.Value),
            new NpgsqlParameter("@city", (object?)center.City ?? DBNull.Value),
            new NpgsqlParameter("@state", (object?)center.State ?? DBNull.Value),
            new NpgsqlParameter("@country", center.Country ?? "India"),
            new NpgsqlParameter("@pincode", (object?)center.Pincode ?? DBNull.Value),
            new NpgsqlParameter("@phone", (object?)center.Phone ?? DBNull.Value),
            new NpgsqlParameter("@email", (object?)center.Email ?? DBNull.Value),
            new NpgsqlParameter("@isActive", center.IsActive)
        };

            return _db.ExecuteNonQuery(query, parameters);
        }

        public int Update(CenterModel center)
        {
            string query = @"
            UPDATE blumebee.center
            SET name=@name,
                address_line1=@address,
                city=@city,
                state=@state,
                country=@country,
                pincode=@pincode,
                phone=@phone,
                email=@email,
                is_active=@isActive
            WHERE id=@id";

            var parameters = new[]
            {
            new NpgsqlParameter("@id", center.Id),
            new NpgsqlParameter("@name", center.Name),
            new NpgsqlParameter("@address", (object?)center.AddressLine1 ?? DBNull.Value),
            new NpgsqlParameter("@city", (object?)center.City ?? DBNull.Value),
            new NpgsqlParameter("@state", (object?)center.State ?? DBNull.Value),
            new NpgsqlParameter("@country", center.Country ?? "India"),
            new NpgsqlParameter("@pincode", (object?)center.Pincode ?? DBNull.Value),
            new NpgsqlParameter("@phone", (object?)center.Phone ?? DBNull.Value),
            new NpgsqlParameter("@email", (object?)center.Email ?? DBNull.Value),
            new NpgsqlParameter("@isActive", center.IsActive)
        };

            return _db.ExecuteNonQuery(query, parameters);
        }

        //public int Delete(int id)
        //{
        //    string query = "DELETE FROM blumebee.center WHERE id = @id";

        //    var parameters = new[]
        //    {
        //    new NpgsqlParameter("@id", id)
        //};

        //    return _db.ExecuteNonQuery(query, parameters);
        //}

        public int Delete(int id)
        {
            string query = @"
        UPDATE blumebee.center
        SET is_active = false
        WHERE id = @id";

            var parameters = new[]
            {
        new NpgsqlParameter("@id", id)
    };

            return _db.ExecuteNonQuery(query, parameters);
        }

        // 🔹 Mapping Method (VERY IMPORTANT)
        private CenterModel MapCenter(DataRow row)
        {
            return new CenterModel
            {
                Id = Convert.ToInt32(row["id"]),
                Code = row["code"].ToString(),
                Name = row["name"].ToString(),
                AddressLine1 = row["address_line1"]?.ToString(),
                City = row["city"]?.ToString(),
                State = row["state"]?.ToString(),
                Country = row["country"]?.ToString(),
                Pincode = row["pincode"]?.ToString(),
                Phone = row["phone"]?.ToString(),
                Email = row["email"]?.ToString(),
                IsActive = Convert.ToBoolean(row["is_active"])
            };
        }
    }
}
