namespace BlumeBee.ModelDTO.Modules;

/// <summary>Typed response DTO for the student_parent module.</summary>
public sealed class StudentParentResponseDto
{
    public long? Id { get; set; }

    public long? StudentId { get; set; }

    public long? ParentId { get; set; }

    public string? RelationshipLabel { get; set; }

    public bool? IsPrimaryContact { get; set; }

    public bool? IsEmergencyContact { get; set; }

    public bool? IsPickupAuthorized { get; set; }

}
