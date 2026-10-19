using BlumeBee.ModelDTO.Modules;
using Microsoft.AspNetCore.Mvc;
using BlumeBee.Services;

namespace BlumeBee.Controllers;

/// <summary>CRUD API for the student_bill table in the blumebee schema.</summary>
[ApiController]
[Route("api/[controller]")]
public sealed class StudentBillController : CrudModuleController<StudentBillRequestDto, StudentBillResponseDto>
{
    public StudentBillController(DynamicCrudService service) : base(service, "student_bill") { }
}
