using BlumeBee.ModelDTO.Modules;
using Microsoft.AspNetCore.Mvc;
using BlumeBee.Services;

namespace BlumeBee.Controllers;

/// <summary>CRUD API for the learning_outcome table in the blumebee schema.</summary>
[ApiController]
[Route("api/[controller]")]
public sealed class LearningOutcomeController : CrudModuleController<LearningOutcomeRequestDto, LearningOutcomeResponseDto>
{
    public LearningOutcomeController(DynamicCrudService service) : base(service, "learning_outcome") { }
}
