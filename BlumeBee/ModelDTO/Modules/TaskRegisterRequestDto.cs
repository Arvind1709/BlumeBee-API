using System.ComponentModel.DataAnnotations;

namespace BlumeBee.ModelDTO.Modules;

/// <summary>Request DTO for the task_register module. Database-generated id/timestamps are not client-controlled.</summary>
public sealed class TaskRegisterRequestDto
{
    [Required]
    public DateOnly? TaskDate { get; set; }

    [StringLength(100)]
    public string? ModuleName { get; set; }

    [Required]
    [StringLength(200)]
    public string? TaskTitle { get; set; }

    public string? TaskDescription { get; set; }

    [StringLength(30)]
    public string? Priority { get; set; }

    [StringLength(50)]
    public string? Status { get; set; }

    public long? AssignedToStaffId { get; set; }

    public long? EscalatedToStaffId { get; set; }

    public DateOnly? DueDate { get; set; }

    public DateOnly? CompletedDate { get; set; }

    [StringLength(30)]
    public string? RelatedEntityType { get; set; }

    public long? RelatedEntityId { get; set; }

    public string? Remarks { get; set; }

}
