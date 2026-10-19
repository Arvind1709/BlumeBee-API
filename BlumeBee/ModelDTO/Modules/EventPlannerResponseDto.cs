namespace BlumeBee.ModelDTO.Modules;

/// <summary>Typed response DTO for the event_planner module.</summary>
public sealed class EventPlannerResponseDto
{
    public long? Id { get; set; }

    public string? EventName { get; set; }

    public DateOnly? EventDate { get; set; }

    public string? TargetGroup { get; set; }

    public long? CoordinatorStaffId { get; set; }

    public decimal? BudgetAmount { get; set; }

    public string? Status { get; set; }

    public string? Remarks { get; set; }

}
