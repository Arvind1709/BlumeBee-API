using BlumeBee.ModelDTO.Modules;
using Microsoft.AspNetCore.Mvc;
using BlumeBee.Services;

namespace BlumeBee.Controllers;

/// <summary>CRUD API for the student_intervention table in the blumebee schema.</summary>
[ApiController]
[Route("api/[controller]")]
public sealed class StudentInterventionController : CrudModuleController<StudentInterventionRequestDto, StudentInterventionResponseDto>
{
    public StudentInterventionController(DynamicCrudService service) : base(service, "student_intervention") { }
}
