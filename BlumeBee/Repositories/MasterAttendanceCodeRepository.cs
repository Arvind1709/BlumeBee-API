using BlumeBee.Data;
using BlumeBee.IRepository;
using BlumeBee.Model;
using Npgsql;
using System.Data;

namespace BlumeBee.Repositories
{
    public class MasterAttendanceCodeRepository : IMasterAttendanceCodeRepository
    {
        private readonly PostgresDbHelper _db;

        public MasterAttendanceCodeRepository(PostgresDbHelper db)
        {
            _db = db;
        }

        public Task<List<MasterAttendanceCodeModel>> GetAllAsync()
        {
            string query = @"SELECT id, code, name
                             FROM blumebee.master_attendance_code
                             ORDER BY id";

            DataTable dt = _db.ExecuteQuery(query);

            var list = dt.AsEnumerable().Select(row => new MasterAttendanceCodeModel
            {
                Id = Convert.ToInt32(row["id"]),
                Code = row["code"].ToString(),
                Name = row["name"].ToString()
            }).ToList();

            return Task.FromResult(list);
        }

        public Task<MasterAttendanceCodeModel> GetByIdAsync(int id)
        {
            string query = @"SELECT id, code, name
                             FROM blumebee.master_attendance_code
                             WHERE id=@id";

            var parameters = new[]
            {
                new NpgsqlParameter("@id", id)
            };

            DataTable dt = _db.ExecuteQuery(query, parameters);

            var data = dt.AsEnumerable().Select(row => new MasterAttendanceCodeModel
            {
                Id = Convert.ToInt32(row["id"]),
                Code = row["code"].ToString(),
                Name = row["name"].ToString()
            }).FirstOrDefault();

            return Task.FromResult(data);
        }

        public Task<int> CreateAsync(MasterAttendanceCodeModel model)
        {
            string query = @"INSERT INTO blumebee.master_attendance_code
                             (code, name)
                             VALUES (@code, @name)";

            var parameters = new[]
            {
                new NpgsqlParameter("@code", model.Code),
                new NpgsqlParameter("@name", model.Name)
            };

            int result = _db.ExecuteNonQuery(query, parameters);
            return Task.FromResult(result);
        }

        public Task<int> UpdateAsync(MasterAttendanceCodeModel model)
        {
            string query = @"UPDATE blumebee.master_attendance_code
                             SET code=@code,
                                 name=@name
                             WHERE id=@id";

            var parameters = new[]
            {
                new NpgsqlParameter("@id", model.Id),
                new NpgsqlParameter("@code", model.Code),
                new NpgsqlParameter("@name", model.Name)
            };

            int result = _db.ExecuteNonQuery(query, parameters);
            return Task.FromResult(result);
        }

        public Task<int> DeleteAsync(int id)
        {
            string query = @"DELETE FROM blumebee.master_attendance_code
                             WHERE id=@id";

            var parameters = new[]
            {
                new NpgsqlParameter("@id", id)
            };

            int result = _db.ExecuteNonQuery(query, parameters);
            return Task.FromResult(result);
        }
    }
}
