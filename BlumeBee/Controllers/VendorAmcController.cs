using BlumeBee.ModelDTO.Modules;
using Microsoft.AspNetCore.Mvc;
using BlumeBee.Services;

namespace BlumeBee.Controllers;

/// <summary>CRUD API for the vendor_amc table in the blumebee schema.</summary>
[ApiController]
[Route("api/[controller]")]
public sealed class VendorAmcController : CrudModuleController<VendorAmcRequestDto, VendorAmcResponseDto>
{
    public VendorAmcController(DynamicCrudService service) : base(service, "vendor_amc") { }
}
