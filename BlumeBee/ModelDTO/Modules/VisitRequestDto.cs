using System.ComponentModel.DataAnnotations;

namespace BlumeBee.ModelDTO.Modules;

/// <summary>Request DTO for the visit module. Database-generated id/timestamps are not client-controlled.</summary>
public sealed class VisitRequestDto
{
    [Required]
    [StringLength(30)]
    public string? VisitCode { get; set; }

    public long? LeadId { get; set; }

    [Required]
    public DateOnly? VisitDate { get; set; }

    [StringLength(150)]
    public string? ParentName { get; set; }

    [StringLength(150)]
    public string? ChildName { get; set; }

    [StringLength(100)]
    public string? PurposeOfVisit { get; set; }

    public long? CounsellorStaffId { get; set; }

    public string? ParentFeedback { get; set; }

    public string? ChildInteractionNotes { get; set; }

    [StringLength(100)]
    public string? VisitOutcome { get; set; }

    [StringLength(50)]
    public string? AdmissionProbability { get; set; }

    public bool? RegistrationDone { get; set; }

    public DateOnly? NextFollowUpDate { get; set; }

    public string? Remarks { get; set; }

}
