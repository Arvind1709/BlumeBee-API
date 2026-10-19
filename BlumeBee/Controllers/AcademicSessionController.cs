using BlumeBee.IRepository;
using BlumeBee.Model;
using BlumeBee.ModelDTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlumeBee.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AcademicSessionController : ControllerBase
    {
        private readonly IAcademicSessionRepository _repo;

        public AcademicSessionController(IAcademicSessionRepository repo)
        {
            _repo = repo;
        }

        [HttpGet("GetAllActiveSessions")]
        public IActionResult GetAllActive()
        {
            var data = _repo.GetAllActive();
            return Ok(data);
        }

        [HttpGet("GetAllNonActiveSessions")]
        public IActionResult GetAllNonActive()
        {
            var data = _repo.GetAllNonActive();
            return Ok(data);
        }

        [HttpGet("GetSessionById/{id}")]
        public IActionResult GetById(int id)
        {
            var data = _repo.GetById(id);
            if (data == null) return NotFound();
            return Ok(data);
        }

        [HttpPost("CreateSession")]
        public IActionResult Create(AcademicSessionRequestDto model)
        {
            var result = _repo.Create(model.ToModel<AcademicSessionModel>());
            return Ok(result);
        }

        [HttpPut("UpdateSession")]
        public IActionResult Update(AcademicSessionRequestDto model)
        {
            var result = _repo.Update(model.ToModel<AcademicSessionModel>());
            return Ok(result);
        }

        [HttpDelete("RemoveSession/{id}")]
        public IActionResult Delete(int id)
        {
            var result = _repo.Delete(id);
            return Ok(result);
        }
    }
}
