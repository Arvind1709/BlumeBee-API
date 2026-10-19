namespace BlumeBee.ModelDTO.Modules;

/// <summary>Typed response DTO for the maintenance_log module.</summary>
public sealed class MaintenanceLogResponseDto
{
    public long? Id { get; set; }

    public DateOnly? TaskDate { get; set; }

    public string? Area { get; set; }

    public string? TaskType { get; set; }

    public string? Description { get; set; }

    public long? AssignedToStaffId { get; set; }

    public string? Status { get; set; }

    public long? CheckedByStaffId { get; set; }

    public string? Remarks { get; set; }

}
