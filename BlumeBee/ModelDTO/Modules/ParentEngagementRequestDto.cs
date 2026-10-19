using System.ComponentModel.DataAnnotations;

namespace BlumeBee.ModelDTO.Modules;

/// <summary>Request DTO for the parent_engagement module. Database-generated id/timestamps are not client-controlled.</summary>
public sealed class ParentEngagementRequestDto
{
    public long? StudentId { get; set; }

    public long? ParentId { get; set; }

    [StringLength(150)]
    public string? EventName { get; set; }

    public DateOnly? EventDate { get; set; }

    public bool? PtmAttended { get; set; }

    public bool? ActivityParticipation { get; set; }

    public bool? HomeworkShared { get; set; }

    public decimal? FeedbackScore { get; set; }

    public string? Remarks { get; set; }

}
