using System.Data;
using System.Reflection;
using System.Text.RegularExpressions;
using BlumeBee.Data;
using Npgsql;

namespace BlumeBee.Services;

/// <summary>
/// Shared parameterized CRUD implementation for the modules added from the BlumeBee SQL package.
/// Table names are restricted to the compile-time allow-list; column names come from DTO properties.
/// </summary>
public sealed class DynamicCrudService
{
    private static readonly HashSet<string> AllowedTables = new(StringComparer.OrdinalIgnoreCase)
    {
        "student_parent", "visit", "student_document", "authorized_pickup", "student_health_record", "staff_training", "staff_verification", "payroll", "fee_structure", "student_bill", "student_discount", "student_refund", "student_ledger", "parent_communication", "parent_meeting", "parent_concern", "parent_engagement", "broadcast_log", "daily_child_update", "learning_outcome", "student_observation", "student_intervention", "student_assessment", "curriculum_annual_map", "weekly_lesson_plan", "daily_activity_plan", "incident_report", "medicine_administration", "emergency_drill", "cctv_audit", "safety_checklist", "inventory_item", "maintenance_log", "complaint", "document_tracker", "task_register", "event_planner", "vendor_amc"
    };

    private readonly PostgresDbHelper _db;
    public DynamicCrudService(PostgresDbHelper db) => _db = db;

    public IReadOnlyList<TResponse> GetAll<TResponse>(string table) where TResponse : class, new()
    {
        ValidateTable(table);
        return MapRows<TResponse>(_db.ExecuteQuery($"SELECT * FROM blumebee.{table} ORDER BY id DESC"));
    }

    public TResponse? GetById<TResponse>(string table, long id) where TResponse : class, new()
    {
        ValidateTable(table);
        var rows = MapRows<TResponse>(_db.ExecuteQuery($"SELECT * FROM blumebee.{table} WHERE id = @id", new[] { new NpgsqlParameter("id", id) }));
        return rows.FirstOrDefault();
    }

    public long Create<TDto>(string table, TDto dto)
    {
        ValidateTable(table);
        var values = GetProperties(dto).Where(x => x.Value is not null).ToList();
        if (values.Count == 0) throw new ArgumentException("At least one field must be supplied.");
        var columns = string.Join(", ", values.Select(x => Quote(SnakeCase(x.Name))));
        var parameters = string.Join(", ", values.Select(x => "@" + x.Name));
        var sql = $"INSERT INTO blumebee.{table} ({columns}) VALUES ({parameters}) RETURNING id";
        var dbParams = values.Select(x => new NpgsqlParameter("@" + x.Name, x.Value ?? DBNull.Value)).ToArray();
        var result = _db.ExecuteScalar(sql, dbParams);
        return Convert.ToInt64(result);
    }

    public bool Update<TDto>(string table, long id, TDto dto)
    {
        ValidateTable(table);
        var values = GetProperties(dto).ToList();
        if (values.Count == 0) throw new ArgumentException("No updatable fields were supplied.");
        var assignments = string.Join(", ", values.Select(x => $"{Quote(SnakeCase(x.Name))} = @{x.Name}"));
        var sql = $"UPDATE blumebee.{table} SET {assignments} WHERE id = @__id";
        var dbParams = values.Select(x => new NpgsqlParameter("@" + x.Name, x.Value ?? DBNull.Value)).ToList();
        dbParams.Add(new NpgsqlParameter("@__id", id));
        return _db.ExecuteNonQuery(sql, dbParams.ToArray()) > 0;
    }

    public bool Delete(string table, long id)
    {
        ValidateTable(table);
        return _db.ExecuteNonQuery($"DELETE FROM blumebee.{table} WHERE id = @id", new[] { new NpgsqlParameter("id", id) }) > 0;
    }

    private static void ValidateTable(string table)
    {
        if (!AllowedTables.Contains(table)) throw new ArgumentOutOfRangeException(nameof(table), "This module is not enabled for generic CRUD.");
    }

    private static List<(string Name, object? Value)> GetProperties<T>(T dto) => typeof(T).GetProperties(BindingFlags.Instance | BindingFlags.Public)
        .Where(p => p.CanRead && p.GetIndexParameters().Length == 0)
        .Select(p => (p.Name, p.GetValue(dto)))
        .ToList();

    private static string SnakeCase(string value) => Regex.Replace(value, "(?<!^)([A-Z])", "_$1").ToLowerInvariant();
    private static string Quote(string value) => "\"" + value.Replace("\"", "\"\"") + "\"";

    private static IReadOnlyList<TResponse> MapRows<TResponse>(DataTable table) where TResponse : class, new()
    {
        var result = new List<TResponse>();
        foreach (DataRow row in table.Rows)
        {
            var item = new TResponse();
            foreach (DataColumn column in table.Columns)
            {
                if (row.IsNull(column)) continue;
                var propertyName = string.Concat(column.ColumnName.Split('_').Select(part => part.Length == 0 ? part : char.ToUpperInvariant(part[0]) + part[1..]));
                var property = typeof(TResponse).GetProperty(propertyName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.IgnoreCase);
                if (property is null || !property.CanWrite) continue;
                var value = row[column];
                var targetType = Nullable.GetUnderlyingType(property.PropertyType) ?? property.PropertyType;
                try
                {
                    if (targetType == typeof(DateOnly))
                        value = value is DateTime dt ? DateOnly.FromDateTime(dt) : DateOnly.Parse(Convert.ToString(value)!);
                    else if (targetType == typeof(TimeOnly))
                        value = value is TimeSpan ts ? TimeOnly.FromTimeSpan(ts) : TimeOnly.Parse(Convert.ToString(value)!);
                    else if (!targetType.IsInstanceOfType(value))
                        value = Convert.ChangeType(value, targetType);
                    property.SetValue(item, value);
                }
                catch (Exception ex) when (ex is InvalidCastException or FormatException or OverflowException or ArgumentException)
                {
                    throw new InvalidOperationException($"Could not map database column '{column.ColumnName}' to response property '{property.Name}'.", ex);
                }
            }
            result.Add(item);
        }
        return result;
    }
}
