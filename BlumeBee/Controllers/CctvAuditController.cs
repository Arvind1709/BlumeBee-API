using BlumeBee.ModelDTO.Modules;
using Microsoft.AspNetCore.Mvc;
using BlumeBee.Services;

namespace BlumeBee.Controllers;

/// <summary>CRUD API for the cctv_audit table in the blumebee schema.</summary>
[ApiController]
[Route("api/[controller]")]
public sealed class CctvAuditController : CrudModuleController<CctvAuditRequestDto, CctvAuditResponseDto>
{
    public CctvAuditController(DynamicCrudService service) : base(service, "cctv_audit") { }
}
