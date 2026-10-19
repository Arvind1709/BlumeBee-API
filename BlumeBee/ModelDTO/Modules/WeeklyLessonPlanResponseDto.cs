namespace BlumeBee.ModelDTO.Modules;

/// <summary>Typed response DTO for the weekly_lesson_plan module.</summary>
public sealed class WeeklyLessonPlanResponseDto
{
    public long? Id { get; set; }

    public int? AcademicSessionId { get; set; }

    public int? ClassId { get; set; }

    public DateOnly? WeekStartDate { get; set; }

    public DateOnly? WeekEndDate { get; set; }

    public string? Theme { get; set; }

    public string? SubTheme { get; set; }

    public int? DomainId { get; set; }

    public string? LearningObjective { get; set; }

    public string? PlannedActivity { get; set; }

    public string? CircleTimeTopic { get; set; }

    public string? RhymeStory { get; set; }

    public string? ArtCraftActivity { get; set; }

    public string? TeachingAidsRequired { get; set; }

    public long? TeacherStaffId { get; set; }

    public string? CompletionStatus { get; set; }

    public string? Remarks { get; set; }

}
