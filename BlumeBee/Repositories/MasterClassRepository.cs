using BlumeBee.Data;
using BlumeBee.IRepository;
using BlumeBee.Model;
using Npgsql;
using System.Data;

namespace BlumeBee.Repositories
{
    public class MasterClassRepository : IMasterClassRepository
    {
        private readonly PostgresDbHelper _db;

        public MasterClassRepository(PostgresDbHelper db)
        {
            _db = db;
        }

        public Task<List<MasterClassModel>> GetAllAsync()
        {
            string query = @"SELECT id, program_id, code, name, capacity, is_active, sort_order
                             FROM blumebee.master_class
                             ORDER BY sort_order, id";

            DataTable dt = _db.ExecuteQuery(query);

            var list = dt.AsEnumerable().Select(row => new MasterClassModel
            {
                Id = Convert.ToInt32(row["id"]),
                ProgramId = row["program_id"] == DBNull.Value ? null : Convert.ToInt32(row["program_id"]),
                Code = row["code"].ToString(),
                Name = row["name"].ToString(),
                Capacity = row["capacity"] == DBNull.Value ? null : Convert.ToInt32(row["capacity"]),
                IsActive = Convert.ToBoolean(row["is_active"]),
                SortOrder = row["sort_order"] == DBNull.Value ? null : Convert.ToInt32(row["sort_order"])
            }).ToList();

            return Task.FromResult(list);
        }

        public Task<MasterClassModel> GetByIdAsync(int id)
        {
            string query = @"SELECT id, program_id, code, name, capacity, is_active, sort_order
                             FROM blumebee.master_class
                             WHERE id=@id";

            var parameters = new[]
            {
                new NpgsqlParameter("@id", id)
            };

            DataTable dt = _db.ExecuteQuery(query, parameters);

            var data = dt.AsEnumerable().Select(row => new MasterClassModel
            {
                Id = Convert.ToInt32(row["id"]),
                ProgramId = row["program_id"] == DBNull.Value ? null : Convert.ToInt32(row["program_id"]),
                Code = row["code"].ToString(),
                Name = row["name"].ToString(),
                Capacity = row["capacity"] == DBNull.Value ? null : Convert.ToInt32(row["capacity"]),
                IsActive = Convert.ToBoolean(row["is_active"]),
                SortOrder = row["sort_order"] == DBNull.Value ? null : Convert.ToInt32(row["sort_order"])
            }).FirstOrDefault();

            return Task.FromResult(data);
        }

        public Task<int> CreateAsync(MasterClassModel model)
        {
            string query = @"INSERT INTO blumebee.master_class
                             (program_id, code, name, capacity, is_active, sort_order)
                             VALUES (@programId, @code, @name, @capacity, @isActive, @sortOrder)";

            var parameters = new[]
            {
                new NpgsqlParameter("@programId", (object?)model.ProgramId ?? DBNull.Value),
                new NpgsqlParameter("@code", model.Code),
                new NpgsqlParameter("@name", model.Name),
                new NpgsqlParameter("@capacity", (object?)model.Capacity ?? DBNull.Value),
                new NpgsqlParameter("@isActive", model.IsActive),
                new NpgsqlParameter("@sortOrder", (object?)model.SortOrder ?? DBNull.Value)
            };

            int result = _db.ExecuteNonQuery(query, parameters);
            return Task.FromResult(result);
        }

        public Task<int> UpdateAsync(MasterClassModel model)
        {
            string query = @"UPDATE blumebee.master_class
                             SET program_id=@programId,
                                 code=@code,
                                 name=@name,
                                 capacity=@capacity,
                                 is_active=@isActive,
                                 sort_order=@sortOrder
                             WHERE id=@id";

            var parameters = new[]
            {
                new NpgsqlParameter("@id", model.Id),
                new NpgsqlParameter("@programId", (object?)model.ProgramId ?? DBNull.Value),
                new NpgsqlParameter("@code", model.Code),
                new NpgsqlParameter("@name", model.Name),
                new NpgsqlParameter("@capacity", (object?)model.Capacity ?? DBNull.Value),
                new NpgsqlParameter("@isActive", model.IsActive),
                new NpgsqlParameter("@sortOrder", (object?)model.SortOrder ?? DBNull.Value)
            };

            int result = _db.ExecuteNonQuery(query, parameters);
            return Task.FromResult(result);
        }

        public Task<int> DeleteAsync(int id)
        {
            string query = "DELETE FROM blumebee.master_class WHERE id=@id";

            var parameters = new[]
            {
                new NpgsqlParameter("@id", id)
            };

            int result = _db.ExecuteNonQuery(query, parameters);
            return Task.FromResult(result);
        }
    }
}
