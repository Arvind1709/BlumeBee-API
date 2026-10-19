namespace BlumeBee.ModelDTO.Modules;

/// <summary>Typed response DTO for the vendor_amc module.</summary>
public sealed class VendorAmcResponseDto
{
    public long? Id { get; set; }

    public string? VendorName { get; set; }

    public string? ServiceType { get; set; }

    public DateOnly? ContractStartDate { get; set; }

    public DateOnly? ContractEndDate { get; set; }

    public string? ContactPerson { get; set; }

    public string? Phone { get; set; }

    public decimal? AmcAmount { get; set; }

    public DateOnly? RenewalDueDate { get; set; }

    public string? Status { get; set; }

    public string? Remarks { get; set; }

}
