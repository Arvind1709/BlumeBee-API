using System.ComponentModel.DataAnnotations;

namespace BlumeBee.ModelDTO.Modules;

/// <summary>Request DTO for the student_health_record module. Database-generated id/timestamps are not client-controlled.</summary>
public sealed class StudentHealthRecordRequestDto
{
    [Required]
    public long? StudentId { get; set; }

    [StringLength(10)]
    public string? BloodGroup { get; set; }

    public string? AllergyDetails { get; set; }

    public string? MedicalCondition { get; set; }

    [StringLength(150)]
    public string? DoctorName { get; set; }

    [StringLength(20)]
    public string? EmergencyContact { get; set; }

    public string? MedicationInstructions { get; set; }

    public bool? VaccinationRecordSubmitted { get; set; }

    public string? SpecialNotes { get; set; }

}
