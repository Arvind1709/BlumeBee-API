using BlumeBee.ModelDTO.Modules;
using Microsoft.AspNetCore.Mvc;
using BlumeBee.Services;

namespace BlumeBee.Controllers;

/// <summary>CRUD API for the medicine_administration table in the blumebee schema.</summary>
[ApiController]
[Route("api/[controller]")]
public sealed class MedicineAdministrationController : CrudModuleController<MedicineAdministrationRequestDto, MedicineAdministrationResponseDto>
{
    public MedicineAdministrationController(DynamicCrudService service) : base(service, "medicine_administration") { }
}
