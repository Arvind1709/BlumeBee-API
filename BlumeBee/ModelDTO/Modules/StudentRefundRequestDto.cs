using System.ComponentModel.DataAnnotations;

namespace BlumeBee.ModelDTO.Modules;

/// <summary>Request DTO for the student_refund module. Database-generated id/timestamps are not client-controlled.</summary>
public sealed class StudentRefundRequestDto
{
    [Required]
    [StringLength(30)]
    public string? RefundCode { get; set; }

    [Required]
    public long? StudentId { get; set; }

    public string? RefundReason { get; set; }

    [Required]
    public decimal? RefundAmount { get; set; }

    [StringLength(50)]
    public string? ApprovalStatus { get; set; }

    public DateOnly? RefundDate { get; set; }

    public string? Remarks { get; set; }

}
