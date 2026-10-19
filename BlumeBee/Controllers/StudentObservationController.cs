using BlumeBee.ModelDTO.Modules;
using Microsoft.AspNetCore.Mvc;
using BlumeBee.Services;

namespace BlumeBee.Controllers;

/// <summary>CRUD API for the student_observation table in the blumebee schema.</summary>
[ApiController]
[Route("api/[controller]")]
public sealed class StudentObservationController : CrudModuleController<StudentObservationRequestDto, StudentObservationResponseDto>
{
    public StudentObservationController(DynamicCrudService service) : base(service, "student_observation") { }
}
