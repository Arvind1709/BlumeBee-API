using BlumeBee.Data;
using BlumeBee.IRepository;
using BlumeBee.Model;
using Npgsql;
using System.Data;

namespace BlumeBee.Repositories
{
    public class MasterSeverityRepository : IMasterSeverityRepository
    {
        private readonly PostgresDbHelper _db;

        public MasterSeverityRepository(PostgresDbHelper db)
        {
            _db = db;
        }

        public Task<List<MasterSeverityModel>> GetAllAsync()
        {
            string query = @"SELECT id, code, name, severity_rank
                             FROM blumebee.master_severity
                             ORDER BY severity_rank, id";

            DataTable dt = _db.ExecuteQuery(query);

            var list = dt.AsEnumerable().Select(row => new MasterSeverityModel
            {
                Id = Convert.ToInt32(row["id"]),
                Code = row["code"].ToString(),
                Name = row["name"].ToString(),
                SeverityRank = row["severity_rank"] == DBNull.Value ? null : Convert.ToInt32(row["severity_rank"])
            }).ToList();

            return Task.FromResult(list);
        }

        public Task<MasterSeverityModel> GetByIdAsync(int id)
        {
            string query = @"SELECT id, code, name, severity_rank
                             FROM blumebee.master_severity
                             WHERE id=@id";

            var parameters = new[]
            {
                new NpgsqlParameter("@id", id)
            };

            DataTable dt = _db.ExecuteQuery(query, parameters);

            var data = dt.AsEnumerable().Select(row => new MasterSeverityModel
            {
                Id = Convert.ToInt32(row["id"]),
                Code = row["code"].ToString(),
                Name = row["name"].ToString(),
                SeverityRank = row["severity_rank"] == DBNull.Value ? null : Convert.ToInt32(row["severity_rank"])
            }).FirstOrDefault();

            return Task.FromResult(data);
        }

        public Task<int> CreateAsync(MasterSeverityModel model)
        {
            string query = @"INSERT INTO blumebee.master_severity
                             (code, name, severity_rank)
                             VALUES (@code, @name, @severityRank)";

            var parameters = new[]
            {
                new NpgsqlParameter("@code", model.Code),
                new NpgsqlParameter("@name", model.Name),
                new NpgsqlParameter("@severityRank", (object?)model.SeverityRank ?? DBNull.Value)
            };

            int result = _db.ExecuteNonQuery(query, parameters);
            return Task.FromResult(result);
        }

        public Task<int> UpdateAsync(MasterSeverityModel model)
        {
            string query = @"UPDATE blumebee.master_severity
                             SET code=@code,
                                 name=@name,
                                 severity_rank=@severityRank
                             WHERE id=@id";

            var parameters = new[]
            {
                new NpgsqlParameter("@id", model.Id),
                new NpgsqlParameter("@code", model.Code),
                new NpgsqlParameter("@name", model.Name),
                new NpgsqlParameter("@severityRank", (object?)model.SeverityRank ?? DBNull.Value)
            };

            int result = _db.ExecuteNonQuery(query, parameters);
            return Task.FromResult(result);
        }

        public Task<int> DeleteAsync(int id)
        {
            string query = @"DELETE FROM blumebee.master_severity
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
