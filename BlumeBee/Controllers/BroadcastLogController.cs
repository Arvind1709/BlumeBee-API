using BlumeBee.ModelDTO.Modules;
using Microsoft.AspNetCore.Mvc;
using BlumeBee.Services;

namespace BlumeBee.Controllers;

/// <summary>CRUD API for the broadcast_log table in the blumebee schema.</summary>
[ApiController]
[Route("api/[controller]")]
public sealed class BroadcastLogController : CrudModuleController<BroadcastLogRequestDto, BroadcastLogResponseDto>
{
    public BroadcastLogController(DynamicCrudService service) : base(service, "broadcast_log") { }
}
