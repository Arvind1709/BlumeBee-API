namespace BlumeBee.Model
{
    public class LeadModel
    {
        public long Id { get; set; }
        public string LeadCode { get; set; }
        public int? CenterId { get; set; }
        public DateTime InquiryDate { get; set; }
        public int? LeadSourceId { get; set; }
        public string ParentName { get; set; }
        public string ChildName { get; set; }
        public DateTime? ChildDob { get; set; }
        public string ParentContactNumber { get; set; }
        public string WhatsappNumber { get; set; }
        public string Email { get; set; }
        public int? PreferredProgramId { get; set; }
        public int? InterestedClassId { get; set; }
        public string LocationArea { get; set; }
        public bool? WorkingParents { get; set; }
        public long? CounselorStaffId { get; set; }
        public DateTime? FollowUpDate { get; set; }
        public int? LeadStatusId { get; set; }
        public DateTime? LastContactDate { get; set; }
        public DateTime? FirstResponseAt { get; set; }
        public string PipelineStage { get; set; }
        public string? LostReason { get; set; }
        public decimal? ProbabilityPercent { get; set; }
        public string Remarks { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
