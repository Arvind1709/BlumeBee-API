using System.ComponentModel.DataAnnotations;

namespace BlumeBee.ModelDTO.Modules;

/// <summary>Request DTO for the student_parent module. Database-generated id/timestamps are not client-controlled.</summary>
public sealed class StudentParentRequestDto
{
    [Required]
    public long? StudentId { get; set; }

    [Required]
    public long? ParentId { get; set; }

    [StringLength(50)]
    public string? RelationshipLabel { get; set; }

    public bool? IsPrimaryContact { get; set; }

    public bool? IsEmergencyContact { get; set; }

    public bool? IsPickupAuthorized { get; set; }

}
