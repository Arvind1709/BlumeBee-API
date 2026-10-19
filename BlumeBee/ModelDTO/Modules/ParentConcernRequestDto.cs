using System.ComponentModel.DataAnnotations;

namespace BlumeBee.ModelDTO.Modules;

/// <summary>Request DTO for the parent_concern module. Database-generated id/timestamps are not client-controlled.</summary>
public sealed class ParentConcernRequestDto
{
    [Required]
    public DateOnly? ConcernDate { get; set; }

    public long? StudentId { get; set; }

    public long? ParentId { get; set; }

    public int? SeverityId { get; set; }

    [StringLength(200)]
    public string? ConcernSubject { get; set; }

    public string? ConcernDescription { get; set; }

    public long? OwnerStaffId { get; set; }

    public DateOnly? PromisedResolutionDate { get; set; }

    public DateOnly? ClosureDate { get; set; }

    [StringLength(50)]
    public string? Status { get; set; }

    public bool? SlaBreached { get; set; }

    public string? Remarks { get; set; }

}
