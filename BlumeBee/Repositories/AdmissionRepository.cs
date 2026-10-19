using BlumeBee.Data;
using BlumeBee.IRepository;
using BlumeBee.Model;
using Npgsql;
using System.Data;

namespace BlumeBee.Repositories
{
    public class AdmissionRepository : IAdmissionRepository
    {
        private readonly PostgresDbHelper _db;

        public AdmissionRepository(PostgresDbHelper db)
        {
            _db = db;
        }

        public Task<List<AdmissionModel>> GetAllAsync()
        {
            string query = @"SELECT * FROM blumebee.admission ORDER BY id DESC";

            DataTable dt = _db.ExecuteQuery(query);

            var list = dt.AsEnumerable().Select(row => new AdmissionModel
            {
                Id = Convert.ToInt64(row["id"]),
                AdmissionCode = row["admission_code"].ToString(),
                StudentId = row["student_id"] == DBNull.Value ? null : Convert.ToInt64(row["student_id"]),
                AdmissionDate = row["admission_date"] == DBNull.Value ? null : Convert.ToDateTime(row["admission_date"]),
                MonthlyFee = row["monthly_fee"] == DBNull.Value ? null : Convert.ToDecimal(row["monthly_fee"]),
                AdmissionStatus = row["admission_status"]?.ToString()
            }).ToList();

            return Task.FromResult(list);
        }

        public Task<AdmissionModel> GetByIdAsync(long id)
        {
            string query = @"SELECT * FROM blumebee.admission WHERE id=@id";

            var param = new[]
            {
                new NpgsqlParameter("@id", id)
            };

            DataTable dt = _db.ExecuteQuery(query, param);

            var data = dt.AsEnumerable().Select(row => new AdmissionModel
            {
                Id = Convert.ToInt64(row["id"]),
                AdmissionCode = row["admission_code"].ToString(),
                LeadId = row["lead_id"] == DBNull.Value ? null : Convert.ToInt64(row["lead_id"]),
                StudentId = row["student_id"] == DBNull.Value ? null : Convert.ToInt64(row["student_id"]),
                AdmissionDate = row["admission_date"] == DBNull.Value ? null : Convert.ToDateTime(row["admission_date"]),
                Remarks = row["remarks"]?.ToString()
            }).FirstOrDefault();

            return Task.FromResult(data);
        }

        public Task<int> CreateAsync(AdmissionModel model)
        {
            string query = @"INSERT INTO blumebee.admission
            (admission_code, lead_id, student_id, admission_date, program_id, class_id,
             monthly_fee, admission_fee, discount_amount, payment_status_id, admission_status, remarks)
            VALUES
            (@code, @leadId, @studentId, @admissionDate, @programId, @classId,
             @monthlyFee, @admissionFee, @discount, @paymentStatus, @status, @remarks)";

            var parameters = new[]
            {
                new NpgsqlParameter("@code", model.AdmissionCode),
                new NpgsqlParameter("@leadId", (object?)model.LeadId ?? DBNull.Value),
                new NpgsqlParameter("@studentId", (object?)model.StudentId ?? DBNull.Value),
                new NpgsqlParameter("@admissionDate", (object?)model.AdmissionDate ?? DBNull.Value),
                new NpgsqlParameter("@programId", (object?)model.ProgramId ?? DBNull.Value),
                new NpgsqlParameter("@classId", (object?)model.ClassId ?? DBNull.Value),
                new NpgsqlParameter("@monthlyFee", (object?)model.MonthlyFee ?? DBNull.Value),
                new NpgsqlParameter("@admissionFee", (object?)model.AdmissionFee ?? DBNull.Value),
                new NpgsqlParameter("@discount", (object?)model.DiscountAmount ?? DBNull.Value),
                new NpgsqlParameter("@paymentStatus", (object?)model.PaymentStatusId ?? DBNull.Value),
                new NpgsqlParameter("@status", (object?)model.AdmissionStatus ?? DBNull.Value),
                new NpgsqlParameter("@remarks", (object?)model.Remarks ?? DBNull.Value)
            };

            int result = _db.ExecuteNonQuery(query, parameters);
            return Task.FromResult(result);
        }

        public Task<int> UpdateAsync(AdmissionModel model)
        {
            string query = @"UPDATE blumebee.admission SET
                student_id=@studentId,
                admission_date=@admissionDate,
                program_id=@programId,
                class_id=@classId,
                monthly_fee=@monthlyFee,
                admission_fee=@admissionFee,
                discount_amount=@discount,
                payment_status_id=@paymentStatus,
                admission_status=@status,
                remarks=@remarks
                WHERE id=@id";

            var parameters = new[]
            {
                new NpgsqlParameter("@id", model.Id),
                new NpgsqlParameter("@studentId", (object?)model.StudentId ?? DBNull.Value),
                new NpgsqlParameter("@admissionDate", (object?)model.AdmissionDate ?? DBNull.Value),
                new NpgsqlParameter("@programId", (object?)model.ProgramId ?? DBNull.Value),
                new NpgsqlParameter("@classId", (object?)model.ClassId ?? DBNull.Value),
                new NpgsqlParameter("@monthlyFee", (object?)model.MonthlyFee ?? DBNull.Value),
                new NpgsqlParameter("@admissionFee", (object?)model.AdmissionFee ?? DBNull.Value),
                new NpgsqlParameter("@discount", (object?)model.DiscountAmount ?? DBNull.Value),
                new NpgsqlParameter("@paymentStatus", (object?)model.PaymentStatusId ?? DBNull.Value),
                new NpgsqlParameter("@status", (object?)model.AdmissionStatus ?? DBNull.Value),
                new NpgsqlParameter("@remarks", (object?)model.Remarks ?? DBNull.Value)
            };

            int result = _db.ExecuteNonQuery(query, parameters);
            return Task.FromResult(result);
        }

        public Task<int> DeleteAsync(long id)
        {
            string query = @"DELETE FROM blumebee.admission WHERE id=@id";

            var param = new[]
            {
                new NpgsqlParameter("@id", id)
            };

            int result = _db.ExecuteNonQuery(query, param);
            return Task.FromResult(result);
        }
    }
}
