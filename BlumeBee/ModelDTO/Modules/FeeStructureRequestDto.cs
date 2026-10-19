using System.ComponentModel.DataAnnotations;

namespace BlumeBee.ModelDTO.Modules;

/// <summary>Request DTO for the fee_structure module. Database-generated id/timestamps are not client-controlled.</summary>
public sealed class FeeStructureRequestDto
{
    public int? CenterId { get; set; }

    public int? ProgramId { get; set; }

    public int? ClassId { get; set; }

    [Required]
    [StringLength(100)]
    public string? FeeHead { get; set; }

    [Required]
    public decimal? Amount { get; set; }

    [StringLength(50)]
    public string? Frequency { get; set; }

    [Required]
    public DateOnly? ApplicableFrom { get; set; }

    public DateOnly? ApplicableTo { get; set; }

}
