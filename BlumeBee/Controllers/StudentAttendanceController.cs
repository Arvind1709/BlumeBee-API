using BlumeBee.IRepository;
using BlumeBee.ModelDTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlumeBee.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentAttendanceController : ControllerBase
    {
        private readonly IStudentAttendanceRepository _repo;

        public StudentAttendanceController(IStudentAttendanceRepository repo)
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
                    message = "Attendance record not found"
                });
            }

            return Ok(data);
        }

        // 🔹 INSERT
        [HttpPost]
        public IActionResult Create([FromBody] StudentAttendanceModelDTO model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var id = _repo.Insert(model);

                return Ok(new
                {
                    message = "Attendance added successfully",
                    id = id
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    message = ex.Message
                });
            }
        }

        // 🔹 UPDATE
        [HttpPut("{id}")]
        public IActionResult Update(long id, [FromBody] StudentAttendanceModelDTO model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = _repo.Update(id, model);

            if (!result)
            {
                return NotFound(new
                {
                    message = "Attendance record not found"
                });
            }

            return Ok(new
            {
                message = "Attendance updated successfully"
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
                    message = "Attendance record not found"
                });
            }

            return Ok(new
            {
                message = "Attendance deleted successfully"
            });
        }
    }
}
