using BlumeBee.ModelDTO.Modules;
using Microsoft.AspNetCore.Mvc;
using BlumeBee.Services;

namespace BlumeBee.Controllers;

/// <summary>CRUD API for the authorized_pickup table in the blumebee schema.</summary>
[ApiController]
[Route("api/[controller]")]
public sealed class AuthorizedPickupController : CrudModuleController<AuthorizedPickupRequestDto, AuthorizedPickupResponseDto>
{
    public AuthorizedPickupController(DynamicCrudService service) : base(service, "authorized_pickup") { }
}
