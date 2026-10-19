using System.ComponentModel.DataAnnotations;

namespace BlumeBee.ModelDTO.Modules;

/// <summary>Request DTO for the document_tracker module. Database-generated id/timestamps are not client-controlled.</summary>
public sealed class DocumentTrackerRequestDto
{
    [Required]
    [StringLength(30)]
    public string? EntityType { get; set; }

    [Required]
    public long? EntityId { get; set; }

    [StringLength(100)]
    public string? ClassOrDepartment { get; set; }

    [Required]
    [StringLength(100)]
    public string? DocumentName { get; set; }

    public bool? Submitted { get; set; }

    public DateOnly? SubmissionDate { get; set; }

    public long? VerifiedByStaffId { get; set; }

    [StringLength(50)]
    public string? PendingStatus { get; set; }

    public string? Remarks { get; set; }

}
