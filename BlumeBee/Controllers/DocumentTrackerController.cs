using BlumeBee.ModelDTO.Modules;
using Microsoft.AspNetCore.Mvc;
using BlumeBee.Services;

namespace BlumeBee.Controllers;

/// <summary>CRUD API for the document_tracker table in the blumebee schema.</summary>
[ApiController]
[Route("api/[controller]")]
public sealed class DocumentTrackerController : CrudModuleController<DocumentTrackerRequestDto, DocumentTrackerResponseDto>
{
    public DocumentTrackerController(DynamicCrudService service) : base(service, "document_tracker") { }
}
