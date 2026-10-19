using BlumeBee.ModelDTO.Modules;
using Microsoft.AspNetCore.Mvc;
using BlumeBee.Services;

namespace BlumeBee.Controllers;

/// <summary>CRUD API for the weekly_lesson_plan table in the blumebee schema.</summary>
[ApiController]
[Route("api/[controller]")]
public sealed class WeeklyLessonPlanController : CrudModuleController<WeeklyLessonPlanRequestDto, WeeklyLessonPlanResponseDto>
{
    public WeeklyLessonPlanController(DynamicCrudService service) : base(service, "weekly_lesson_plan") { }
}
