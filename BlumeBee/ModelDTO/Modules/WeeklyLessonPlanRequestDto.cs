using System.ComponentModel.DataAnnotations;

namespace BlumeBee.ModelDTO.Modules;

/// <summary>Request DTO for the weekly_lesson_plan module. Database-generated id/timestamps are not client-controlled.</summary>
public sealed class WeeklyLessonPlanRequestDto
{
    public int? AcademicSessionId { get; set; }

    public int? ClassId { get; set; }

    [Required]
    public DateOnly? WeekStartDate { get; set; }

    [Required]
    public DateOnly? WeekEndDate { get; set; }

    [StringLength(150)]
    public string? Theme { get; set; }

    [StringLength(150)]
    public string? SubTheme { get; set; }

    public int? DomainId { get; set; }

    public string? LearningObjective { get; set; }

    public string? PlannedActivity { get; set; }

    public string? CircleTimeTopic { get; set; }

    public string? RhymeStory { get; set; }

    public string? ArtCraftActivity { get; set; }

    public string? TeachingAidsRequired { get; set; }

    public long? TeacherStaffId { get; set; }

    [StringLength(50)]
    public string? CompletionStatus { get; set; }

    public string? Remarks { get; set; }

}
