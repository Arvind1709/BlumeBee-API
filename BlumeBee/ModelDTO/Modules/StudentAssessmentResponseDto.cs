namespace BlumeBee.ModelDTO.Modules;

/// <summary>Typed response DTO for the student_assessment module.</summary>
public sealed class StudentAssessmentResponseDto
{
    public long? Id { get; set; }

    public long? StudentId { get; set; }

    public int? ClassId { get; set; }

    public string? AssessmentPeriod { get; set; }

    public DateOnly? AssessmentDate { get; set; }

    public int? DomainId { get; set; }

    public string? AssessmentMethod { get; set; }

    public string? GradeLevel { get; set; }

    public string? TeacherFeedback { get; set; }

    public string? ParentFeedback { get; set; }

    public DateOnly? ReportSharedDate { get; set; }

    public string? Remarks { get; set; }

}
