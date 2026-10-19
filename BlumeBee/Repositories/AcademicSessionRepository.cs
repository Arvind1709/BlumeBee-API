using BlumeBee.Data;
using BlumeBee.IRepository;
using BlumeBee.Model;
using Npgsql;
using System.Data;

namespace BlumeBee.Repositories
{
    public class AcademicSessionRepository : IAcademicSessionRepository
    {
        private readonly PostgresDbHelper _db;

        public AcademicSessionRepository(PostgresDbHelper db)
        {
            _db = db;
        }

        public IEnumerable<AcademicSessionModel> GetAllActive()
        {
            string query = "SELECT * FROM blumebee.academic_session WHERE is_active = true";

            var dt = _db.ExecuteQuery(query);
            return MapList(dt);
        }

        public IEnumerable<AcademicSessionModel> GetAllNonActive()
        {
            string query = "SELECT * FROM blumebee.academic_session WHERE is_active = false";

            var dt = _db.ExecuteQuery(query);
            return MapList(dt);
        }

        public AcademicSessionModel GetById(int id)
        {
            string query = "SELECT * FROM blumebee.academic_session WHERE id = @id";

            var parameters = new[]
            {
            new NpgsqlParameter("@id", id)
        };

            var dt = _db.ExecuteQuery(query, parameters);

            if (dt.Rows.Count == 0)
                return null;

            return Map(dt.Rows[0]);
        }

        public int Create(AcademicSessionModel model)
        {
            string query = @"
            INSERT INTO blumebee.academic_session
            (name, start_date, end_date, is_active)
            VALUES
            (@name, @start, @end, @isActive)";

            var parameters = new[]
            {
            new NpgsqlParameter("@name", model.Name),
            new NpgsqlParameter("@start", model.StartDate),
            new NpgsqlParameter("@end", model.EndDate),
            new NpgsqlParameter("@isActive", model.IsActive)
        };

            return _db.ExecuteNonQuery(query, parameters);
        }

        public int Update(AcademicSessionModel model)
        {
            string query = @"
            UPDATE blumebee.academic_session
            SET name=@name,
                start_date=@start,
                end_date=@end,
                is_active=@isActive
            WHERE id=@id";

            var parameters = new[]
            {
            new NpgsqlParameter("@id", model.Id),
            new NpgsqlParameter("@name", model.Name),
            new NpgsqlParameter("@start", model.StartDate),
            new NpgsqlParameter("@end", model.EndDate),
            new NpgsqlParameter("@isActive", model.IsActive)
        };

            return _db.ExecuteNonQuery(query, parameters);
        }

        // ✅ Soft Delete
        public int Delete(int id)
        {
            string query = @"
            UPDATE blumebee.academic_session
            SET is_active = false
            WHERE id = @id";

            var parameters = new[]
            {
            new NpgsqlParameter("@id", id)
        };

            return _db.ExecuteNonQuery(query, parameters);
        }

        // 🔹 Common Mapping
        private List<AcademicSessionModel> MapList(DataTable dt)
        {
            var list = new List<AcademicSessionModel>();

            foreach (DataRow row in dt.Rows)
            {
                list.Add(Map(row));
            }

            return list;
        }

        private AcademicSessionModel Map(DataRow row)
        {
            return new AcademicSessionModel
            {
                Id = Convert.ToInt32(row["id"]),
                Name = row["name"].ToString(),
                StartDate = Convert.ToDateTime(row["start_date"]),
                EndDate = Convert.ToDateTime(row["end_date"]),
                IsActive = Convert.ToBoolean(row["is_active"])
            };
        }
    }
}
