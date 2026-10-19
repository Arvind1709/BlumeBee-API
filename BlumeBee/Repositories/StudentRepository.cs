using BlumeBee.Data;
using BlumeBee.IRepository;
using BlumeBee.Model;
using BlumeBee.ModelDTO;
using Npgsql;
using System.Data;

namespace BlumeBee.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        //private readonly PostgresDbHelper _db;

        //public StudentRepository(PostgresDbHelper db)
        //{
        //    _db = db;
        //}

        ////public DataTable GetAllStudents()
        ////{
        ////    string query = "SELECT * FROM blumebee.student;";
        ////    return _db.ExecuteQuery(query);
        ////}

        //public List<StudentModel> GetAllStudents()
        //{
        //    string query = "SELECT * FROM blumebee.student;";
        //    DataTable dt = _db.ExecuteQuery(query);

        //    var students = new List<StudentModel>();

        //    foreach (DataRow row in dt.Rows)
        //    {
        //        students.Add(new StudentModel
        //        {
        //            Id = Convert.ToInt64(row["id"]),
        //            StudentCode = row["student_code"]?.ToString(),
        //            CenterId = row["center_id"] == DBNull.Value ? null : Convert.ToInt32(row["center_id"]),
        //            FirstName = row["first_name"]?.ToString(),
        //            LastName = row["last_name"]?.ToString(),
        //            FullName = row["full_name"]?.ToString(),
        //            GenderId = row["gender_id"] == DBNull.Value ? null : Convert.ToInt32(row["gender_id"]),
        //            Dob = Convert.ToDateTime(row["dob"]),
        //            BloodGroup = row["blood_group"]?.ToString(),
        //            Allergies = row["allergies"]?.ToString(),
        //            MedicalNotes = row["medical_notes"]?.ToString(),
        //            SpecialSupportNotes = row["special_support_notes"]?.ToString(),
        //            AddressLine1 = row["address_line1"]?.ToString(),
        //            AddressLine2 = row["address_line2"]?.ToString(),
        //            City = row["city"]?.ToString(),
        //            State = row["state"]?.ToString(),
        //            Pincode = row["pincode"]?.ToString(),
        //            AadhaarRef = row["aadhaar_ref"]?.ToString(),
        //            StudentStatusId = row["student_status_id"] == DBNull.Value ? null : Convert.ToInt32(row["student_status_id"]),
        //            Remarks = row["remarks"]?.ToString(),
        //            CreatedAt = Convert.ToDateTime(row["created_at"]),
        //            UpdatedAt = Convert.ToDateTime(row["updated_at"])
        //        });
        //    }

        //    return students;
        //}

        //public int AddStudent(string name)
        //{
        //    string query = "INSERT INTO blumebee.student(name) VALUES(@name)";

        //    var parameters = new[]
        //    {
        //        new NpgsqlParameter("@name", name)
        //    };

        //    return _db.ExecuteNonQuery(query, parameters);
        //}

        private readonly PostgresDbHelper _db;

        public StudentRepository(PostgresDbHelper db)
        {
            _db = db;
        }

        // GET: All students
        public List<StudentModel> GetAllStudents()
        {
            const string query = @"SELECT c.name as CenterName,* FROM blumebee.student s 
                                    inner join blumebee.center c on s.center_id = c.id
                                    ORDER BY s.id DESC;";




            DataTable dt = _db.ExecuteQuery(query);

            return MapStudents(dt);
        }

        // GET: Student by ID
        public StudentModel? GetStudentById(long id)
        {
            const string query = @"
                SELECT *
                FROM blumebee.student
                WHERE id = @id;";

            var parameters = new[]
            {
                new NpgsqlParameter("@id", id)
            };

            DataTable dt = _db.ExecuteQuery(query, parameters);

            var students = MapStudents(dt);

            return students.FirstOrDefault();
        }

        // POST: Add student
        public int AddStudent(StudentCreateDto student)
        {
            const string query = @"
                INSERT INTO blumebee.student
                (
                    student_code,
                    center_id,
                    first_name,
                    last_name,
                    full_name,
                    gender_id,
                    dob,
                    blood_group,
                    allergies,
                    medical_notes,
                    special_support_notes,
                    address_line1,
                    address_line2,
                    city,
                    state,
                    pincode,
                    aadhaar_ref,
                    student_status_id,
                    remarks
                )
                VALUES
                (
                    @student_code,
                    @center_id,
                    @first_name,
                    @last_name,
                    @full_name,
                    @gender_id,
                    @dob,
                    @blood_group,
                    @allergies,
                    @medical_notes,
                    @special_support_notes,
                    @address_line1,
                    @address_line2,
                    @city,
                    @state,
                    @pincode,
                    @aadhaar_ref,
                    @student_status_id,
                    @remarks
                );";

            var parameters = GetStudentParameters(student);

            return _db.ExecuteNonQuery(query, parameters);
        }

        // PUT: Update student
        public int UpdateStudent(long id, StudentUpdateDto student)
        {
            const string query = @"
                UPDATE blumebee.student
                SET
                    student_code = @student_code,
                    center_id = @center_id,
                    first_name = @first_name,
                    last_name = @last_name,
                    full_name = @full_name,
                    gender_id = @gender_id,
                    dob = @dob,
                    blood_group = @blood_group,
                    allergies = @allergies,
                    medical_notes = @medical_notes,
                    special_support_notes = @special_support_notes,
                    address_line1 = @address_line1,
                    address_line2 = @address_line2,
                    city = @city,
                    state = @state,
                    pincode = @pincode,
                    aadhaar_ref = @aadhaar_ref,
                    student_status_id = @student_status_id,
                    remarks = @remarks,
                    updated_at = NOW()
                WHERE id = @id;";

            var parameters = GetStudentParameters(student)
                .Concat(new[]
                {
                    new NpgsqlParameter("@id", id)
                })
                .ToArray();

            return _db.ExecuteNonQuery(query, parameters);
        }

        // DELETE: Delete student
        public int DeleteStudent(long id)
        {
            const string query = @"
                DELETE FROM blumebee.student
                WHERE id = @id;";

            var parameters = new[]
            {
                new NpgsqlParameter("@id", id)
            };

            return _db.ExecuteNonQuery(query, parameters);
        }

        // Shared parameter mapping for INSERT and UPDATE
        private static NpgsqlParameter[] GetStudentParameters(
            StudentCreateDto student)
        {
            return new[]
            {
                new NpgsqlParameter("@student_code", student.StudentCode),
                new NpgsqlParameter("@center_id",
                    (object?)student.CenterId ?? DBNull.Value),
                new NpgsqlParameter("@first_name", student.FirstName),
                new NpgsqlParameter("@last_name",
                    (object?)student.LastName ?? DBNull.Value),
                new NpgsqlParameter("@full_name", student.FullName),
                new NpgsqlParameter("@gender_id",
                    (object?)student.GenderId ?? DBNull.Value),
                new NpgsqlParameter("@dob", student.Dob.Date),
                new NpgsqlParameter("@blood_group",
                    (object?)student.BloodGroup ?? DBNull.Value),
                new NpgsqlParameter("@allergies",
                    (object?)student.Allergies ?? DBNull.Value),
                new NpgsqlParameter("@medical_notes",
                    (object?)student.MedicalNotes ?? DBNull.Value),
                new NpgsqlParameter("@special_support_notes",
                    (object?)student.SpecialSupportNotes ?? DBNull.Value),
                new NpgsqlParameter("@address_line1",
                    (object?)student.AddressLine1 ?? DBNull.Value),
                new NpgsqlParameter("@address_line2",
                    (object?)student.AddressLine2 ?? DBNull.Value),
                new NpgsqlParameter("@city",
                    (object?)student.City ?? DBNull.Value),
                new NpgsqlParameter("@state",
                    (object?)student.State ?? DBNull.Value),
                new NpgsqlParameter("@pincode",
                    (object?)student.Pincode ?? DBNull.Value),
                new NpgsqlParameter("@aadhaar_ref",
                    (object?)student.AadhaarRef ?? DBNull.Value),
                new NpgsqlParameter("@student_status_id",
                    (object?)student.StudentStatusId ?? DBNull.Value),
                new NpgsqlParameter("@remarks",
                    (object?)student.Remarks ?? DBNull.Value)
            };
        }

        // Convert DataTable rows to StudentModel objects
        private static List<StudentModel> MapStudents(DataTable dt)
        {
            var students = new List<StudentModel>();

            foreach (DataRow row in dt.Rows)
            {
                students.Add(new StudentModel
                {
                    Id = Convert.ToInt64(row["id"]),
                    CenterName = Convert.ToString(row["CenterName"])!,
                    StudentCode = Convert.ToString(row["student_code"])!,
                    CenterId = GetNullableInt(row, "center_id"),
                    FirstName = Convert.ToString(row["first_name"])!,
                    LastName = GetNullableString(row, "last_name"),
                    FullName = Convert.ToString(row["full_name"])!,
                    GenderId = GetNullableInt(row, "gender_id"),
                    Dob = Convert.ToDateTime(row["dob"]),
                    BloodGroup = GetNullableString(row, "blood_group"),
                    Allergies = GetNullableString(row, "allergies"),
                    MedicalNotes = GetNullableString(row, "medical_notes"),
                    SpecialSupportNotes =
                        GetNullableString(row, "special_support_notes"),
                    AddressLine1 = GetNullableString(row, "address_line1"),
                    AddressLine2 = GetNullableString(row, "address_line2"),
                    City = GetNullableString(row, "city"),
                    State = GetNullableString(row, "state"),
                    Pincode = GetNullableString(row, "pincode"),
                    AadhaarRef = GetNullableString(row, "aadhaar_ref"),
                    StudentStatusId = GetNullableInt(row, "student_status_id"),
                    Remarks = GetNullableString(row, "remarks"),
                    CreatedAt = Convert.ToDateTime(row["created_at"]),
                    UpdatedAt = Convert.ToDateTime(row["updated_at"])
                });
            }

            return students;
        }

        private static int? GetNullableInt(DataRow row, string column)
        {
            return row[column] == DBNull.Value
                ? null
                : Convert.ToInt32(row[column]);
        }

        private static string? GetNullableString(
            DataRow row, string column)
        {
            return row[column] == DBNull.Value
                ? null
                : Convert.ToString(row[column]);
        }
    }
}
