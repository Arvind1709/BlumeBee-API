using System.ComponentModel.DataAnnotations;

namespace BlumeBee.ModelDTO.Modules;

/// <summary>Request DTO for the student_discount module. Database-generated id/timestamps are not client-controlled.</summary>
public sealed class StudentDiscountRequestDto
{
    [Required]
    public long? StudentId { get; set; }

    [StringLength(100)]
    public string? DiscountType { get; set; }

    public decimal? DiscountValue { get; set; }

    public decimal? DiscountPercent { get; set; }

    public long? ApprovedByStaffId { get; set; }

    public DateOnly? EffectiveFrom { get; set; }

    public DateOnly? EffectiveTo { get; set; }

    public string? Remarks { get; set; }

}
