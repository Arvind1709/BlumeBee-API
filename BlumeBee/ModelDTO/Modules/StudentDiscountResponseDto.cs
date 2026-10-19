namespace BlumeBee.ModelDTO.Modules;

/// <summary>Typed response DTO for the student_discount module.</summary>
public sealed class StudentDiscountResponseDto
{
    public long? Id { get; set; }

    public long? StudentId { get; set; }

    public string? DiscountType { get; set; }

    public decimal? DiscountValue { get; set; }

    public decimal? DiscountPercent { get; set; }

    public long? ApprovedByStaffId { get; set; }

    public DateOnly? EffectiveFrom { get; set; }

    public DateOnly? EffectiveTo { get; set; }

    public string? Remarks { get; set; }

}
