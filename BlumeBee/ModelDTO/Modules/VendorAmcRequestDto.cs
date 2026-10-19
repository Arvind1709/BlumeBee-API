using System.ComponentModel.DataAnnotations;

namespace BlumeBee.ModelDTO.Modules;

/// <summary>Request DTO for the vendor_amc module. Database-generated id/timestamps are not client-controlled.</summary>
public sealed class VendorAmcRequestDto
{
    [Required]
    [StringLength(150)]
    public string? VendorName { get; set; }

    [StringLength(100)]
    public string? ServiceType { get; set; }

    public DateOnly? ContractStartDate { get; set; }

    public DateOnly? ContractEndDate { get; set; }

    [StringLength(150)]
    public string? ContactPerson { get; set; }

    [StringLength(20)]
    public string? Phone { get; set; }

    public decimal? AmcAmount { get; set; }

    public DateOnly? RenewalDueDate { get; set; }

    [StringLength(50)]
    public string? Status { get; set; }

    public string? Remarks { get; set; }

}
