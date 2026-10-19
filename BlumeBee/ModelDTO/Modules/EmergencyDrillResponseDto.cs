namespace BlumeBee.ModelDTO.Modules;

/// <summary>Typed response DTO for the emergency_drill module.</summary>
public sealed class EmergencyDrillResponseDto
{
    public long? Id { get; set; }

    public DateOnly? DrillDate { get; set; }

    public string? DrillType { get; set; }

    public long? ConductedByStaffId { get; set; }

    public string? Observations { get; set; }

    public string? ActionPoints { get; set; }

    public DateOnly? ClosureDate { get; set; }

    public string? Remarks { get; set; }

}
