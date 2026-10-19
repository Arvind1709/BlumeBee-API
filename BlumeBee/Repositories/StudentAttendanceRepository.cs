using BlumeBee.Data;
using BlumeBee.IRepository;
using BlumeBee.Model;
using BlumeBee.ModelDTO;
using Npgsql;
using System.Data;

namespace BlumeBee.Repositories
{
    public class StudentAttendanceRepository : IStudentAttendanceRepository
    {
        private readonly PostgresDbHelper _db;

        public StudentAttendanceRepository(PostgresDbHelper db)
        {
            _db = db;
        }

        // 🔹 GET ALL
        public List<StudentAttendanceModel> GetAll()
        {
            var dt = _db.ExecuteQuery(
                "SELECT * FROM blumebee.student_attendance ORDER BY id DESC");

            var list = new List<StudentAttendanceModel>();

            foreach (DataRow row in dt.Rows)
            {
                list.Add(Map(row));
            }

            return list;
        }

        // 🔹 GET BY ID
        public StudentAttendanceModel? GetById(long id)
        {
            var dt = _db.ExecuteQuery(
                "SELECT * FROM blumebee.student_attendance WHERE id = @id",
                new[]
                {
                    new NpgsqlParameter("@id", id)
                });

            if (dt.Rows.Count == 0)
                return null;

            return Map(dt.Rows[0]);
        }

        // 🔹 INSERT
        public long Insert(StudentAttendanceModelDTO model)
        {
            var sql = @"
                INSERT INTO blumebee.student_attendance
                (
                    attendance_date,
                    student_id,
                    class_id,
                    attendance_code_id,
                    remarks
                )
                VALUES
                (
                    @attendance_date,
                    @student_id,
                    @class_id,
                    @attendance_code_id,
                    @remarks
                )
                RETURNING id;
            ";

            var result = _db.ExecuteScalar(sql, new[]
            {
                new NpgsqlParameter("@attendance_date", model.AttendanceDate),
                new NpgsqlParameter("@student_id", model.StudentId),
                new NpgsqlParameter("@class_id", (object?)model.ClassId ?? DBNull.Value),
                new NpgsqlParameter("@attendance_code_id", (object?)model.AttendanceCodeId ?? DBNull.Value),
                new NpgsqlParameter("@remarks", (object?)model.Remarks ?? DBNull.Value)
            });

            return Convert.ToInt64(result);
        }

        // 🔹 UPDATE
        public bool Update(long id, StudentAttendanceModelDTO model)
        {
            var sql = @"
                UPDATE blumebee.student_attendance
                SET
                    attendance_date = @attendance_date,
                    student_id = @student_id,
                    class_id = @class_id,
                    attendance_code_id = @attendance_code_id,
                    remarks = @remarks
                WHERE id = @id;
            ";

            var affected = _db.ExecuteNonQuery(sql, new[]
            {
                new NpgsqlParameter("@attendance_date", model.AttendanceDate),
                new NpgsqlParameter("@student_id", model.StudentId),
                new NpgsqlParameter("@class_id", (object?)model.ClassId ?? DBNull.Value),
                new NpgsqlParameter("@attendance_code_id", (object?)model.AttendanceCodeId ?? DBNull.Value),
                new NpgsqlParameter("@remarks", (object?)model.Remarks ?? DBNull.Value),
                new NpgsqlParameter("@id", id)
            });

            return affected > 0;
        }

        // 🔹 DELETE
        public bool Delete(long id)
        {
            var affected = _db.ExecuteNonQuery(
                "DELETE FROM blumebee.student_attendance WHERE id = @id",
                new[]
                {
                    new NpgsqlParameter("@id", id)
                });

            return affected > 0;
        }

        // 🔹 MAPPING
        private StudentAttendanceModel Map(DataRow row)
        {
            return new StudentAttendanceModel
            {
                Id = Convert.ToInt64(row["id"]),
                AttendanceDate = Convert.ToDateTime(row["attendance_date"]),
                StudentId = Convert.ToInt64(row["student_id"]),

                ClassId = row["class_id"] == DBNull.Value
                    ? null
                    : Convert.ToInt32(row["class_id"]),

                AttendanceCodeId = row["attendance_code_id"] == DBNull.Value
                    ? null
                    : Convert.ToInt32(row["attendance_code_id"]),

                Remarks = row["remarks"] == DBNull.Value
                    ? null
                    : row["remarks"].ToString()
            };
        }
    }
}
