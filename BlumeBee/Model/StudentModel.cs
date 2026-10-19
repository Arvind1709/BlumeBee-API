namespace BlumeBee.Model
{
    public class StudentModel
    {
        public long Id { get; set; }                    // BIGSERIAL

        public string StudentCode { get; set; }         // VARCHAR(30)

        public int? CenterId { get; set; }              // FK (nullable)
        public string CenterName { get; set; }              // FK (nullable)

        public string FirstName { get; set; }           // VARCHAR(80)

        public string LastName { get; set; }            // VARCHAR(80)

        public string FullName { get; set; }            // VARCHAR(160)

        public int? GenderId { get; set; }              // FK (nullable)

        public DateTime Dob { get; set; }               // DATE

        public string BloodGroup { get; set; }          // VARCHAR(10)

        public string Allergies { get; set; }           // TEXT

        public string MedicalNotes { get; set; }        // TEXT

        public string SpecialSupportNotes { get; set; } // TEXT

        public string AddressLine1 { get; set; }        // VARCHAR(255)

        public string AddressLine2 { get; set; }        // VARCHAR(255)

        public string City { get; set; }                // VARCHAR(100)

        public string State { get; set; }               // VARCHAR(100)

        public string Pincode { get; set; }             // VARCHAR(20)

        public string AadhaarRef { get; set; }          // VARCHAR(100)

        public int? StudentStatusId { get; set; }       // FK (nullable)

        public string Remarks { get; set; }             // TEXT

        public DateTime CreatedAt { get; set; }         // TIMESTAMP

        public DateTime UpdatedAt { get; set; }         // TIMESTAMP
    }
}
