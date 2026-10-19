namespace BlumeBee.ModelDTO
{
    public class VisitorLogModelDto
    {
        public DateTime VisitDate { get; set; }
        public string VisitorName { get; set; }
        public string? ContactNumber { get; set; }
        public string? PurposeOfVisit { get; set; }
        public TimeSpan? InTime { get; set; }
        public TimeSpan? OutTime { get; set; }
        public string? PersonMet { get; set; }
        public bool IdVerified { get; set; }
        public string? Remarks { get; set; }
    }
}
