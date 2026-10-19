using BlumeBee.ModelDTO.Modules;
using Microsoft.AspNetCore.Mvc;
using BlumeBee.Services;

namespace BlumeBee.Controllers;

/// <summary>CRUD API for the student_health_record table in the blumebee schema.</summary>
[ApiController]
[Route("api/[controller]")]
public sealed class StudentHealthRecordController : CrudModuleController<StudentHealthRecordRequestDto, StudentHealthRecordResponseDto>
{
    public StudentHealthRecordController(DynamicCrudService service) : base(service, "student_health_record") { }
}
