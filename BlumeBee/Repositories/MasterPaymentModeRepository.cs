using BlumeBee.Data;
using BlumeBee.IRepository;
using BlumeBee.Model;
using Npgsql;
using System.Data;

namespace BlumeBee.Repositories
{
    public class MasterPaymentModeRepository : IMasterPaymentModeRepository
    {
        private readonly PostgresDbHelper _db;

        public MasterPaymentModeRepository(PostgresDbHelper db)
        {
            _db = db;
        }

        public Task<List<MasterPaymentModeModel>> GetAllAsync()
        {
            string query = @"SELECT id, code, name
                             FROM blumebee.master_payment_mode
                             ORDER BY id";

            DataTable dt = _db.ExecuteQuery(query);

            var list = dt.AsEnumerable().Select(row => new MasterPaymentModeModel
            {
                Id = Convert.ToInt32(row["id"]),
                Code = row["code"].ToString(),
                Name = row["name"].ToString()
            }).ToList();

            return Task.FromResult(list);
        }

        public Task<MasterPaymentModeModel> GetByIdAsync(int id)
        {
            string query = @"SELECT id, code, name
                             FROM blumebee.master_payment_mode
                             WHERE id=@id";

            var parameters = new[]
            {
                new NpgsqlParameter("@id", id)
            };

            DataTable dt = _db.ExecuteQuery(query, parameters);

            var data = dt.AsEnumerable().Select(row => new MasterPaymentModeModel
            {
                Id = Convert.ToInt32(row["id"]),
                Code = row["code"].ToString(),
                Name = row["name"].ToString()
            }).FirstOrDefault();

            return Task.FromResult(data);
        }

        public Task<int> CreateAsync(MasterPaymentModeModel model)
        {
            string query = @"INSERT INTO blumebee.master_payment_mode
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

        public Task<int> UpdateAsync(MasterPaymentModeModel model)
        {
            string query = @"UPDATE blumebee.master_payment_mode
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
            string query = "DELETE FROM blumebee.master_payment_mode WHERE id=@id";

            var parameters = new[]
            {
                new NpgsqlParameter("@id", id)
            };

            int result = _db.ExecuteNonQuery(query, parameters);
            return Task.FromResult(result);
        }
    }
}
