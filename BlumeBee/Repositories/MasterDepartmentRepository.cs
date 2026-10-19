using BlumeBee.Data;
using BlumeBee.IRepository;
using BlumeBee.Model;
using Npgsql;
using System.Data;

namespace BlumeBee.Repositories
{
    public class MasterDepartmentRepository : IMasterDepartmentRepository
    {
        private readonly PostgresDbHelper _db;

        public MasterDepartmentRepository(PostgresDbHelper db)
        {
            _db = db;
        }

        public Task<List<MasterDepartmentModel>> GetAllAsync()
        {
            string query = @"SELECT id, code, name, is_active
                             FROM blumebee.master_department
                             ORDER BY id";

            DataTable dt = _db.ExecuteQuery(query);

            var list = dt.AsEnumerable().Select(row => new MasterDepartmentModel
            {
                Id = Convert.ToInt32(row["id"]),
                Code = row["code"].ToString(),
                Name = row["name"].ToString(),
                IsActive = Convert.ToBoolean(row["is_active"])
            }).ToList();

            return Task.FromResult(list);
        }

        public Task<MasterDepartmentModel> GetByIdAsync(int id)
        {
            string query = @"SELECT id, code, name, is_active
                             FROM blumebee.master_department
                             WHERE id=@id";

            var parameters = new[]
            {
                new NpgsqlParameter("@id", id)
            };

            DataTable dt = _db.ExecuteQuery(query, parameters);

            var data = dt.AsEnumerable().Select(row => new MasterDepartmentModel
            {
                Id = Convert.ToInt32(row["id"]),
                Code = row["code"].ToString(),
                Name = row["name"].ToString(),
                IsActive = Convert.ToBoolean(row["is_active"])
            }).FirstOrDefault();

            return Task.FromResult(data);
        }

        public Task<int> CreateAsync(MasterDepartmentModel model)
        {
            string query = @"INSERT INTO blumebee.master_department
                             (code, name, is_active)
                             VALUES (@code, @name, @isActive)";

            var parameters = new[]
            {
                new NpgsqlParameter("@code", model.Code),
                new NpgsqlParameter("@name", model.Name),
                new NpgsqlParameter("@isActive", model.IsActive)
            };

            int result = _db.ExecuteNonQuery(query, parameters);
            return Task.FromResult(result);
        }

        public Task<int> UpdateAsync(MasterDepartmentModel model)
        {
            string query = @"UPDATE blumebee.master_department
                             SET code=@code,
                                 name=@name,
                                 is_active=@isActive
                             WHERE id=@id";

            var parameters = new[]
            {
                new NpgsqlParameter("@id", model.Id),
                new NpgsqlParameter("@code", model.Code),
                new NpgsqlParameter("@name", model.Name),
                new NpgsqlParameter("@isActive", model.IsActive)
            };

            int result = _db.ExecuteNonQuery(query, parameters);
            return Task.FromResult(result);
        }

        public Task<int> DeleteAsync(int id)
        {
            // Prefer soft delete in production
            string query = @"DELETE FROM blumebee.master_department WHERE id=@id";

            var parameters = new[]
            {
                new NpgsqlParameter("@id", id)
            };

            int result = _db.ExecuteNonQuery(query, parameters);
            return Task.FromResult(result);
        }
    }
}
