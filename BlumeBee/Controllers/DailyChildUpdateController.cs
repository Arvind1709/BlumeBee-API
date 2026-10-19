using BlumeBee.ModelDTO.Modules;
using Microsoft.AspNetCore.Mvc;
using BlumeBee.Services;

namespace BlumeBee.Controllers;

/// <summary>CRUD API for the daily_child_update table in the blumebee schema.</summary>
[ApiController]
[Route("api/[controller]")]
public sealed class DailyChildUpdateController : CrudModuleController<DailyChildUpdateRequestDto, DailyChildUpdateResponseDto>
{
    public DailyChildUpdateController(DynamicCrudService service) : base(service, "daily_child_update") { }
}
