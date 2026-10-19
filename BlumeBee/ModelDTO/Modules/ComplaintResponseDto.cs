namespace BlumeBee.ModelDTO.Modules;

/// <summary>Typed response DTO for the complaint module.</summary>
public sealed class ComplaintResponseDto
{
    public long? Id { get; set; }

    public string? ComplaintCode { get; set; }

    public DateOnly? ComplaintDate { get; set; }

    public string? ComplaintBy { get; set; }

    public string? ReferenceType { get; set; }

    public long? ReferenceId { get; set; }

    public string? Category { get; set; }

    public string? Description { get; set; }

    public long? AssignedToStaffId { get; set; }

    public string? ActionTaken { get; set; }

    public DateOnly? ResolutionDate { get; set; }

    public string? Status { get; set; }

    public string? Remarks { get; set; }

}
