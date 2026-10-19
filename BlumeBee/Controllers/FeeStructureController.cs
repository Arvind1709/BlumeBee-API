using BlumeBee.ModelDTO.Modules;
using Microsoft.AspNetCore.Mvc;
using BlumeBee.Services;

namespace BlumeBee.Controllers;

/// <summary>CRUD API for the fee_structure table in the blumebee schema.</summary>
[ApiController]
[Route("api/[controller]")]
public sealed class FeeStructureController : CrudModuleController<FeeStructureRequestDto, FeeStructureResponseDto>
{
    public FeeStructureController(DynamicCrudService service) : base(service, "fee_structure") { }
}
