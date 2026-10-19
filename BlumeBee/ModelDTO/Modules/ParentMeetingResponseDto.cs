namespace BlumeBee.ModelDTO.Modules;

/// <summary>Typed response DTO for the parent_meeting module.</summary>
public sealed class ParentMeetingResponseDto
{
    public long? Id { get; set; }

    public DateOnly? MeetingDate { get; set; }

    public long? StudentId { get; set; }

    public long? ParentId { get; set; }

    public int? ClassId { get; set; }

    public string? MeetingType { get; set; }

    public string? Purpose { get; set; }

    public string? DiscussionNotes { get; set; }

    public string? ConcernsRaised { get; set; }

    public string? ActionAgreed { get; set; }

    public long? TeacherStaffId { get; set; }

    public DateOnly? NextFollowUp { get; set; }

    public string? ClosureStatus { get; set; }

}
