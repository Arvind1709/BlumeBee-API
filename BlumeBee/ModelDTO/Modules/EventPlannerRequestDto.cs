using System.ComponentModel.DataAnnotations;

namespace BlumeBee.ModelDTO.Modules;

/// <summary>Request DTO for the event_planner module. Database-generated id/timestamps are not client-controlled.</summary>
public sealed class EventPlannerRequestDto
{
    [Required]
    [StringLength(150)]
    public string? EventName { get; set; }

    [Required]
    public DateOnly? EventDate { get; set; }

    [StringLength(100)]
    public string? TargetGroup { get; set; }

    public long? CoordinatorStaffId { get; set; }

    public decimal? BudgetAmount { get; set; }

    [StringLength(50)]
    public string? Status { get; set; }

    public string? Remarks { get; set; }

}
