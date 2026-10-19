namespace BlumeBee.ModelDTO.Modules;

/// <summary>Typed response DTO for the parent_engagement module.</summary>
public sealed class ParentEngagementResponseDto
{
    public long? Id { get; set; }

    public long? StudentId { get; set; }

    public long? ParentId { get; set; }

    public string? EventName { get; set; }

    public DateOnly? EventDate { get; set; }

    public bool? PtmAttended { get; set; }

    public bool? ActivityParticipation { get; set; }

    public bool? HomeworkShared { get; set; }

    public decimal? FeedbackScore { get; set; }

    public string? Remarks { get; set; }

}
