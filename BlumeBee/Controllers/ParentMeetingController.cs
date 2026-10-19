using BlumeBee.ModelDTO.Modules;
using Microsoft.AspNetCore.Mvc;
using BlumeBee.Services;

namespace BlumeBee.Controllers;

/// <summary>CRUD API for the parent_meeting table in the blumebee schema.</summary>
[ApiController]
[Route("api/[controller]")]
public sealed class ParentMeetingController : CrudModuleController<ParentMeetingRequestDto, ParentMeetingResponseDto>
{
    public ParentMeetingController(DynamicCrudService service) : base(service, "parent_meeting") { }
}
