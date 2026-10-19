namespace BlumeBee.ModelDTO.Modules;

/// <summary>Typed response DTO for the task_register module.</summary>
public sealed class TaskRegisterResponseDto
{
    public long? Id { get; set; }

    public DateOnly? TaskDate { get; set; }

    public string? ModuleName { get; set; }

    public string? TaskTitle { get; set; }

    public string? TaskDescription { get; set; }

    public string? Priority { get; set; }

    public string? Status { get; set; }

    public long? AssignedToStaffId { get; set; }

    public long? EscalatedToStaffId { get; set; }

    public DateOnly? DueDate { get; set; }

    public DateOnly? CompletedDate { get; set; }

    public string? RelatedEntityType { get; set; }

    public long? RelatedEntityId { get; set; }

    public string? Remarks { get; set; }

}
