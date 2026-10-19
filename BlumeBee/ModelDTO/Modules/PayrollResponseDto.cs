namespace BlumeBee.ModelDTO.Modules;

/// <summary>Typed response DTO for the payroll module.</summary>
public sealed class PayrollResponseDto
{
    public long? Id { get; set; }

    public DateOnly? PayrollMonth { get; set; }

    public long? StaffId { get; set; }

    public decimal? GrossSalary { get; set; }

    public decimal? Deductions { get; set; }

    public decimal? LeaveDeduction { get; set; }

    public decimal? BonusIncentive { get; set; }

    public decimal? NetPay { get; set; }

    public DateOnly? PaymentDate { get; set; }

    public int? PaymentModeId { get; set; }

    public string? Remarks { get; set; }

}
