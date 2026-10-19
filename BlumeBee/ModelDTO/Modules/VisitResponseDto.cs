namespace BlumeBee.ModelDTO.Modules;

/// <summary>Typed response DTO for the visit module.</summary>
public sealed class VisitResponseDto
{
    public long? Id { get; set; }

    public string? VisitCode { get; set; }

    public long? LeadId { get; set; }

    public DateOnly? VisitDate { get; set; }

    public string? ParentName { get; set; }

    public string? ChildName { get; set; }

    public string? PurposeOfVisit { get; set; }

    public long? CounsellorStaffId { get; set; }

    public string? ParentFeedback { get; set; }

    public string? ChildInteractionNotes { get; set; }

    public string? VisitOutcome { get; set; }

    public string? AdmissionProbability { get; set; }

    public bool? RegistrationDone { get; set; }

    public DateOnly? NextFollowUpDate { get; set; }

    public string? Remarks { get; set; }

    public DateTime? CreatedAt { get; set; }

}
