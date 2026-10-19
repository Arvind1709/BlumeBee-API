using BlumeBee.Data;
using BlumeBee.IRepository;
using BlumeBee.Model;
using Npgsql;
using System.Data;

namespace BlumeBee.Repositories
{
    public class LeadRepository : ILeadRepository
    {
        private readonly PostgresDbHelper _db;

        public LeadRepository(PostgresDbHelper db)
        {
            _db = db;
        }

        //public Task<List<LeadModel>> GetAllAsync()
        //{
        //    string query = @"SELECT * FROM blumebee.lead ORDER BY id DESC";

        //    DataTable dt = _db.ExecuteQuery(query);

        //    var list = dt.AsEnumerable().Select(row => new LeadModel
        //    {
        //        Id = Convert.ToInt64(row["id"]),
        //        LeadCode = row["lead_code"].ToString(),
        //        ParentName = row["parent_name"].ToString(),
        //        ChildName = row["child_name"]?.ToString(),
        //        InquiryDate = Convert.ToDateTime(row["inquiry_date"]),
        //        ParentContactNumber = row["parent_contact_number"]?.ToString(),
        //        Email = row["email"]?.ToString(),
        //        Remarks = row["remarks"]?.ToString()
        //    }).ToList();

        //    return Task.FromResult(list);
        //}

        public Task<List<LeadModel>> GetAllAsync()
        {
            string query = @"SELECT * FROM blumebee.lead ORDER BY id DESC";

            DataTable dt = _db.ExecuteQuery(query);

            var list = dt.AsEnumerable().Select(row => new LeadModel
            {
                Id = Convert.ToInt64(row["id"]),
                LeadCode = row["lead_code"]?.ToString(),

                CenterId = row["center_id"] == DBNull.Value ? null : Convert.ToInt32(row["center_id"]),
                InquiryDate = Convert.ToDateTime(row["inquiry_date"]),
                LeadSourceId = row["lead_source_id"] == DBNull.Value ? null : Convert.ToInt32(row["lead_source_id"]),

                ParentName = row["parent_name"]?.ToString(),
                ChildName = row["child_name"]?.ToString(),
                ChildDob = row["child_dob"] == DBNull.Value ? null : Convert.ToDateTime(row["child_dob"]),

                ParentContactNumber = row["parent_contact_number"]?.ToString(),
                WhatsappNumber = row["whatsapp_number"]?.ToString(),
                Email = row["email"]?.ToString(),

                PreferredProgramId = row["preferred_program_id"] == DBNull.Value ? null : Convert.ToInt32(row["preferred_program_id"]),
                InterestedClassId = row["interested_class_id"] == DBNull.Value ? null : Convert.ToInt32(row["interested_class_id"]),

                LocationArea = row["location_area"]?.ToString(),
                WorkingParents = row["working_parents"] == DBNull.Value ? null : Convert.ToBoolean(row["working_parents"]),

                CounselorStaffId = row["counselor_staff_id"] == DBNull.Value ? null : Convert.ToInt32(row["counselor_staff_id"]),

                FollowUpDate = row["follow_up_date"] == DBNull.Value ? null : Convert.ToDateTime(row["follow_up_date"]),
                LeadStatusId = row["lead_status_id"] == DBNull.Value ? null : Convert.ToInt32(row["lead_status_id"]),

                LastContactDate = row["last_contact_date"] == DBNull.Value ? null : Convert.ToDateTime(row["last_contact_date"]),
                FirstResponseAt = row["first_response_at"] == DBNull.Value ? null : Convert.ToDateTime(row["first_response_at"]),

                PipelineStage = row["pipeline_stage"]?.ToString(),
                LostReason = row["lost_reason"]?.ToString(),

                ProbabilityPercent = row["probability_percent"] == DBNull.Value
                    ? null
                    : Convert.ToDecimal(row["probability_percent"]),

                Remarks = row["remarks"]?.ToString(),

                CreatedAt = row["created_at"] == DBNull.Value ? null : Convert.ToDateTime(row["created_at"]),
                UpdatedAt = row["updated_at"] == DBNull.Value ? null : Convert.ToDateTime(row["updated_at"])
            }).ToList();

            return Task.FromResult(list);
        }

