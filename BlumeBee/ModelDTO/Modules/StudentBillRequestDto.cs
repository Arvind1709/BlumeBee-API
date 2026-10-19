using System.ComponentModel.DataAnnotations;

namespace BlumeBee.ModelDTO.Modules;

/// <summary>Request DTO for the student_bill module. Database-generated id/timestamps are not client-controlled.</summary>
public sealed class StudentBillRequestDto
{
    [Required]
    [StringLength(40)]
    public string? ReceiptInvoiceNo { get; set; }

    [Required]
    public long? StudentId { get; set; }

    public int? ClassId { get; set; }

    [Required]
    public DateOnly? FeeMonth { get; set; }

    [Required]
    public decimal? TotalFeeDue { get; set; }

    public decimal? DiscountAmount { get; set; }

    [Required]
    public decimal? NetDue { get; set; }

    [Required]
    public DateOnly? DueDate { get; set; }

    public decimal? AmountPaid { get; set; }

    [Required]
    public decimal? BalancePending { get; set; }

    public DateOnly? PaymentDate { get; set; }

    public int? PaymentModeId { get; set; }

    public int? PaymentStatusId { get; set; }

    public decimal? LateFee { get; set; }

    [StringLength(50)]
    public string? ReminderStage { get; set; }

    [StringLength(50)]
    public string? RiskFlag { get; set; }

    public string? Remarks { get; set; }

}
