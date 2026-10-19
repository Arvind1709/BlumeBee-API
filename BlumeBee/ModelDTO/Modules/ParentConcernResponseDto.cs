namespace BlumeBee.ModelDTO.Modules;

/// <summary>Typed response DTO for the parent_concern module.</summary>
public sealed class ParentConcernResponseDto
{
    public long? Id { get; set; }

    public DateOnly? ConcernDate { get; set; }

    public long? StudentId { get; set; }

    public long? ParentId { get; set; }

    public int? SeverityId { get; set; }

    public string? ConcernSubject { get; set; }

    public string? ConcernDescription { get; set; }

    public long? OwnerStaffId { get; set; }

    public DateOnly? PromisedResolutionDate { get; set; }

    public DateOnly? ClosureDate { get; set; }

    public string? Status { get; set; }

    public bool? SlaBreached { get; set; }

    public string? Remarks { get; set; }

}
