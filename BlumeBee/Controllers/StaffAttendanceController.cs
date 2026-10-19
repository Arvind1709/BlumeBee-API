using BlumeBee.IRepository;
using BlumeBee.ModelDTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Npgsql;

namespace BlumeBee.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StaffAttendanceController : ControllerBase
    {
        private readonly IStaffAttendanceRepository _repo;

        public StaffAttendanceController(IStaffAttendanceRepository repo)
        {
            _repo = repo;
        }

        // 🔹 GET ALL
        [HttpGet]
        public IActionResult GetAll()
        {
            var data = _repo.GetAll();
            return Ok(data);
        }

        // 🔹 GET BY ID
        [HttpGet("{id}")]
        public IActionResult GetById(long id)
        {
            var data = _repo.GetById(id);

            if (data == null)
            {
                return NotFound(new
                {
                    message = "Staff attendance not found"
                });
            }

            return Ok(data);
        }

        // 🔹 INSERT
        [HttpPost]
        public IActionResult Create([FromBody] StaffAttendanceModelDTO model)
        {
            try
            {
                var id = _repo.Insert(model);

                return Ok(new
                {
                    message = "Staff attendance added successfully",
                    id = id
                });
            }
            catch (PostgresException ex) when (ex.SqlState == "23505")
            {
                return BadRequest(new
                {
                    message = "Attendance already marked for this staff on this date"
                });
            }
        }

        // 🔹 UPDATE
        [HttpPut("{id}")]
        public IActionResult Update(long id, [FromBody] StaffAttendanceModelDTO model)
        {
            var result = _repo.Update(id, model);

            if (!result)
            {
                return NotFound(new
                {
                    message = "Staff attendance not found"
                });
            }

            return Ok(new
            {
                message = "Staff attendance updated successfully"
            });
        }

        // 🔹 DELETE
        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            var result = _repo.Delete(id);

            if (!result)
            {
                return NotFound(new
                {
                    message = "Staff attendance not found"
                });
            }

            return Ok(new
            {
                message = "Staff attendance deleted successfully"
            });
        }
    }
}
