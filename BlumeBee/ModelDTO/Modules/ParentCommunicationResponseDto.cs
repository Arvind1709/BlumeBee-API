namespace BlumeBee.ModelDTO.Modules;

/// <summary>Typed response DTO for the parent_communication module.</summary>
public sealed class ParentCommunicationResponseDto
{
    public long? Id { get; set; }

    public DateOnly? CommunicationDate { get; set; }

    public long? StudentId { get; set; }

    public long? ParentId { get; set; }

    public int? CommunicationTypeId { get; set; }

    public string? Subject { get; set; }

    public string? DiscussionSummary { get; set; }

    public string? ActionRequired { get; set; }

    public long? ResponsibleStaffId { get; set; }

    public DateOnly? FollowUpDate { get; set; }

    public DateOnly? ClosureDate { get; set; }

    public string? Status { get; set; }

    public string? Remarks { get; set; }

}
