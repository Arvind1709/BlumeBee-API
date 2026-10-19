using System.ComponentModel.DataAnnotations;

namespace BlumeBee.ModelDTO.Modules;

/// <summary>Request DTO for the student_assessment module. Database-generated id/timestamps are not client-controlled.</summary>
public sealed class StudentAssessmentRequestDto
{
    [Required]
    public long? StudentId { get; set; }

    public int? ClassId { get; set; }

    [StringLength(50)]
    public string? AssessmentPeriod { get; set; }

    [Required]
    public DateOnly? AssessmentDate { get; set; }

    public int? DomainId { get; set; }

    [StringLength(100)]
    public string? AssessmentMethod { get; set; }

    [StringLength(50)]
    public string? GradeLevel { get; set; }

    public string? TeacherFeedback { get; set; }

    public string? ParentFeedback { get; set; }

    public DateOnly? ReportSharedDate { get; set; }

    public string? Remarks { get; set; }

}
