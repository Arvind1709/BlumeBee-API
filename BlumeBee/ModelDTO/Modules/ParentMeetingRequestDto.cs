using System.ComponentModel.DataAnnotations;

namespace BlumeBee.ModelDTO.Modules;

/// <summary>Request DTO for the parent_meeting module. Database-generated id/timestamps are not client-controlled.</summary>
public sealed class ParentMeetingRequestDto
{
    [Required]
    public DateOnly? MeetingDate { get; set; }

    public long? StudentId { get; set; }

    public long? ParentId { get; set; }

    public int? ClassId { get; set; }

    [StringLength(100)]
    public string? MeetingType { get; set; }

    public string? Purpose { get; set; }

    public string? DiscussionNotes { get; set; }

    public string? ConcernsRaised { get; set; }

    public string? ActionAgreed { get; set; }

    public long? TeacherStaffId { get; set; }

    public DateOnly? NextFollowUp { get; set; }

    [StringLength(50)]
    public string? ClosureStatus { get; set; }

}
