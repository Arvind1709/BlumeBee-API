namespace BlumeBee.ModelDTO.Modules;

/// <summary>Typed response DTO for the inventory_item module.</summary>
public sealed class InventoryItemResponseDto
{
    public long? Id { get; set; }

    public string? ItemCode { get; set; }

    public string? ItemName { get; set; }

    public int? CategoryId { get; set; }

    public decimal? Quantity { get; set; }

    public string? Unit { get; set; }

    public DateOnly? PurchaseDate { get; set; }

    public string? VendorName { get; set; }

    public string? LocationName { get; set; }

    public int? ConditionId { get; set; }

    public DateOnly? MaintenanceDueDate { get; set; }

    public long? AssignedToStaffId { get; set; }

    public string? Status { get; set; }

    public string? Remarks { get; set; }

}
