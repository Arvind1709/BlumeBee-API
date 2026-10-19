namespace BlumeBee.ModelDTO.Modules;

/// <summary>Typed response DTO for the student_health_record module.</summary>
public sealed class StudentHealthRecordResponseDto
{
    public long? Id { get; set; }

    public long? StudentId { get; set; }

    public string? BloodGroup { get; set; }

    public string? AllergyDetails { get; set; }

    public string? MedicalCondition { get; set; }

    public string? DoctorName { get; set; }

    public string? EmergencyContact { get; set; }

    public string? MedicationInstructions { get; set; }

    public bool? VaccinationRecordSubmitted { get; set; }

    public string? SpecialNotes { get; set; }

    public DateTime? UpdatedAt { get; set; }

}
