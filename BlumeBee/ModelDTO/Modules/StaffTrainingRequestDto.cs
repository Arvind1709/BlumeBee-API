using System.ComponentModel.DataAnnotations;

namespace BlumeBee.ModelDTO.Modules;

/// <summary>Request DTO for the staff_training module. Database-generated id/timestamps are not client-controlled.</summary>
public sealed class StaffTrainingRequestDto
{
    [Required]
    public long? StaffId { get; set; }

    [StringLength(100)]
    public string? TrainingType { get; set; }

    [Required]
    public DateOnly? TrainingDate { get; set; }

    [StringLength(150)]
    public string? TrainerName { get; set; }

    [StringLength(50)]
    public string? CompletionStatus { get; set; }

    public DateOnly? ValidTill { get; set; }

    public string? Remarks { get; set; }

}
