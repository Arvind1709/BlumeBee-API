namespace BlumeBee.ModelDTO.Modules;

/// <summary>Typed response DTO for the staff_training module.</summary>
public sealed class StaffTrainingResponseDto
{
    public long? Id { get; set; }

    public long? StaffId { get; set; }

    public string? TrainingType { get; set; }

    public DateOnly? TrainingDate { get; set; }

    public string? TrainerName { get; set; }

    public string? CompletionStatus { get; set; }

    public DateOnly? ValidTill { get; set; }

    public string? Remarks { get; set; }

}
