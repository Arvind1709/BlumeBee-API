using BlumeBee.ModelDTO.Modules;
using Microsoft.AspNetCore.Mvc;
using BlumeBee.Services;

namespace BlumeBee.Controllers;

/// <summary>CRUD API for the daily_activity_plan table in the blumebee schema.</summary>
[ApiController]
[Route("api/[controller]")]
public sealed class DailyActivityPlanController : CrudModuleController<DailyActivityPlanRequestDto, DailyActivityPlanResponseDto>
{
    public DailyActivityPlanController(DynamicCrudService service) : base(service, "daily_activity_plan") { }
}
