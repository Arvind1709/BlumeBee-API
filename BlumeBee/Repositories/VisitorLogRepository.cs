using BlumeBee.Data;
using BlumeBee.IRepository;
using BlumeBee.Model;
using BlumeBee.ModelDTO;
using Npgsql;
using System.Data;

namespace BlumeBee.Repositories
{
    public class VisitorLogRepository : IVisitorLogRepository
    {
        private readonly PostgresDbHelper _db;

        public VisitorLogRepository(PostgresDbHelper db)
        {
            _db = db;
        }

        // 🔹 GET ALL
        public List<VisitorLogModel> GetAll()
        {
            var dt = _db.ExecuteQuery("SELECT * FROM blumebee.visitor_log ORDER BY id DESC");

            var list = new List<VisitorLogModel>();

            foreach (DataRow row in dt.Rows)
            {
                list.Add(Map(row));
            }

            return list;
        }

        // 🔹 GET BY ID
        public VisitorLogModel? GetById(long id)
        {
            var dt = _db.ExecuteQuery(
                "SELECT * FROM blumebee.visitor_log WHERE id = @id",
                new[]
                {
                    new NpgsqlParameter("@id", id)
                });

            if (dt.Rows.Count == 0)
                return null;

            return Map(dt.Rows[0]);
        }

        // 🔹 INSERT
        public long Insert(VisitorLogModelDto model)
        {
            var sql = @"
                INSERT INTO blumebee.visitor_log
                (visit_date, visitor_name, contact_number, purpose_of_visit,
                 in_time, out_time, person_met, id_verified, remarks)
                VALUES
                (@visit_date, @visitor_name, @contact_number, @purpose_of_visit,
                 @in_time, @out_time, @person_met, @id_verified, @remarks)
                RETURNING id;
            ";

            var result = _db.ExecuteScalar(sql, new[]
            {
                new NpgsqlParameter("@visit_date", model.VisitDate),
                new NpgsqlParameter("@visitor_name", model.VisitorName),
                new NpgsqlParameter("@contact_number", (object?)model.ContactNumber ?? DBNull.Value),
                new NpgsqlParameter("@purpose_of_visit", (object?)model.PurposeOfVisit ?? DBNull.Value),
                new NpgsqlParameter("@in_time", (object?)model.InTime ?? DBNull.Value),
                new NpgsqlParameter("@out_time", (object?)model.OutTime ?? DBNull.Value),
                new NpgsqlParameter("@person_met", (object?)model.PersonMet ?? DBNull.Value),
                new NpgsqlParameter("@id_verified", model.IdVerified),
                new NpgsqlParameter("@remarks", (object?)model.Remarks ?? DBNull.Value)
            });

            return Convert.ToInt64(result);
        }

        // 🔹 UPDATE
        public bool Update(long id, VisitorLogModelDto model)
        {
            var sql = @"
                UPDATE blumebee.visitor_log
                SET visit_date = @visit_date,
                    visitor_name = @visitor_name,
                    contact_number = @contact_number,
                    purpose_of_visit = @purpose_of_visit,
                    in_time = @in_time,
                    out_time = @out_time,
                    person_met = @person_met,
                    id_verified = @id_verified,
                    remarks = @remarks
                WHERE id = @id;
            ";

            var affected = _db.ExecuteNonQuery(sql, new[]
            {
                new NpgsqlParameter("@visit_date", model.VisitDate),
                new NpgsqlParameter("@visitor_name", model.VisitorName),
                new NpgsqlParameter("@contact_number", (object?)model.ContactNumber ?? DBNull.Value),
                new NpgsqlParameter("@purpose_of_visit", (object?)model.PurposeOfVisit ?? DBNull.Value),
                new NpgsqlParameter("@in_time", (object?)model.InTime ?? DBNull.Value),
                new NpgsqlParameter("@out_time", (object?)model.OutTime ?? DBNull.Value),
                new NpgsqlParameter("@person_met", (object?)model.PersonMet ?? DBNull.Value),
                new NpgsqlParameter("@id_verified", model.IdVerified),
                new NpgsqlParameter("@remarks", (object?)model.Remarks ?? DBNull.Value),
                new NpgsqlParameter("@id", id)
            });

            return affected > 0;
        }

        // 🔹 DELETE
        public bool Delete(long id)
        {
            var affected = _db.ExecuteNonQuery(
                "DELETE FROM blumebee.visitor_log WHERE id = @id",
                new[]
                {
                    new NpgsqlParameter("@id", id)
                });

            return affected > 0;
        }

        // 🔹 MAPPING
        private VisitorLogModel Map(DataRow row)
        {
            return new VisitorLogModel
            {
                Id = Convert.ToInt64(row["id"]),
                VisitDate = Convert.ToDateTime(row["visit_date"]),
                VisitorName = row["visitor_name"].ToString(),
                ContactNumber = row["contact_number"] == DBNull.Value ? null : row["contact_number"].ToString(),
                PurposeOfVisit = row["purpose_of_visit"] == DBNull.Value ? null : row["purpose_of_visit"].ToString(),
                InTime = row["in_time"] == DBNull.Value ? null : (TimeSpan?)row["in_time"],
                OutTime = row["out_time"] == DBNull.Value ? null : (TimeSpan?)row["out_time"],
                PersonMet = row["person_met"] == DBNull.Value ? null : row["person_met"].ToString(),
                IdVerified = Convert.ToBoolean(row["id_verified"]),
                Remarks = row["remarks"] == DBNull.Value ? null : row["remarks"].ToString()
            };
        }
    }
}
