using BlumeBee.ModelDTO.Modules;
using Microsoft.AspNetCore.Mvc;
using BlumeBee.Services;

namespace BlumeBee.Controllers;

/// <summary>CRUD API for the payroll table in the blumebee schema.</summary>
[ApiController]
[Route("api/[controller]")]
public sealed class PayrollController : CrudModuleController<PayrollRequestDto, PayrollResponseDto>
{
    public PayrollController(DynamicCrudService service) : base(service, "payroll") { }
}
