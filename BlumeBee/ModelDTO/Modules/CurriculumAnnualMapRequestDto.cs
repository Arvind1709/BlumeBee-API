using System.ComponentModel.DataAnnotations;

namespace BlumeBee.ModelDTO.Modules;

/// <summary>Request DTO for the curriculum_annual_map module. Database-generated id/timestamps are not client-controlled.</summary>
public sealed class CurriculumAnnualMapRequestDto
{
    public int? AcademicSessionId { get; set; }

    public int? ClassId { get; set; }

    [Required]
    public int? MonthNo { get; set; }

    [StringLength(150)]
    public string? Theme { get; set; }

    [StringLength(150)]
    public string? SubTheme { get; set; }

    public string? Remarks { get; set; }

}
