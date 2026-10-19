using System.ComponentModel.DataAnnotations;

namespace BlumeBee.ModelDTO.Modules;

/// <summary>Request DTO for the staff_verification module. Database-generated id/timestamps are not client-controlled.</summary>
public sealed class StaffVerificationRequestDto
{
    [Required]
    public long? StaffId { get; set; }

    public bool? PoliceVerification { get; set; }

    public bool? ReferenceCheck { get; set; }

    public bool? MedicalFitness { get; set; }

    public bool? PocsoOrientation { get; set; }

    public bool? FirstAidTraining { get; set; }

    public string? Remarks { get; set; }

}
