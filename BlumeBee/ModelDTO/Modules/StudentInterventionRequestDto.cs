using System.ComponentModel.DataAnnotations;

namespace BlumeBee.ModelDTO.Modules;

/// <summary>Request DTO for the student_intervention module. Database-generated id/timestamps are not client-controlled.</summary>
public sealed class StudentInterventionRequestDto
{
    [Required]
    public long? StudentId { get; set; }

    [StringLength(100)]
    public string? ConcernType { get; set; }

    [Required]
    public DateOnly? IdentifiedDate { get; set; }

    public string? SupportPlan { get; set; }

    public long? ResponsibleStaffId { get; set; }

    public DateOnly? ReviewDate { get; set; }

    [StringLength(50)]
    public string? Status { get; set; }

    public bool? ParentCounsellingNeeded { get; set; }

    public string? Remarks { get; set; }

}
