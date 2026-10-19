using System.ComponentModel.DataAnnotations;

namespace BlumeBee.ModelDTO.Modules;

/// <summary>Request DTO for the inventory_item module. Database-generated id/timestamps are not client-controlled.</summary>
public sealed class InventoryItemRequestDto
{
    [Required]
    [StringLength(30)]
    public string? ItemCode { get; set; }

    [Required]
    [StringLength(150)]
    public string? ItemName { get; set; }

    public int? CategoryId { get; set; }

    public decimal? Quantity { get; set; }

    [StringLength(30)]
    public string? Unit { get; set; }

    public DateOnly? PurchaseDate { get; set; }

    [StringLength(150)]
    public string? VendorName { get; set; }

    [StringLength(120)]
    public string? LocationName { get; set; }

    public int? ConditionId { get; set; }

    public DateOnly? MaintenanceDueDate { get; set; }

    public long? AssignedToStaffId { get; set; }

    [StringLength(50)]
    public string? Status { get; set; }

    public string? Remarks { get; set; }

}
