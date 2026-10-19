using BlumeBee.ModelDTO.Modules;
using Microsoft.AspNetCore.Mvc;
using BlumeBee.Services;

namespace BlumeBee.Controllers;

/// <summary>CRUD API for the student_ledger table in the blumebee schema.</summary>
[ApiController]
[Route("api/[controller]")]
public sealed class StudentLedgerController : CrudModuleController<StudentLedgerRequestDto, StudentLedgerResponseDto>
{
    public StudentLedgerController(DynamicCrudService service) : base(service, "student_ledger") { }
}
