using BlumeBee.ModelDTO.Modules;
using Microsoft.AspNetCore.Mvc;
using BlumeBee.Services;

namespace BlumeBee.Controllers;

/// <summary>CRUD API for the inventory_item table in the blumebee schema.</summary>
[ApiController]
[Route("api/[controller]")]
public sealed class InventoryItemController : CrudModuleController<InventoryItemRequestDto, InventoryItemResponseDto>
{
    public InventoryItemController(DynamicCrudService service) : base(service, "inventory_item") { }
}
