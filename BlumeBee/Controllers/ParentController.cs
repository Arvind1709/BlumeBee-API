using BlumeBee.IRepository;
using BlumeBee.ModelDTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlumeBee.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParentController : ControllerBase
    {
        private readonly IParentRepository _repo;

        public ParentController(IParentRepository repo)
        {
            _repo = repo;
        }

        // 🔹 GET ALL
        // api/Parent
        [HttpGet]
        public IActionResult GetAll()
        {
            var data = _repo.GetAll();
            return Ok(data);
        }

        // 🔹 GET BY ID
        // api/Parent/5
        [HttpGet("{id}")]
        public IActionResult GetById(long id)
        {
            var data = _repo.GetById(id);

            if (data == null)
                return NotFound(new
                {
                    message = "Parent not found"
                });

            return Ok(data);
        }

        // 🔹 INSERT
        // api/Parent
        [HttpPost]
        public IActionResult Create([FromBody] ParentModelDTO model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var id = _repo.Insert(model);

            return Ok(new
            {
                message = "Parent created successfully",
                id = id
            });
        }

        // 🔹 UPDATE
        // api/Parent/5
        [HttpPut("{id}")]
        public IActionResult Update(long id, [FromBody] ParentModelDTO model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = _repo.Update(id, model);

            if (!result)
            {
                return NotFound(new
                {
                    message = "Parent not found"
                });
            }

            return Ok(new
            {
                message = "Parent updated successfully"
            });
        }

        // 🔹 DELETE
        // api/Parent/5
        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            var result = _repo.Delete(id);

            if (!result)
            {
                return NotFound(new
                {
                    message = "Parent not found"
                });
            }

            return Ok(new
            {
                message = "Parent deleted successfully"
            });
        }
    }
}
