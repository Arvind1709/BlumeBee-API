using BlumeBee.Data;
using BlumeBee.IRepository;
using BlumeBee.Model;
using BlumeBee.ModelDTO;
using Npgsql;
using System.Data;

namespace BlumeBee.Repositories
{
    public class StaffRepository : IStaffRepository
    {
        private readonly PostgresDbHelper _db;

        public StaffRepository(PostgresDbHelper db)
        {
            _db = db;
        }

        // 🔹 GET ALL
        public List<StaffModel> GetAll()
        {
            var dt = _db.ExecuteQuery(
                "SELECT * FROM blumebee.staff ORDER BY id DESC");

            var list = new List<StaffModel>();

            foreach (DataRow row in dt.Rows)
            {
                list.Add(Map(row));
            }

            return list;
        }

        // 🔹 GET BY ID
        public StaffModel? GetById(long id)
        {
            var dt = _db.ExecuteQuery(
                "SELECT * FROM blumebee.staff WHERE id = @id",
                new[]
                {
                    new NpgsqlParameter("@id", id)
                });

            if (dt.Rows.Count == 0)
                return null;

            return Map(dt.Rows[0]);
        }

        // 🔹 INSERT
        public long Insert(StaffModelDTO model)
        {
            var sql = @"
                INSERT INTO blumebee.staff
                (
                    employee_code,
                    center_id,
                    full_name,
                    gender_id,
                    role_id,
                    department_id,
                    joining_date,
                    qualification,
                    experience_years,
                    contact_number,
                    email,
                    address_line1,
                    city,
                    state,
                    pincode,
                    salary,
                    bank_details,
                    aadhaar_ref,
                    emergency_contact,
                    employment_status,
                    probation_end_date,
                    remarks
                )
                VALUES
                (
                    @employee_code,
                    @center_id,
                    @full_name,
                    @gender_id,
                    @role_id,
                    @department_id,
                    @joining_date,
                    @qualification,
                    @experience_years,
                    @contact_number,
                    @email,
                    @address_line1,
                    @city,
                    @state,
                    @pincode,
                    @salary,
                    @bank_details,
                    @aadhaar_ref,
                    @emergency_contact,
                    @employment_status,
                    @probation_end_date,
                    @remarks
                )
                RETURNING id;
            ";

            var result = _db.ExecuteScalar(sql, new[]
            {
                new NpgsqlParameter("@employee_code", model.EmployeeCode),
                new NpgsqlParameter("@center_id", (object?)model.CenterId ?? DBNull.Value),
                new NpgsqlParameter("@full_name", model.FullName),
                new NpgsqlParameter("@gender_id", (object?)model.GenderId ?? DBNull.Value),
                new NpgsqlParameter("@role_id", (object?)model.RoleId ?? DBNull.Value),
                new NpgsqlParameter("@department_id", (object?)model.DepartmentId ?? DBNull.Value),
                new NpgsqlParameter("@joining_date", (object?)model.JoiningDate ?? DBNull.Value),
                new NpgsqlParameter("@qualification", (object?)model.Qualification ?? DBNull.Value),
                new NpgsqlParameter("@experience_years", (object?)model.ExperienceYears ?? DBNull.Value),
                new NpgsqlParameter("@contact_number", (object?)model.ContactNumber ?? DBNull.Value),
                new NpgsqlParameter("@email", (object?)model.Email ?? DBNull.Value),
                new NpgsqlParameter("@address_line1", (object?)model.AddressLine1 ?? DBNull.Value),
                new NpgsqlParameter("@city", (object?)model.City ?? DBNull.Value),
                new NpgsqlParameter("@state", (object?)model.State ?? DBNull.Value),
                new NpgsqlParameter("@pincode", (object?)model.Pincode ?? DBNull.Value),
                new NpgsqlParameter("@salary", (object?)model.Salary ?? DBNull.Value),
                new NpgsqlParameter("@bank_details", (object?)model.BankDetails ?? DBNull.Value),
                new NpgsqlParameter("@aadhaar_ref", (object?)model.AadhaarRef ?? DBNull.Value),
                new NpgsqlParameter("@emergency_contact", (object?)model.EmergencyContact ?? DBNull.Value),
                new NpgsqlParameter("@employment_status", (object?)model.EmploymentStatus ?? DBNull.Value),
                new NpgsqlParameter("@probation_end_date", (object?)model.ProbationEndDate ?? DBNull.Value),
                new NpgsqlParameter("@remarks", (object?)model.Remarks ?? DBNull.Value)
            });

            return Convert.ToInt64(result);
        }

