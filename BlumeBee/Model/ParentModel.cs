namespace BlumeBee.Model
{
    public class ParentModel
    {
        public long Id { get; set; }
        public string FullName { get; set; }
        public int? RelationshipMasterId { get; set; }

        public string? PhonePrimary { get; set; }
        public string? PhoneWhatsapp { get; set; }
        public string? Email { get; set; }
        public string? Occupation { get; set; }

        public string? AddressLine1 { get; set; }
        public string? AddressLine2 { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public string? Pincode { get; set; }

        public string? AadhaarRef { get; set; }

        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
