namespace BlumeBee.Model
{
    public class AdmissionModel
    {
        public long Id { get; set; }
        public string AdmissionCode { get; set; }
        public long? LeadId { get; set; }
        public long? StudentId { get; set; }
        public int? CenterId { get; set; }
        public DateTime? RegistrationDate { get; set; }
        public DateTime? AdmissionDate { get; set; }
        public int? AcademicSessionId { get; set; }
        public int? ProgramId { get; set; }
        public int? ClassId { get; set; }
        public string PreviousSchool { get; set; }

        public decimal? RegistrationFee { get; set; }
        public decimal? AdmissionFee { get; set; }
        public decimal? SecurityFee { get; set; }
        public decimal? MonthlyFee { get; set; }
        public decimal? DayCareFee { get; set; }
        public decimal? TransportFee { get; set; }
        public decimal? DiscountAmount { get; set; }

        public int? PaymentStatusId { get; set; }
        public string AdmissionStatus { get; set; }
        public string Remarks { get; set; }
    }
}
