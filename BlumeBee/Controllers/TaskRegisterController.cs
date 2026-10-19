using BlumeBee.ModelDTO.Modules;
using Microsoft.AspNetCore.Mvc;
using BlumeBee.Services;

namespace BlumeBee.Controllers;

/// <summary>CRUD API for the task_register table in the blumebee schema.</summary>
[ApiController]
[Route("api/[controller]")]
public sealed class TaskRegisterController : CrudModuleController<TaskRegisterRequestDto, TaskRegisterResponseDto>
{
    public TaskRegisterController(DynamicCrudService service) : base(service, "task_register") { }
}
