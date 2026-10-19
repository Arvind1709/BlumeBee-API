using System.Data;
using BlumeBee.Data;
using Microsoft.AspNetCore.Mvc;

namespace BlumeBee.Controllers;

[ApiController]
[Route("api/[controller]")]
public sealed class ReportsController : ControllerBase
{
    private readonly PostgresDbHelper _db;
    public ReportsController(PostgresDbHelper db) => _db = db;

    [HttpGet("dashboard")]
    public IActionResult Dashboard() => Ok(QueryOne(@"SELECT
      (SELECT COUNT(*) FROM blumebee.lead) AS total_leads,
      (SELECT COUNT(*) FROM blumebee.admission WHERE admission_date IS NOT NULL) AS total_admissions,
      (SELECT COUNT(*) FROM blumebee.student s JOIN blumebee.master_student_status ss ON ss.id=s.student_status_id WHERE ss.code='ACTIVE') AS active_students,
      (SELECT COALESCE(SUM(balance_pending),0) FROM blumebee.student_bill WHERE balance_pending>0) AS pending_fees,
      (SELECT COUNT(*) FROM blumebee.incident_report WHERE closure_status IS NULL OR closure_status <> 'Closed') AS open_incidents,
      (SELECT COUNT(*) FROM blumebee.parent_communication WHERE follow_up_date IS NOT NULL AND closure_date IS NULL) AS parent_followups_pending"));

    [HttpGet("active-students")]
    public IActionResult ActiveStudents() => Ok(Query(@"SELECT * FROM blumebee.v_active_students ORDER BY full_name"));

    [HttpGet("fee-ageing")]
    public IActionResult FeeAgeing() => Ok(Query(@"SELECT * FROM blumebee.v_fee_ageing ORDER BY overdue_days DESC"));

    [HttpGet("admissions-funnel")]
    public IActionResult AdmissionsFunnel() => Ok(Query(@"SELECT * FROM blumebee.v_admissions_funnel ORDER BY pipeline_stage"));

    [HttpGet("class-wise-students")]
    public IActionResult ClassWiseStudents() => Ok(Query(@"SELECT mc.name AS class_name, COUNT(a.student_id) AS student_count
      FROM blumebee.admission a JOIN blumebee.master_class mc ON mc.id=a.class_id
      WHERE a.student_id IS NOT NULL GROUP BY mc.name ORDER BY mc.name"));

    [HttpGet("monthly-leads-admissions")]
    public IActionResult MonthlyLeadsAdmissions() => Ok(Query(@"SELECT DATE_TRUNC('month', l.inquiry_date)::date AS month,
      COUNT(DISTINCT l.id) AS total_leads, COUNT(DISTINCT a.id) AS total_admissions
      FROM blumebee.lead l LEFT JOIN blumebee.admission a ON a.lead_id=l.id
      GROUP BY 1 ORDER BY 1"));

    [HttpGet("fee-collection-trend")]
    public IActionResult FeeCollectionTrend() => Ok(Query(@"SELECT DATE_TRUNC('month', fee_month)::date AS month, SUM(amount_paid) AS total_collected
      FROM blumebee.student_bill GROUP BY 1 ORDER BY 1"));

    [HttpGet("attendance-percentage")]
    public IActionResult AttendancePercentage() => Ok(QueryOne(@"SELECT ROUND(100.0 * SUM(CASE WHEN mac.code='P' THEN 1 ELSE 0 END) / NULLIF(COUNT(*),0),2) AS attendance_percent
      FROM blumebee.student_attendance sa JOIN blumebee.master_attendance_code mac ON mac.id=sa.attendance_code_id"));

    private object Query(string sql)
    {
        var table = _db.ExecuteQuery(sql);
        return ToRows(table);
    }
    private object QueryOne(string sql) => ToRows(_db.ExecuteQuery(sql)).FirstOrDefault() ?? new Dictionary<string, object?>();
    private static IReadOnlyList<Dictionary<string, object?>> ToRows(DataTable table)
    {
        var rows = new List<Dictionary<string, object?>>();
        foreach (DataRow row in table.Rows)
        {
            var item = new Dictionary<string, object?>(StringComparer.OrdinalIgnoreCase);
            foreach (DataColumn col in table.Columns) item[col.ColumnName] = row.IsNull(col) ? null : row[col];
            rows.Add(item);
        }
        return rows;
    }
}
