using BlumeBee.ModelDTO.Modules;
using Microsoft.AspNetCore.Mvc;
using BlumeBee.Services;

namespace BlumeBee.Controllers;

/// <summary>CRUD API for the parent_engagement table in the blumebee schema.</summary>
[ApiController]
[Route("api/[controller]")]
public sealed class ParentEngagementController : CrudModuleController<ParentEngagementRequestDto, ParentEngagementResponseDto>
{
    public ParentEngagementController(DynamicCrudService service) : base(service, "parent_engagement") { }
}
