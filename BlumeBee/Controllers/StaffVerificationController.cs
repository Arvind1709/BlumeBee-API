using BlumeBee.ModelDTO.Modules;
using Microsoft.AspNetCore.Mvc;
using BlumeBee.Services;

namespace BlumeBee.Controllers;

/// <summary>CRUD API for the staff_verification table in the blumebee schema.</summary>
[ApiController]
[Route("api/[controller]")]
public sealed class StaffVerificationController : CrudModuleController<StaffVerificationRequestDto, StaffVerificationResponseDto>
{
    public StaffVerificationController(DynamicCrudService service) : base(service, "staff_verification") { }
}
