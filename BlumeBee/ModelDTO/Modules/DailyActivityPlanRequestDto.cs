using System.ComponentModel.DataAnnotations;

namespace BlumeBee.ModelDTO.Modules;

/// <summary>Request DTO for the daily_activity_plan module. Database-generated id/timestamps are not client-controlled.</summary>
public sealed class DailyActivityPlanRequestDto
{
    [Required]
    public DateOnly? ActivityDate { get; set; }

    public int? ClassId { get; set; }

    public string? AssemblyCircleTime { get; set; }

    public string? MainThemeActivity { get; set; }

    public string? LanguageActivity { get; set; }

    public string? NumeracyActivity { get; set; }

    public string? ArtCraft { get; set; }

    public string? FreePlay { get; set; }

    public string? OutdoorPlay { get; set; }

    public string? SnackTime { get; set; }

    public string? StoryTime { get; set; }

    public string? DispersalNotes { get; set; }

    public string? TeacherRemarks { get; set; }

    public long? TeacherStaffId { get; set; }

}
