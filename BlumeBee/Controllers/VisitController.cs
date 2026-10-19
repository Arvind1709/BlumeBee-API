using BlumeBee.ModelDTO.Modules;
using Microsoft.AspNetCore.Mvc;
using BlumeBee.Services;

namespace BlumeBee.Controllers;

/// <summary>CRUD API for the visit table in the blumebee schema.</summary>
[ApiController]
[Route("api/[controller]")]
public sealed class VisitController : CrudModuleController<VisitRequestDto, VisitResponseDto>
{
    public VisitController(DynamicCrudService service) : base(service, "visit") { }
}
