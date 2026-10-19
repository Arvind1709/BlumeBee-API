using System.ComponentModel.DataAnnotations;

namespace BlumeBee.ModelDTO.Modules;

/// <summary>Request DTO for the maintenance_log module. Database-generated id/timestamps are not client-controlled.</summary>
public sealed class MaintenanceLogRequestDto
{
    [Required]
    public DateOnly? TaskDate { get; set; }

    [StringLength(100)]
    public string? Area { get; set; }

    [StringLength(100)]
    public string? TaskType { get; set; }

    public string? Description { get; set; }

    public long? AssignedToStaffId { get; set; }

    [StringLength(50)]
    public string? Status { get; set; }

    public string? Remarks { get; set; }

}