        // 🔹 UPDATE
        public bool Update(long id, StaffModelDTO model)
        {
            var sql = @"
                UPDATE blumebee.staff
                SET
                    employee_code = @employee_code,
                    center_id = @center_id,
                    full_name = @full_name,
                    gender_id = @gender_id,
                    role_id = @role_id,
                    department_id = @department_id,
                    joining_date = @joining_date,
                    qualification = @qualification,
                    experience_years = @experience_years,
                    contact_number = @contact_number,
                    email = @email,
                    address_line1 = @address_line1,
                    city = @city,
                    state = @state,
                    pincode = @pincode,
                    salary = @salary,
                    bank_details = @bank_details,
                    aadhaar_ref = @aadhaar_ref,
                    emergency_contact = @emergency_contact,
                    employment_status = @employment_status,
                    probation_end_date = @probation_end_date,
                    remarks = @remarks
                WHERE id = @id;
            ";

            var affected = _db.ExecuteNonQuery(sql, new[]
            {
                new NpgsqlParameter("@employee_code", model.EmployeeCode),
                new NpgsqlParameter("@center_id", (object?)model.CenterId ?? DBNull.Value),
                new NpgsqlParameter("@full_name", model.FullName),
                new NpgsqlParameter("@gender_id", (object?)model.GenderId ?? DBNull.Value),
                new NpgsqlParameter("@role_id", (object?)model.RoleId ?? DBNull.Value),
                new NpgsqlParameter("@department_id", (object?)model.DepartmentId ?? DBNull.Value),
                new NpgsqlParameter("@joining_date", (object?)model.JoiningDate ?? DBNull.Value),
                new NpgsqlParameter("@qualification", (object?)model.Qualification ?? DBNull.Value),
                new NpgsqlParameter("@experience_years", (object?)model.ExperienceYears ?? DBNull.Value),
                new NpgsqlParameter("@contact_number", (object?)model.ContactNumber ?? DBNull.Value),
                new NpgsqlParameter("@email", (object?)model.Email ?? DBNull.Value),
                new NpgsqlParameter("@address_line1", (object?)model.AddressLine1 ?? DBNull.Value),
                new NpgsqlParameter("@city", (object?)model.City ?? DBNull.Value),
                new NpgsqlParameter("@state", (object?)model.State ?? DBNull.Value),
                new NpgsqlParameter("@pincode", (object?)model.Pincode ?? DBNull.Value),
                new NpgsqlParameter("@salary", (object?)model.Salary ?? DBNull.Value),
                new NpgsqlParameter("@bank_details", (object?)model.BankDetails ?? DBNull.Value),
                new NpgsqlParameter("@aadhaar_ref", (object?)model.AadhaarRef ?? DBNull.Value),
                new NpgsqlParameter("@emergency_contact", (object?)model.EmergencyContact ?? DBNull.Value),
                new NpgsqlParameter("@employment_status", (object?)model.EmploymentStatus ?? DBNull.Value),
                new NpgsqlParameter("@probation_end_date", (object?)model.ProbationEndDate ?? DBNull.Value),
                new NpgsqlParameter("@remarks", (object?)model.Remarks ?? DBNull.Value),
                new NpgsqlParameter("@id", id)
            });

            return affected > 0;
        }

        // 🔹 DELETE
        public bool Delete(long id)
        {
            var affected = _db.ExecuteNonQuery(
                "DELETE FROM blumebee.staff WHERE id = @id",
                new[]
                {
                    new NpgsqlParameter("@id", id)
                });

            return affected > 0;
        }

        // 🔹 MAPPING
        private StaffModel Map(DataRow row)
        {
            return new StaffModel
            {
                Id = Convert.ToInt64(row["id"]),
                EmployeeCode = row["employee_code"].ToString(),
                CenterId = row["center_id"] == DBNull.Value ? null : Convert.ToInt32(row["center_id"]),
                FullName = row["full_name"].ToString(),
                GenderId = row["gender_id"] == DBNull.Value ? null : Convert.ToInt32(row["gender_id"]),
                RoleId = row["role_id"] == DBNull.Value ? null : Convert.ToInt32(row["role_id"]),
                DepartmentId = row["department_id"] == DBNull.Value ? null : Convert.ToInt32(row["department_id"]),
                JoiningDate = row["joining_date"] == DBNull.Value ? null : Convert.ToDateTime(row["joining_date"]),
                Qualification = row["qualification"] == DBNull.Value ? null : row["qualification"].ToString(),
                ExperienceYears = row["experience_years"] == DBNull.Value ? null : Convert.ToDecimal(row["experience_years"]),
                ContactNumber = row["contact_number"] == DBNull.Value ? null : row["contact_number"].ToString(),
                Email = row["email"] == DBNull.Value ? null : row["email"].ToString(),
                AddressLine1 = row["address_line1"] == DBNull.Value ? null : row["address_line1"].ToString(),
                City = row["city"] == DBNull.Value ? null : row["city"].ToString(),
                State = row["state"] == DBNull.Value ? null : row["state"].ToString(),
                Pincode = row["pincode"] == DBNull.Value ? null : row["pincode"].ToString(),
                Salary = row["salary"] == DBNull.Value ? null : Convert.ToDecimal(row["salary"]),
                BankDetails = row["bank_details"] == DBNull.Value ? null : row["bank_details"].ToString(),
                AadhaarRef = row["aadhaar_ref"] == DBNull.Value ? null : row["aadhaar_ref"].ToString(),
                EmergencyContact = row["emergency_contact"] == DBNull.Value ? null : row["emergency_contact"].ToString(),
                EmploymentStatus = row["employment_status"] == DBNull.Value ? null : row["employment_status"].ToString(),
                ProbationEndDate = row["probation_end_date"] == DBNull.Value ? null : Convert.ToDateTime(row["probation_end_date"]),
                Remarks = row["remarks"] == DBNull.Value ? null : row["remarks"].ToString(),
                CreatedAt = Convert.ToDateTime(row["created_at"])
            };
        }
    }
}
