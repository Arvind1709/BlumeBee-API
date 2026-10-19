using BlumeBee.ModelDTO.Modules;
using Microsoft.AspNetCore.Mvc;
using BlumeBee.Services;

namespace BlumeBee.Controllers;

/// <summary>CRUD API for the incident_report table in the blumebee schema.</summary>
[ApiController]
[Route("api/[controller]")]
public sealed class IncidentReportController : CrudModuleController<IncidentReportRequestDto, IncidentReportResponseDto>
{
    public IncidentReportController(DynamicCrudService service) : base(service, "incident_report") { }
}
