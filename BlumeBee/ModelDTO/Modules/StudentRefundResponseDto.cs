namespace BlumeBee.ModelDTO.Modules;

/// <summary>Typed response DTO for the student_refund module.</summary>
public sealed class StudentRefundResponseDto
{
    public long? Id { get; set; }

    public string? RefundCode { get; set; }

    public long? StudentId { get; set; }

    public string? RefundReason { get; set; }

    public decimal? RefundAmount { get; set; }

    public string? ApprovalStatus { get; set; }

    public DateOnly? RefundDate { get; set; }

    public string? Remarks { get; set; }

}
