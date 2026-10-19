using BlumeBee.ModelDTO.Modules;
using Microsoft.AspNetCore.Mvc;
using BlumeBee.Services;

namespace BlumeBee.Controllers;

/// <summary>CRUD API for the curriculum_annual_map table in the blumebee schema.</summary>
[ApiController]
[Route("api/[controller]")]
public sealed class CurriculumAnnualMapController : CrudModuleController<CurriculumAnnualMapRequestDto, CurriculumAnnualMapResponseDto>
{
    public CurriculumAnnualMapController(DynamicCrudService service) : base(service, "curriculum_annual_map") { }
}
