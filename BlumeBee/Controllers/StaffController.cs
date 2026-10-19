using BlumeBee.IRepository;
using BlumeBee.ModelDTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Npgsql;

namespace BlumeBee.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StaffController : ControllerBase
    {
        private readonly IStaffRepository _repo;

        public StaffController(IStaffRepository repo)
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
                    message = "Staff not found"
                });
            }

            return Ok(data);
        }

        // 🔹 INSERT
        [HttpPost]
        public IActionResult Create([FromBody] StaffModelDTO model)
        {
            try
            {
                var id = _repo.Insert(model);

                return Ok(new
                {
                    message = "Staff created successfully",
                    id = id
                });
            }
            catch (PostgresException ex) when (ex.SqlState == "23505")
            {
                return BadRequest(new
                {
                    message = "Employee code already exists"
                });
            }
        }

        // 🔹 UPDATE
        [HttpPut("{id}")]
        public IActionResult Update(long id, [FromBody] StaffModelDTO model)
        {
            var result = _repo.Update(id, model);

            if (!result)
            {
                return NotFound(new
                {
                    message = "Staff not found"
                });
            }

            return Ok(new
            {
                message = "Staff updated successfully"
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
                    message = "Staff not found"
                });
            }

            return Ok(new
            {
                message = "Staff deleted successfully"
            });
        }
    }
}
