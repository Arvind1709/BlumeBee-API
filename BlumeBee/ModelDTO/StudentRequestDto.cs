namespace BlumeBee.ModelDTO
{
    /// <summary>Request payload for Student create/update operations.</summary>
    public class StudentRequestDto
    {
        public long Id { get; set; }
        public string StudentCode { get; set; }
        public int? CenterId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get; set; }
        public int? GenderId { get; set; }
        public DateTime Dob { get; set; }
        public string BloodGroup { get; set; }
        public string Allergies { get; set; }
        public string MedicalNotes { get; set; }
        public string SpecialSupportNotes { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Pincode { get; set; }
        public string AadhaarRef { get; set; }
        public int? StudentStatusId { get; set; }
        public string Remarks { get; set; }
    }
}
