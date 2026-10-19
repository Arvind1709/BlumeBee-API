using Npgsql;
using System.Data;

namespace BlumeBee.Data
{
    public class PostgresDbHelper
    {
        private readonly string _connectionString;

        public PostgresDbHelper(string connectionString)
        {
            _connectionString = connectionString;
        }

        // 🔹 Execute SELECT and return DataTable
        public DataTable ExecuteQuery(string query, NpgsqlParameter[] parameters = null)
        {
            var dt = new DataTable();

            using var conn = new NpgsqlConnection(_connectionString);
            using var cmd = new NpgsqlCommand(query, conn);

            if (parameters != null)
                cmd.Parameters.AddRange(parameters);

            conn.Open();

            using var reader = cmd.ExecuteReader();
            dt.Load(reader);

            return dt;
        }

        // 🔹 Execute INSERT, UPDATE, DELETE
        public int ExecuteNonQuery(string query, NpgsqlParameter[] parameters = null)
        {
            using var conn = new NpgsqlConnection(_connectionString);
            using var cmd = new NpgsqlCommand(query, conn);

            if (parameters != null)
                cmd.Parameters.AddRange(parameters);

            conn.Open();

            return cmd.ExecuteNonQuery();
        }

        // 🔹 Execute Scalar (single value)
        public object ExecuteScalar(string query, NpgsqlParameter[] parameters = null)
        {
            using var conn = new NpgsqlConnection(_connectionString);
            using var cmd = new NpgsqlCommand(query, conn);

            if (parameters != null)
                cmd.Parameters.AddRange(parameters);

            conn.Open();

            return cmd.ExecuteScalar();
        }
    }
}
