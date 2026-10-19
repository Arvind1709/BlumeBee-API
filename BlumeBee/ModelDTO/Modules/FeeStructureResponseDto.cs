namespace BlumeBee.ModelDTO.Modules;

/// <summary>Typed response DTO for the fee_structure module.</summary>
public sealed class FeeStructureResponseDto
{
    public long? Id { get; set; }

    public int? CenterId { get; set; }

    public int? ProgramId { get; set; }

    public int? ClassId { get; set; }

    public string? FeeHead { get; set; }

    public decimal? Amount { get; set; }

    public string? Frequency { get; set; }

    public DateOnly? ApplicableFrom { get; set; }

    public DateOnly? ApplicableTo { get; set; }

}
