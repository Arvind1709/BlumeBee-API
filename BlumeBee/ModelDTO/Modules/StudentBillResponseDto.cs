namespace BlumeBee.ModelDTO.Modules;

/// <summary>Typed response DTO for the student_bill module.</summary>
public sealed class StudentBillResponseDto
{
    public long? Id { get; set; }

    public string? ReceiptInvoiceNo { get; set; }

    public long? StudentId { get; set; }

    public int? ClassId { get; set; }

    public DateOnly? FeeMonth { get; set; }

    public decimal? TotalFeeDue { get; set; }

    public decimal? DiscountAmount { get; set; }

    public decimal? NetDue { get; set; }

    public DateOnly? DueDate { get; set; }

    public decimal? AmountPaid { get; set; }

    public decimal? BalancePending { get; set; }

    public DateOnly? PaymentDate { get; set; }

    public int? PaymentModeId { get; set; }

    public int? PaymentStatusId { get; set; }

    public decimal? LateFee { get; set; }

    public string? ReminderStage { get; set; }

    public string? RiskFlag { get; set; }

    public string? Remarks { get; set; }

    public DateTime? CreatedAt { get; set; }

}
