using BlumeBee.IRepository;
using BlumeBee.Model;
using BlumeBee.Data;
using Npgsql;
using System.Data;

namespace BlumeBee.Repositories
{
    public class MasterProgramRepository : IMasterProgramRepository
    {
        private readonly PostgresDbHelper _db;

        public MasterProgramRepository(PostgresDbHelper db)
        {
            _db = db;
        }

        public Task<List<MasterProgramModel>> GetAllAsync()
        {
            string query = @"SELECT id, code, name, age_min_months, age_max_months, is_active, sort_order 
                             FROM blumebee.master_program 
                             ORDER BY sort_order, id";

            DataTable dt = _db.ExecuteQuery(query);

            var list = dt.AsEnumerable().Select(row => new MasterProgramModel
            {
                Id = Convert.ToInt32(row["id"]),
                Code = row["code"].ToString(),
                Name = row["name"].ToString(),
                AgeMinMonths = row["age_min_months"] == DBNull.Value ? null : Convert.ToInt32(row["age_min_months"]),
                AgeMaxMonths = row["age_max_months"] == DBNull.Value ? null : Convert.ToInt32(row["age_max_months"]),
                IsActive = Convert.ToBoolean(row["is_active"]),
                SortOrder = row["sort_order"] == DBNull.Value ? null : Convert.ToInt32(row["sort_order"])
            }).ToList();

            return Task.FromResult(list);
        }

        public Task<MasterProgramModel> GetByIdAsync(int id)
        {
            string query = @"SELECT id, code, name, age_min_months, age_max_months, is_active, sort_order 
                             FROM blumebee.master_program 
                             WHERE id=@id";

            var parameters = new[]
            {
                new NpgsqlParameter("@id", id)
            };

            DataTable dt = _db.ExecuteQuery(query, parameters);

            var data = dt.AsEnumerable().Select(row => new MasterProgramModel
            {
                Id = Convert.ToInt32(row["id"]),
                Code = row["code"].ToString(),
                Name = row["name"].ToString(),
                AgeMinMonths = row["age_min_months"] == DBNull.Value ? null : Convert.ToInt32(row["age_min_months"]),
                AgeMaxMonths = row["age_max_months"] == DBNull.Value ? null : Convert.ToInt32(row["age_max_months"]),
                IsActive = Convert.ToBoolean(row["is_active"]),
                SortOrder = row["sort_order"] == DBNull.Value ? null : Convert.ToInt32(row["sort_order"])
            }).FirstOrDefault();

            return Task.FromResult(data);
        }

        public Task<int> CreateAsync(MasterProgramModel model)
        {
            string query = @"INSERT INTO blumebee.master_program 
                             (code, name, age_min_months, age_max_months, is_active, sort_order)
                             VALUES (@code, @name, @ageMin, @ageMax, @isActive, @sortOrder)";

            var parameters = new[]
            {
                new NpgsqlParameter("@code", model.Code),
                new NpgsqlParameter("@name", model.Name),
                new NpgsqlParameter("@ageMin", (object?)model.AgeMinMonths ?? DBNull.Value),
                new NpgsqlParameter("@ageMax", (object?)model.AgeMaxMonths ?? DBNull.Value),
                new NpgsqlParameter("@isActive", model.IsActive),
                new NpgsqlParameter("@sortOrder", (object?)model.SortOrder ?? DBNull.Value)
            };

            int result = _db.ExecuteNonQuery(query, parameters);
            return Task.FromResult(result);
        }

        public Task<int> UpdateAsync(MasterProgramModel model)
        {
            string query = @"UPDATE blumebee.master_program 
                             SET code=@code,
                                 name=@name,
                                 age_min_months=@ageMin,
                                 age_max_months=@ageMax,
                                 is_active=@isActive,
                                 sort_order=@sortOrder
                             WHERE id=@id";

            var parameters = new[]
            {
                new NpgsqlParameter("@id", model.Id),
                new NpgsqlParameter("@code", model.Code),
                new NpgsqlParameter("@name", model.Name),
                new NpgsqlParameter("@ageMin", (object?)model.AgeMinMonths ?? DBNull.Value),
                new NpgsqlParameter("@ageMax", (object?)model.AgeMaxMonths ?? DBNull.Value),
                new NpgsqlParameter("@isActive", model.IsActive),
                new NpgsqlParameter("@sortOrder", (object?)model.SortOrder ?? DBNull.Value)
            };

            int result = _db.ExecuteNonQuery(query, parameters);
            return Task.FromResult(result);
        }

        public Task<int> DeleteAsync(int id)
        {
            string query = "DELETE FROM blumebee.master_program WHERE id=@id";

            var parameters = new[]
            {
                new NpgsqlParameter("@id", id)
            };

            int result = _db.ExecuteNonQuery(query, parameters);
            return Task.FromResult(result);
        }
    }
}