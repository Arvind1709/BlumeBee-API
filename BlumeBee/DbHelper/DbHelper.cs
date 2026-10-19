using Npgsql;
using System.Data;

namespace BlumeBee.DbHelper
{
    //public class DbHelper
    //{
    //    private readonly string _connectionString;

    //    public DbHelper(IConfiguration configuration)
    //    {
    //        _connectionString = configuration.GetConnectionString("DefaultConnection");
    //    }

    //    public async Task<DataTable> ExecuteQueryAsync(string query)
    //    {
    //        using var conn = new NpgsqlConnection(_connectionString);
    //        using var cmd = new NpgsqlCommand(query, conn);

    //        await conn.OpenAsync();

    //        using var reader = await cmd.ExecuteReaderAsync();
    //        var dt = new DataTable();
    //        dt.Load(reader);

    //        return dt;
    //    }

    //    public async Task<int> ExecuteNonQueryAsync(string query)
    //    {
    //        using var conn = new NpgsqlConnection(_connectionString);
    //        using var cmd = new NpgsqlCommand(query, conn);

    //        await conn.OpenAsync();
    //        return await cmd.ExecuteNonQueryAsync();
    //    }
    //}
}
