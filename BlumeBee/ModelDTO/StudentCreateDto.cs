using System.ComponentModel.DataAnnotations;

namespace BlumeBee.ModelDTO
{
    public class StudentCreateDto
    {
        public long Id { get; set; }
        [Required]
        [StringLength(30)]
        public string StudentCode { get; set; } = string.Empty;

        public int? CenterId { get; set; }
        public string? CenterName { get; set; }
        [Required]
        [StringLength(80)]
        public string FirstName { get; set; } = string.Empty;

        [StringLength(80)]
        public string? LastName { get; set; }

        [Required]
        [StringLength(160)]
        public string FullName { get; set; } = string.Empty;

        public int? GenderId { get; set; }

        [Required]
        public DateTime Dob { get; set; }

        [StringLength(10)]
        public string? BloodGroup { get; set; }

        public string? Allergies { get; set; }
        public string? MedicalNotes { get; set; }
        public string? SpecialSupportNotes { get; set; }

        [StringLength(255)]
        public string? AddressLine1 { get; set; }

        [StringLength(255)]
        public string? AddressLine2 { get; set; }

        [StringLength(100)]
        public string? City { get; set; }

        [StringLength(100)]
        public string? State { get; set; }

        [StringLength(20)]
        public string? Pincode { get; set; }

        [StringLength(100)]
        public string? AadhaarRef { get; set; }

        public int? StudentStatusId { get; set; }

        public string? Remarks { get; set; }
    }
}
