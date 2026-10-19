namespace BlumeBee.ModelDTO.Modules;

/// <summary>Typed response DTO for the student_observation module.</summary>
public sealed class StudentObservationResponseDto
{
    public long? Id { get; set; }

    public long? StudentId { get; set; }

    public int? ClassId { get; set; }

    public int? DomainId { get; set; }

    public long? LearningOutcomeId { get; set; }

    public DateOnly? ObservationDate { get; set; }

    public string? ProgressLevel { get; set; }

    public string? TeacherObservation { get; set; }

    public string? Strengths { get; set; }

    public string? ImprovementArea { get; set; }

    public string? ClassroomSupport { get; set; }

    public bool? ParentShared { get; set; }

    public string? RagStatus { get; set; }

    public string? TermName { get; set; }

    public string? Remarks { get; set; }

}
