using BlumeBee.ModelDTO.Modules;
using Microsoft.AspNetCore.Mvc;
using BlumeBee.Services;

namespace BlumeBee.Controllers;

/// <summary>CRUD API for the complaint table in the blumebee schema.</summary>
[ApiController]
[Route("api/[controller]")]
public sealed class ComplaintController : CrudModuleController<ComplaintRequestDto, ComplaintResponseDto>
{
    public ComplaintController(DynamicCrudService service) : base(service, "complaint") { }
}
