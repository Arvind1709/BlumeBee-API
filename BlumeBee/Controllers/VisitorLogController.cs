using BlumeBee.IRepository;
using BlumeBee.ModelDTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlumeBee.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VisitorLogController : ControllerBase
    {
        private readonly IVisitorLogRepository _repo;

        public VisitorLogController(IVisitorLogRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var data =  _repo.GetAll();
            return Ok(data);
        }

        [HttpGet("{id}")]
        public  IActionResult GetById(long id)
        {
            var data =  _repo.GetById(id);
            if (data == null) return NotFound();
            return Ok(data);
        }

        [HttpPost]
        public IActionResult Create(VisitorLogModelDto model)
        {
            var id =  _repo.Insert(model);
            return Ok(new { id });
        }

        [HttpPut("{id}")]
        public IActionResult Update(long id, VisitorLogModelDto model)
        {
            var result =  _repo.Update(id, model);
            if (!result) return NotFound();
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            var result =  _repo.Delete(id);
            if (!result) return NotFound();
            return Ok(result);
        }
    }
}