        //public Task<LeadModel> GetByIdAsync(long id)
        //{
        //    string query = @"SELECT * FROM blumebee.lead WHERE id=@id";

        //    var param = new[]
        //    {
        //        new NpgsqlParameter("@id", id)
        //    };

        //    DataTable dt = _db.ExecuteQuery(query, param);

        //    var data = dt.AsEnumerable().Select(row => new LeadModel
        //    {
        //        Id = Convert.ToInt64(row["id"]),
        //        LeadCode = row["lead_code"].ToString(),
        //        ParentName = row["parent_name"].ToString(),
        //        ChildName = row["child_name"]?.ToString(),
        //        InquiryDate = Convert.ToDateTime(row["inquiry_date"]),
        //        Remarks = row["remarks"]?.ToString()
        //    }).FirstOrDefault();

        //    return Task.FromResult(data);
        //}

        public Task<LeadModel> GetByIdAsync(long id)
        {
            string query = @"SELECT * FROM blumebee.lead WHERE id=@id";

            var param = new[]
            {
        new NpgsqlParameter("@id", id)
    };

            DataTable dt = _db.ExecuteQuery(query, param);

            var data = dt.AsEnumerable().Select(row => new LeadModel
            {
                Id = Convert.ToInt64(row["id"]),
                LeadCode = row["lead_code"]?.ToString(),

                CenterId = row["center_id"] == DBNull.Value ? null : Convert.ToInt32(row["center_id"]),
                InquiryDate = Convert.ToDateTime(row["inquiry_date"]),
                LeadSourceId = row["lead_source_id"] == DBNull.Value ? null : Convert.ToInt32(row["lead_source_id"]),

                ParentName = row["parent_name"]?.ToString(),
                ChildName = row["child_name"]?.ToString(),
                ChildDob = row["child_dob"] == DBNull.Value ? null : Convert.ToDateTime(row["child_dob"]),

                ParentContactNumber = row["parent_contact_number"]?.ToString(),
                WhatsappNumber = row["whatsapp_number"]?.ToString(),
                Email = row["email"]?.ToString(),

                PreferredProgramId = row["preferred_program_id"] == DBNull.Value ? null : Convert.ToInt32(row["preferred_program_id"]),
                InterestedClassId = row["interested_class_id"] == DBNull.Value ? null : Convert.ToInt32(row["interested_class_id"]),

                LocationArea = row["location_area"]?.ToString(),
                WorkingParents = row["working_parents"] == DBNull.Value ? null : Convert.ToBoolean(row["working_parents"]),

                CounselorStaffId = row["counselor_staff_id"] == DBNull.Value ? null : Convert.ToInt32(row["counselor_staff_id"]),

                FollowUpDate = row["follow_up_date"] == DBNull.Value ? null : Convert.ToDateTime(row["follow_up_date"]),
                LeadStatusId = row["lead_status_id"] == DBNull.Value ? null : Convert.ToInt32(row["lead_status_id"]),

                LastContactDate = row["last_contact_date"] == DBNull.Value ? null : Convert.ToDateTime(row["last_contact_date"]),
                FirstResponseAt = row["first_response_at"] == DBNull.Value ? null : Convert.ToDateTime(row["first_response_at"]),

                PipelineStage = row["pipeline_stage"]?.ToString(),
                LostReason = row["lost_reason"]?.ToString(),

                ProbabilityPercent = row["probability_percent"] == DBNull.Value
                    ? null
                    : Convert.ToDecimal(row["probability_percent"]),

                Remarks = row["remarks"]?.ToString(),

                CreatedAt = row["created_at"] == DBNull.Value ? null : Convert.ToDateTime(row["created_at"]),
                UpdatedAt = row["updated_at"] == DBNull.Value ? null : Convert.ToDateTime(row["updated_at"])
            }).FirstOrDefault();

            return Task.FromResult(data);
        }

        //public Task<int> CreateAsync(LeadModel model)
        //{
        //    string query = @"INSERT INTO blumebee.lead
        //    (lead_code, inquiry_date, parent_name, child_name, parent_contact_number, email, remarks)
        //    VALUES (@leadCode, @inquiryDate, @parentName, @childName, @contact, @email, @remarks)";

