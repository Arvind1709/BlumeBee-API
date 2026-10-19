using BlumeBee.ModelDTO.Modules;
using Microsoft.AspNetCore.Mvc;
using BlumeBee.Services;

namespace BlumeBee.Controllers;

/// <summary>CRUD API for the safety_checklist table in the blumebee schema.</summary>
[ApiController]
[Route("api/[controller]")]
public sealed class SafetyChecklistController : CrudModuleController<SafetyChecklistRequestDto, SafetyChecklistResponseDto>
{
    public SafetyChecklistController(DynamicCrudService service) : base(service, "safety_checklist") { }
}
