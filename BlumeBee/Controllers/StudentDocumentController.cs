using BlumeBee.ModelDTO.Modules;
using Microsoft.AspNetCore.Mvc;
using BlumeBee.Services;

namespace BlumeBee.Controllers;

/// <summary>CRUD API for the student_document table in the blumebee schema.</summary>
[ApiController]
[Route("api/[controller]")]
public sealed class StudentDocumentController : CrudModuleController<StudentDocumentRequestDto, StudentDocumentResponseDto>
{
    public StudentDocumentController(DynamicCrudService service) : base(service, "student_document") { }
}
