using BlumeBee.ModelDTO.Modules;
using Microsoft.AspNetCore.Mvc;
using BlumeBee.Services;

namespace BlumeBee.Controllers;

/// <summary>CRUD API for the parent_communication table in the blumebee schema.</summary>
[ApiController]
[Route("api/[controller]")]
public sealed class ParentCommunicationController : CrudModuleController<ParentCommunicationRequestDto, ParentCommunicationResponseDto>
{
    public ParentCommunicationController(DynamicCrudService service) : base(service, "parent_communication") { }
}
