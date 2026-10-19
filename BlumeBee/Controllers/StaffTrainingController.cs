using BlumeBee.ModelDTO.Modules;
using Microsoft.AspNetCore.Mvc;
using BlumeBee.Services;

namespace BlumeBee.Controllers;

/// <summary>CRUD API for the staff_training table in the blumebee schema.</summary>
[ApiController]
[Route("api/[controller]")]
public sealed class StaffTrainingController : CrudModuleController<StaffTrainingRequestDto, StaffTrainingResponseDto>
{
    public StaffTrainingController(DynamicCrudService service) : base(service, "staff_training") { }
}
