using System.ComponentModel.DataAnnotations;

namespace BlumeBee.ModelDTO.Modules;

/// <summary>Request DTO for the student_observation module. Database-generated id/timestamps are not client-controlled.</summary>
public sealed class StudentObservationRequestDto
{
    [Required]
    public long? StudentId { get; set; }

    public int? ClassId { get; set; }

    public int? DomainId { get; set; }

    public long? LearningOutcomeId { get; set; }

    [Required]
    public DateOnly? ObservationDate { get; set; }

    [StringLength(50)]
    public string? ProgressLevel { get; set; }

    public string? TeacherObservation { get; set; }

    public string? Strengths { get; set; }

    public string? ImprovementArea { get; set; }

    public string? ClassroomSupport { get; set; }

    public bool? ParentShared { get; set; }

    [StringLength(10)]
    public string? RagStatus { get; set; }

    [StringLength(50)]
    public string? TermName { get; set; }

    public string? Remarks { get; set; }

}
