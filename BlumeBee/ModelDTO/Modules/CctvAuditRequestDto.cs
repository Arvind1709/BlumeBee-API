using System.ComponentModel.DataAnnotations;

namespace BlumeBee.ModelDTO.Modules;

/// <summary>Request DTO for the cctv_audit module. Database-generated id/timestamps are not client-controlled.</summary>
public sealed class CctvAuditRequestDto
{
    [Required]
    public DateOnly? AuditDate { get; set; }

    [StringLength(120)]
    public string? Area { get; set; }

    [StringLength(50)]
    public string? Status { get; set; }

    public string? IssueFound { get; set; }

    public string? CorrectiveAction { get; set; }

    public DateOnly? ClosureDate { get; set; }

    public string? Remarks { get; set; }

}
