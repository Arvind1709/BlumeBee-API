using BlumeBee.ModelDTO.Modules;
using Microsoft.AspNetCore.Mvc;
using BlumeBee.Services;

namespace BlumeBee.Controllers;

/// <summary>CRUD API for the student_parent table in the blumebee schema.</summary>
[ApiController]
[Route("api/[controller]")]
public sealed class StudentParentController : CrudModuleController<StudentParentRequestDto, StudentParentResponseDto>
{
    public StudentParentController(DynamicCrudService service) : base(service, "student_parent") { }
}
