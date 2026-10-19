using System.ComponentModel.DataAnnotations;

namespace BlumeBee.ModelDTO.Modules;

/// <summary>Request DTO for the emergency_drill module. Database-generated id/timestamps are not client-controlled.</summary>
public sealed class EmergencyDrillRequestDto
{
    [Required]
    public DateOnly? DrillDate { get; set; }

    [StringLength(100)]
    public string? DrillType { get; set; }

    public long? ConductedByStaffId { get; set; }

    public string? Observations { get; set; }

    public string? ActionPoints { get; set; }

    public DateOnly? ClosureDate { get; set; }

    public string? Remarks { get; set; }

}