        //    var parameters = new[]
        //    {
        //        new NpgsqlParameter("@leadCode", model.LeadCode),
        //        new NpgsqlParameter("@inquiryDate", model.InquiryDate),
        //        new NpgsqlParameter("@parentName", model.ParentName),
        //        new NpgsqlParameter("@childName", (object?)model.ChildName ?? DBNull.Value),
        //        new NpgsqlParameter("@contact", (object?)model.ParentContactNumber ?? DBNull.Value),
        //        new NpgsqlParameter("@email", (object?)model.Email ?? DBNull.Value),
        //        new NpgsqlParameter("@remarks", (object?)model.Remarks ?? DBNull.Value)
        //    };

        //    int result = _db.ExecuteNonQuery(query, parameters);
        //    return Task.FromResult(result);
        //}

        public Task<int> CreateAsync(LeadModel model)
        {
            string query = @"
        INSERT INTO blumebee.lead
        (
            lead_code,
            center_id,
            inquiry_date,
            lead_source_id,
            parent_name,
            child_name,
            child_dob,
            parent_contact_number,
            whatsapp_number,
            email,
            preferred_program_id,
            interested_class_id,
            location_area,
            working_parents,
            counselor_staff_id,
            follow_up_date,
            lead_status_id,
            last_contact_date,
            first_response_at,
            pipeline_stage,
            lost_reason,
            probability_percent,
            remarks
        )
        VALUES
        (
            @lead_code,
            @center_id,
            @inquiry_date,
            @lead_source_id,
            @parent_name,
            @child_name,
            @child_dob,
            @parent_contact_number,
            @whatsapp_number,
            @email,
            @preferred_program_id,
            @interested_class_id,
            @location_area,
            @working_parents,
            @counselor_staff_id,
            @follow_up_date,
            @lead_status_id,
            @last_contact_date,
            @first_response_at,
            @pipeline_stage,
            @lost_reason,
            @probability_percent,
            @remarks
        )";

            var parameters = new[]
            {
        new NpgsqlParameter("@lead_code", model.LeadCode),

        new NpgsqlParameter("@center_id", (object?)model.CenterId ?? DBNull.Value),
        new NpgsqlParameter("@inquiry_date", model.InquiryDate),
        new NpgsqlParameter("@lead_source_id", (object?)model.LeadSourceId ?? DBNull.Value),

        new NpgsqlParameter("@parent_name", model.ParentName),
        new NpgsqlParameter("@child_name", (object?)model.ChildName ?? DBNull.Value),
        new NpgsqlParameter("@child_dob", (object?)model.ChildDob ?? DBNull.Value),

        new NpgsqlParameter("@parent_contact_number", (object?)model.ParentContactNumber ?? DBNull.Value),
        new NpgsqlParameter("@whatsapp_number", (object?)model.WhatsappNumber ?? DBNull.Value),
        new NpgsqlParameter("@email", (object?)model.Email ?? DBNull.Value),

        new NpgsqlParameter("@preferred_program_id", (object?)model.PreferredProgramId ?? DBNull.Value),
        new NpgsqlParameter("@interested_class_id", (object?)model.InterestedClassId ?? DBNull.Value),

        new NpgsqlParameter("@location_area", (object?)model.LocationArea ?? DBNull.Value),
        new NpgsqlParameter("@working_parents", (object?)model.WorkingParents ?? DBNull.Value),

        new NpgsqlParameter("@counselor_staff_id", (object?)model.CounselorStaffId ?? DBNull.Value),

        new NpgsqlParameter("@follow_up_date", (object?)model.FollowUpDate ?? DBNull.Value),
        new NpgsqlParameter("@lead_status_id", (object?)model.LeadStatusId ?? DBNull.Value),

        new NpgsqlParameter("@last_contact_date", (object?)model.LastContactDate ?? DBNull.Value),
        new NpgsqlParameter("@first_response_at", (object?)model.FirstResponseAt ?? DBNull.Value),

        new NpgsqlParameter("@pipeline_stage", (object?)model.PipelineStage ?? DBNull.Value),
        new NpgsqlParameter("@lost_reason", (object?)model.LostReason ?? DBNull.Value),

        new NpgsqlParameter("@probability_percent", (object?)model.ProbabilityPercent ?? DBNull.Value),
        new NpgsqlParameter("@remarks", (object?)model.Remarks ?? DBNull.Value)
    };

            int result = _db.ExecuteNonQuery(query, parameters);
            return Task.FromResult(result);
        }


