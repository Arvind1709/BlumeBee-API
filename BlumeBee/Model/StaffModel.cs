namespace BlumeBee.Model
{
    public class StaffModel
    {
        public long Id { get; set; }

        public string EmployeeCode { get; set; }

        public int? CenterId { get; set; }

        public string FullName { get; set; }

        public int? GenderId { get; set; }

        public int? RoleId { get; set; }

        public int? DepartmentId { get; set; }

        public DateTime? JoiningDate { get; set; }

        public string? Qualification { get; set; }

        public decimal? ExperienceYears { get; set; }

        public string? ContactNumber { get; set; }

        public string? Email { get; set; }

        public string? AddressLine1 { get; set; }

        public string? City { get; set; }

        public string? State { get; set; }

        public string? Pincode { get; set; }

        public decimal? Salary { get; set; }

        public string? BankDetails { get; set; }

        public string? AadhaarRef { get; set; }

        public string? EmergencyContact { get; set; }

        public string? EmploymentStatus { get; set; }

        public DateTime? ProbationEndDate { get; set; }

        public string? Remarks { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}
