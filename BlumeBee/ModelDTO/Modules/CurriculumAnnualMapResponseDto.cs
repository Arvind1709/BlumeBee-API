namespace BlumeBee.ModelDTO.Modules;

/// <summary>Typed response DTO for the curriculum_annual_map module.</summary>
public sealed class CurriculumAnnualMapResponseDto
{
    public long? Id { get; set; }

    public int? AcademicSessionId { get; set; }

    public int? ClassId { get; set; }

    public int? MonthNo { get; set; }

    public string? Theme { get; set; }

    public string? SubTheme { get; set; }

    public string? Remarks { get; set; }

}
