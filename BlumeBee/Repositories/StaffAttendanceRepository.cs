using BlumeBee.Data;
using BlumeBee.IRepository;
using BlumeBee.Model;
using BlumeBee.ModelDTO;
using Npgsql;
using System.Data;

namespace BlumeBee.Repositories
{
    public class StaffAttendanceRepository : IStaffAttendanceRepository
    {
        private readonly PostgresDbHelper _db;

        public StaffAttendanceRepository(PostgresDbHelper db)
        {
            _db = db;
        }

        // 🔹 GET ALL
        public List<StaffAttendanceModel> GetAll()
        {
            var dt = _db.ExecuteQuery(
                "SELECT * FROM blumebee.staff_attendance ORDER BY id DESC");

            var list = new List<StaffAttendanceModel>();

            foreach (DataRow row in dt.Rows)
            {
                list.Add(Map(row));
            }

            return list;
        }

        // 🔹 GET BY ID
        public StaffAttendanceModel? GetById(long id)
        {
            var dt = _db.ExecuteQuery(
                "SELECT * FROM blumebee.staff_attendance WHERE id = @id",
                new[]
                {
                    new NpgsqlParameter("@id", id)
                });

            if (dt.Rows.Count == 0)
                return null;

            return Map(dt.Rows[0]);
        }

        // 🔹 INSERT
        public long Insert(StaffAttendanceModelDTO model)
        {
            var sql = @"
                INSERT INTO blumebee.staff_attendance
                (
                    attendance_date,
                    staff_id,
                    attendance_code_id,
                    leave_type_id,
                    remarks
                )
                VALUES
                (
                    @attendance_date,
                    @staff_id,
                    @attendance_code_id,
                    @leave_type_id,
                    @remarks
                )
                RETURNING id;
            ";

            var result = _db.ExecuteScalar(sql, new[]
            {
                new NpgsqlParameter("@attendance_date", model.AttendanceDate),
                new NpgsqlParameter("@staff_id", model.StaffId),
                new NpgsqlParameter("@attendance_code_id", (object?)model.AttendanceCodeId ?? DBNull.Value),
                new NpgsqlParameter("@leave_type_id", (object?)model.LeaveTypeId ?? DBNull.Value),
                new NpgsqlParameter("@remarks", (object?)model.Remarks ?? DBNull.Value)
            });

            return Convert.ToInt64(result);
        }

        // 🔹 UPDATE
        public bool Update(long id, StaffAttendanceModelDTO model)
        {
            var sql = @"
                UPDATE blumebee.staff_attendance
                SET
                    attendance_date = @attendance_date,
                    staff_id = @staff_id,
                    attendance_code_id = @attendance_code_id,
                    leave_type_id = @leave_type_id,
                    remarks = @remarks
                WHERE id = @id;
            ";

            var affected = _db.ExecuteNonQuery(sql, new[]
            {
                new NpgsqlParameter("@attendance_date", model.AttendanceDate),
                new NpgsqlParameter("@staff_id", model.StaffId),
                new NpgsqlParameter("@attendance_code_id", (object?)model.AttendanceCodeId ?? DBNull.Value),
                new NpgsqlParameter("@leave_type_id", (object?)model.LeaveTypeId ?? DBNull.Value),
                new NpgsqlParameter("@remarks", (object?)model.Remarks ?? DBNull.Value),
                new NpgsqlParameter("@id", id)
            });

            return affected > 0;
        }

        // 🔹 DELETE
        public bool Delete(long id)
        {
            var affected = _db.ExecuteNonQuery(
                "DELETE FROM blumebee.staff_attendance WHERE id = @id",
                new[]
                {
                    new NpgsqlParameter("@id", id)
                });

            return affected > 0;
        }

        // 🔹 MAPPING
        private StaffAttendanceModel Map(DataRow row)
        {
            return new StaffAttendanceModel
            {
                Id = Convert.ToInt64(row["id"]),

                AttendanceDate = Convert.ToDateTime(row["attendance_date"]),

                StaffId = Convert.ToInt64(row["staff_id"]),

                AttendanceCodeId = row["attendance_code_id"] == DBNull.Value
                    ? null
                    : Convert.ToInt32(row["attendance_code_id"]),

                LeaveTypeId = row["leave_type_id"] == DBNull.Value
                    ? null
                    : Convert.ToInt32(row["leave_type_id"]),

                Remarks = row["remarks"] == DBNull.Value
                    ? null
                    : row["remarks"].ToString()
            };
        }
    }
}
