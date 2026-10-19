using BlumeBee.Data;
using BlumeBee.IRepository;
using BlumeBee.Model;
using Npgsql;
using System.Data;

namespace BlumeBee.Repositories
{
    public class MasterLeaveTypeRepository: IMasterLeaveTypeRepository
    {
        private readonly PostgresDbHelper _db;

        public MasterLeaveTypeRepository(PostgresDbHelper db)
        {
            _db = db;
        }

        public Task<List<MasterLeaveTypeModel>> GetAllAsync()
        {
            string query = @"SELECT id, code, name
                             FROM blumebee.master_leave_type
                             ORDER BY id";

            DataTable dt = _db.ExecuteQuery(query);

            var list = dt.AsEnumerable().Select(row => new MasterLeaveTypeModel
            {
                Id = Convert.ToInt32(row["id"]),
                Code = row["code"].ToString(),
                Name = row["name"].ToString()
            }).ToList();

            return Task.FromResult(list);
        }

        public Task<MasterLeaveTypeModel> GetByIdAsync(int id)
        {
            string query = @"SELECT id, code, name
                             FROM blumebee.master_leave_type
                             WHERE id=@id";

            var parameters = new[]
            {
                new NpgsqlParameter("@id", id)
            };

            DataTable dt = _db.ExecuteQuery(query, parameters);

            var data = dt.AsEnumerable().Select(row => new MasterLeaveTypeModel
            {
                Id = Convert.ToInt32(row["id"]),
                Code = row["code"].ToString(),
                Name = row["name"].ToString()
            }).FirstOrDefault();

            return Task.FromResult(data);
        }

        public Task<int> CreateAsync(MasterLeaveTypeModel model)
        {
            string query = @"INSERT INTO blumebee.master_leave_type
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

        public Task<int> UpdateAsync(MasterLeaveTypeModel model)
        {
            string query = @"UPDATE blumebee.master_leave_type
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
            string query = @"DELETE FROM blumebee.master_leave_type
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
