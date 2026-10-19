using System.ComponentModel.DataAnnotations;

namespace BlumeBee.ModelDTO.Modules;

/// <summary>Request DTO for the payroll module. Database-generated id/timestamps are not client-controlled.</summary>
public sealed class PayrollRequestDto
{
    [Required]
    public DateOnly? PayrollMonth { get; set; }

    [Required]
    public long? StaffId { get; set; }

    [Required]
    public decimal? GrossSalary { get; set; }

    public decimal? Deductions { get; set; }

    public decimal? LeaveDeduction { get; set; }

    public decimal? BonusIncentive { get; set; }

    [Required]
    public decimal? NetPay { get; set; }

    public DateOnly? PaymentDate { get; set; }

    public int? PaymentModeId { get; set; }

    public string? Remarks { get; set; }

}
