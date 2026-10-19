namespace BlumeBee.ModelDTO.Modules;

/// <summary>Typed response DTO for the document_tracker module.</summary>
public sealed class DocumentTrackerResponseDto
{
    public long? Id { get; set; }

    public string? EntityType { get; set; }

    public long? EntityId { get; set; }

    public string? ClassOrDepartment { get; set; }

    public string? DocumentName { get; set; }

    public bool? Submitted { get; set; }

    public DateOnly? SubmissionDate { get; set; }

    public long? VerifiedByStaffId { get; set; }

    public string? PendingStatus { get; set; }

    public string? Remarks { get; set; }

}