        public Task<int> UpdateAsync(LeadModel model)
        {
                  string query = @"
                    UPDATE blumebee.lead
                    SET
                        lead_code = @lead_code,
                        center_id = @center_id,
                        inquiry_date = @inquiry_date,
                        lead_source_id = @lead_source_id,
                        parent_name = @parent_name,
                        child_name = @child_name,
                        child_dob = @child_dob,
                        parent_contact_number = @parent_contact_number,
                        whatsapp_number = @whatsapp_number,
                        email = @email,
                        preferred_program_id = @preferred_program_id,
                        interested_class_id = @interested_class_id,
                        location_area = @location_area,
                        working_parents = @working_parents,
                        counselor_staff_id = @counselor_staff_id,
                        follow_up_date = @follow_up_date,
                        lead_status_id = @lead_status_id,
                        last_contact_date = @last_contact_date,
                        first_response_at = @first_response_at,
                        pipeline_stage = @pipeline_stage,
                        lost_reason = @lost_reason,
                        probability_percent = @probability_percent,
                        remarks = @remarks,
                        updated_at = NOW()
                  WHERE id = @id";

                        var parameters = new[]
                        {
                    new NpgsqlParameter("@id", model.Id),

                    new NpgsqlParameter("@lead_code", model.LeadCode),
                    new NpgsqlParameter("@center_id", (object?)model.CenterId ?? DBNull.Value),
                    new NpgsqlParameter("@inquiry_date", model.InquiryDate),
                    new NpgsqlParameter("@lead_source_id", (object?)model.LeadSourceId ?? DBNull.Value),

                    new NpgsqlParameter("@parent_name", model.ParentName),
                    new NpgsqlParameter("@child_name", (object?)model.ChildName ?? DBNull.Value),
                    new NpgsqlParameter("@child_dob", (object?)model.ChildDob ?? DBNull.Value),

                    new NpgsqlParameter("@parent_contact_number", (object?)model.ParentContactNumber ?? DBNull.Value),
                    new NpgsqlParameter("@whatsapp_number", (object?)model.WhatsappNumber ?? DBNull.Value),
                    new NpgsqlParameter("@email", (object?)model.Email ?? DBNull.Value),

                    new NpgsqlParameter("@preferred_program_id", (object?)model.PreferredProgramId ?? DBNull.Value),
                    new NpgsqlParameter("@interested_class_id", (object?)model.InterestedClassId ?? DBNull.Value),

                    new NpgsqlParameter("@location_area", (object?)model.LocationArea ?? DBNull.Value),
                    new NpgsqlParameter("@working_parents", (object?)model.WorkingParents ?? DBNull.Value),

                    new NpgsqlParameter("@counselor_staff_id", (object?)model.CounselorStaffId ?? DBNull.Value),

                    new NpgsqlParameter("@follow_up_date", (object?)model.FollowUpDate ?? DBNull.Value),
                    new NpgsqlParameter("@lead_status_id", (object?)model.LeadStatusId ?? DBNull.Value),

                    new NpgsqlParameter("@last_contact_date", (object?)model.LastContactDate ?? DBNull.Value),
                    new NpgsqlParameter("@first_response_at", (object?)model.FirstResponseAt ?? DBNull.Value),

                    new NpgsqlParameter("@pipeline_stage", (object?)model.PipelineStage ?? DBNull.Value),
                    new NpgsqlParameter("@lost_reason", (object?)model.LostReason ?? DBNull.Value),

                    new NpgsqlParameter("@probability_percent", (object?)model.ProbabilityPercent ?? DBNull.Value),
                    new NpgsqlParameter("@remarks", (object?)model.Remarks ?? DBNull.Value)
                };

                        int result = _db.ExecuteNonQuery(query, parameters);
                        return Task.FromResult(result);
        }

        public Task<int> DeleteAsync(long id)
        {
            string query = @"DELETE FROM blumebee.lead WHERE id=@id";

            var param = new[]
            {
                new NpgsqlParameter("@id", id)
            };

            int result = _db.ExecuteNonQuery(query, param);
            return Task.FromResult(result);
        }
    }
}
