using BlumeBee.Data;
using BlumeBee.IRepository;
using BlumeBee.Model;
using Npgsql;
using System.Data;

namespace BlumeBee.Repositories
{
    public class MasterLeadSourceRepository : IMasterLeadSourceRepository
    {
        private readonly PostgresDbHelper _dbHelper;

        public MasterLeadSourceRepository(PostgresDbHelper dbHelper)
        {
            _dbHelper = dbHelper;
        }

        public int Insert(MasterLeadSourceModel model)
        {
            string query = @"INSERT INTO blumebee.master_lead_source
                             (code, name, is_active, sort_order)
                             VALUES
                             (@p_code, @p_name, @p_is_active, @p_sort_order)";

            var parameters = new NpgsqlParameter[]
            {
                new NpgsqlParameter("@p_code", model.Code),
                new NpgsqlParameter("@p_name", model.Name),
                new NpgsqlParameter("@p_is_active", model.IsActive),
                new NpgsqlParameter("@p_sort_order", model.SortOrder ?? (object)DBNull.Value)
            };

            return _dbHelper.ExecuteNonQuery(query, parameters);
        }

        public int Update(MasterLeadSourceModel model)
        {
            string query = @"UPDATE blumebee.master_lead_source
                             SET code = @p_code,
                                 name = @p_name,
                                 is_active = @p_is_active,
                                 sort_order = @p_sort_order
                             WHERE id = @p_id";

            var parameters = new NpgsqlParameter[]
            {
                new NpgsqlParameter("@p_id", model.Id),
                new NpgsqlParameter("@p_code", model.Code),
                new NpgsqlParameter("@p_name", model.Name),
                new NpgsqlParameter("@p_is_active", model.IsActive),
                new NpgsqlParameter("@p_sort_order", model.SortOrder ?? (object)DBNull.Value)
            };

            return _dbHelper.ExecuteNonQuery(query, parameters);
        }

        public int Delete(int id)
        {
            string query = @"DELETE FROM blumebee.master_lead_source WHERE id = @p_id";

            var parameters = new NpgsqlParameter[]
            {
                new NpgsqlParameter("@p_id", id)
            };

            return _dbHelper.ExecuteNonQuery(query, parameters);
        }

        public List<MasterLeadSourceModel> GetAll()
        {
            string query = @"SELECT id, code, name, is_active, sort_order
                             FROM blumebee.master_lead_source
                             ORDER BY sort_order, id";

            DataTable dt = _dbHelper.ExecuteQuery(query);

            List<MasterLeadSourceModel> list = new List<MasterLeadSourceModel>();

            foreach (DataRow row in dt.Rows)
            {
                list.Add(new MasterLeadSourceModel
                {
                    Id = Convert.ToInt32(row["id"]),
                    Code = row["code"].ToString(),
                    Name = row["name"].ToString(),
                    IsActive = Convert.ToBoolean(row["is_active"]),
                    SortOrder = row["sort_order"] == DBNull.Value ? null : Convert.ToInt32(row["sort_order"])
                });
            }

            return list;
        }

        public MasterLeadSourceModel GetById(int id)
        {
            string query = @"SELECT id, code, name, is_active, sort_order
                             FROM blumebee.master_lead_source
                             WHERE id = @p_id";

            var parameters = new NpgsqlParameter[]
            {
                new NpgsqlParameter("@p_id", id)
            };

            DataTable dt = _dbHelper.ExecuteQuery(query, parameters);

            if (dt.Rows.Count == 0)
                return null;

            DataRow row = dt.Rows[0];

            return new MasterLeadSourceModel
            {
                Id = Convert.ToInt32(row["id"]),
                Code = row["code"].ToString(),
                Name = row["name"].ToString(),
                IsActive = Convert.ToBoolean(row["is_active"]),
                SortOrder = row["sort_order"] == DBNull.Value ? null : Convert.ToInt32(row["sort_order"])
            };
        }
    }
}
