using System.ComponentModel.DataAnnotations;

namespace BlumeBee.ModelDTO.Modules;

/// <summary>Request DTO for the safety_checklist module. Database-generated id/timestamps are not client-controlled.</summary>
public sealed class SafetyChecklistRequestDto
{
    [StringLength(100)]
    public string? Area { get; set; }

    [StringLength(50)]
    public string? Status { get; set; }

    public string? IssueFound { get; set; }

    public string? CorrectiveAction { get; set; }

    public DateOnly? ClosureDate { get; set; }

    public string? Remarks { get; set; }

}
