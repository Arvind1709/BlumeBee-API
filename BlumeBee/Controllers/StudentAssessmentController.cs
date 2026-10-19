using BlumeBee.ModelDTO.Modules;
using Microsoft.AspNetCore.Mvc;
using BlumeBee.Services;

namespace BlumeBee.Controllers;

/// <summary>CRUD API for the student_assessment table in the blumebee schema.</summary>
[ApiController]
[Route("api/[controller]")]
public sealed class StudentAssessmentController : CrudModuleController<StudentAssessmentRequestDto, StudentAssessmentResponseDto>
{
    public StudentAssessmentController(DynamicCrudService service) : base(service, "student_assessment") { }
}
