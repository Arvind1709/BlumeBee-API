using System.ComponentModel.DataAnnotations;

namespace BlumeBee.ModelDTO.Modules;

/// <summary>Request DTO for the parent_communication module. Database-generated id/timestamps are not client-controlled.</summary>
public sealed class ParentCommunicationRequestDto
{
    [Required]
    public DateOnly? CommunicationDate { get; set; }

    public long? StudentId { get; set; }

    public long? ParentId { get; set; }

    public int? CommunicationTypeId { get; set; }

    [StringLength(200)]
    public string? Subject { get; set; }

    public string? DiscussionSummary { get; set; }

    public string? ActionRequired { get; set; }

    public long? ResponsibleStaffId { get; set; }

    public DateOnly? FollowUpDate { get; set; }

    public DateOnly? ClosureDate { get; set; }

    [StringLength(50)]
    public string? Status { get; set; }

    public string? Remarks { get; set; }

}
