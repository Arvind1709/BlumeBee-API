using Microsoft.AspNetCore.Mvc;
using Npgsql;
using BlumeBee.Services;

namespace BlumeBee.Controllers;

[ApiController]
public abstract class CrudModuleController<TRequestDto, TResponseDto> : ControllerBase
    where TRequestDto : class
    where TResponseDto : class, new()
{
    private readonly DynamicCrudService _service;
    private readonly string _table;

    protected CrudModuleController(DynamicCrudService service, string table)
    {
        _service = service;
        _table = table;
    }

    [HttpGet]
    public ActionResult<IReadOnlyList<TResponseDto>> GetAll()
    {
        try { return Ok(_service.GetAll<TResponseDto>(_table)); }
        catch (PostgresException ex) { return DatabaseError(ex); }
    }

    [HttpGet("{id:long}")]
    public ActionResult<TResponseDto> GetById(long id)
    {
        try
        {
            var item = _service.GetById<TResponseDto>(_table, id);
            if (item is null) return NotFound(new { message = $"Record {id} was not found." });
            return Ok(item);
        }
        catch (PostgresException ex) { return DatabaseError(ex); }
    }

    [HttpPost]
    public IActionResult Create([FromBody] TRequestDto request)
    {
        if (!ModelState.IsValid) return ValidationProblem(ModelState);
        try
        {
            var id = _service.Create(_table, request);
            return CreatedAtAction(nameof(GetById), new { id }, new { id, message = "Record created successfully." });
        }
        catch (PostgresException ex) { return DatabaseError(ex); }
        catch (ArgumentException ex) { return BadRequest(new { message = ex.Message }); }
    }

    [HttpPut("{id:long}")]
    public IActionResult Update(long id, [FromBody] TRequestDto request)
    {
        if (!ModelState.IsValid) return ValidationProblem(ModelState);
        try
        {
            if (!_service.Update(_table, id, request)) return NotFound(new { message = $"Record {id} was not found." });
            return Ok(new { id, message = "Record updated successfully." });
        }
        catch (PostgresException ex) { return DatabaseError(ex); }
        catch (ArgumentException ex) { return BadRequest(new { message = ex.Message }); }
    }

    [HttpDelete("{id:long}")]
    public IActionResult Delete(long id)
    {
        try
        {
            if (!_service.Delete(_table, id)) return NotFound(new { message = $"Record {id} was not found." });
            return NoContent();
        }
        catch (PostgresException ex) { return DatabaseError(ex); }
    }

    private ObjectResult DatabaseError(PostgresException ex)
    {
        // Do not expose SQL or connection details to API clients.
        var message = ex.SqlState switch
        {
            PostgresErrorCodes.UniqueViolation => "A record with the same unique value already exists.",
            PostgresErrorCodes.ForeignKeyViolation => "The request references a related record that does not exist or is still in use.",
            PostgresErrorCodes.NotNullViolation => "A required database field is missing.",
            PostgresErrorCodes.CheckViolation => "One or more values violate a database constraint.",
            _ => "The database could not complete the request. Check the submitted data and server logs."
        };
        return StatusCode(ex.SqlState is PostgresErrorCodes.UniqueViolation or PostgresErrorCodes.ForeignKeyViolation ? 409 : 400, new { message });
    }
}
