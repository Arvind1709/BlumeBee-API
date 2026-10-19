using BlumeBee.Data;
using BlumeBee.IRepository;
using BlumeBee.Model;
using Npgsql;
using System.Data;

namespace BlumeBee.Repositories
{
    public class MasterLeadStatusRepository : IMasterLeadStatusRepository
    {
        private readonly PostgresDbHelper _db;

        public MasterLeadStatusRepository(PostgresDbHelper db)
        {
            _db = db;
        }

        public Task<List<MasterLeadStatusModel>> GetAllAsync()
        {
            string query = @"SELECT id, code, name, is_active, sort_order
                             FROM blumebee.master_lead_status
                             ORDER BY sort_order, id";

            DataTable dt = _db.ExecuteQuery(query);

            var list = dt.AsEnumerable().Select(row => new MasterLeadStatusModel
            {
                Id = Convert.ToInt32(row["id"]),
                Code = row["code"].ToString(),
                Name = row["name"].ToString(),
                IsActive = Convert.ToBoolean(row["is_active"]),
                SortOrder = row["sort_order"] == DBNull.Value ? null : Convert.ToInt32(row["sort_order"])
            }).ToList();

            return Task.FromResult(list);
        }

        public Task<MasterLeadStatusModel> GetByIdAsync(int id)
        {
            string query = @"SELECT id, code, name, is_active, sort_order
                             FROM blumebee.master_lead_status
                             WHERE id=@id";

            var parameters = new[]
            {
                new NpgsqlParameter("@id", id)
            };

            DataTable dt = _db.ExecuteQuery(query, parameters);

            var data = dt.AsEnumerable().Select(row => new MasterLeadStatusModel
            {
                Id = Convert.ToInt32(row["id"]),
                Code = row["code"].ToString(),
                Name = row["name"].ToString(),
                IsActive = Convert.ToBoolean(row["is_active"]),
                SortOrder = row["sort_order"] == DBNull.Value ? null : Convert.ToInt32(row["sort_order"])
            }).FirstOrDefault();

            return Task.FromResult(data);
        }

        public Task<int> CreateAsync(MasterLeadStatusModel model)
        {
            string query = @"INSERT INTO blumebee.master_lead_status
                             (code, name, is_active, sort_order)
                             VALUES (@code, @name, @isActive, @sortOrder)";

            var parameters = new[]
            {
                new NpgsqlParameter("@code", model.Code),
                new NpgsqlParameter("@name", model.Name),
                new NpgsqlParameter("@isActive", model.IsActive),
                new NpgsqlParameter("@sortOrder", (object?)model.SortOrder ?? DBNull.Value)
            };

            int result = _db.ExecuteNonQuery(query, parameters);
            return Task.FromResult(result);
        }

        public Task<int> UpdateAsync(MasterLeadStatusModel model)
        {
            string query = @"UPDATE blumebee.master_lead_status
                             SET code=@code,
                                 name=@name,
                                 is_active=@isActive,
                                 sort_order=@sortOrder
                             WHERE id=@id";

            var parameters = new[]
            {
                new NpgsqlParameter("@id", model.Id),
                new NpgsqlParameter("@code", model.Code),
                new NpgsqlParameter("@name", model.Name),
                new NpgsqlParameter("@isActive", model.IsActive),
                new NpgsqlParameter("@sortOrder", (object?)model.SortOrder ?? DBNull.Value)
            };

            int result = _db.ExecuteNonQuery(query, parameters);
            return Task.FromResult(result);
        }

        public Task<int> DeleteAsync(int id)
        {
            // You can convert this to soft delete if needed
            string query = "DELETE FROM blumebee.master_lead_status WHERE id=@id";

            var parameters = new[]
            {
                new NpgsqlParameter("@id", id)
            };

            int result = _db.ExecuteNonQuery(query, parameters);
            return Task.FromResult(result);
        }
    }
}
