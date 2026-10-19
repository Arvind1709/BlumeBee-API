using BlumeBee.ModelDTO.Modules;
using Microsoft.AspNetCore.Mvc;
using BlumeBee.Services;

namespace BlumeBee.Controllers;

/// <summary>CRUD API for the event_planner table in the blumebee schema.</summary>
[ApiController]
[Route("api/[controller]")]
public sealed class EventPlannerController : CrudModuleController<EventPlannerRequestDto, EventPlannerResponseDto>
{
    public EventPlannerController(DynamicCrudService service) : base(service, "event_planner") { }
}
