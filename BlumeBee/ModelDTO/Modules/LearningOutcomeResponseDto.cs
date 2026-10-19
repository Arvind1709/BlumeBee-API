namespace BlumeBee.ModelDTO.Modules;

/// <summary>Typed response DTO for the learning_outcome module.</summary>
public sealed class LearningOutcomeResponseDto
{
    public long? Id { get; set; }

    public int? ClassId { get; set; }

    public int? DomainId { get; set; }

    public string? Milestone { get; set; }

    public string? Description { get; set; }

    public string? AgeBand { get; set; }

    public bool? IsActive { get; set; }

}
