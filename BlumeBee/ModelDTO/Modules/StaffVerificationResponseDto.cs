namespace BlumeBee.ModelDTO.Modules;

/// <summary>Typed response DTO for the staff_verification module.</summary>
public sealed class StaffVerificationResponseDto
{
    public long? Id { get; set; }

    public long? StaffId { get; set; }

    public bool? PoliceVerification { get; set; }

    public bool? ReferenceCheck { get; set; }

    public bool? MedicalFitness { get; set; }

    public bool? PocsoOrientation { get; set; }

    public bool? FirstAidTraining { get; set; }

    public string? Remarks { get; set; }

    public DateTime? UpdatedAt { get; set; }

}
