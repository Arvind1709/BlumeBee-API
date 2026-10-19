using BlumeBee.IRepository;
using BlumeBee.Model;
using BlumeBee.ModelDTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlumeBee.Controllers
{
    // Add using Microsoft.AspNetCore.Authorization;
    // At controller level to require authentication for all actions:
    //[Authorize]
    //[Authorize(Roles = "Admin")]
    [Route("api/[controller]")]
    [ApiController]
    public class CenterController : ControllerBase
    {
        private readonly ICenterRepository _repo;

        public CenterController(ICenterRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        [Route("GetAllActiveCenters")]
        public IActionResult GetAllActive()
        {
            var data = _repo.GetAllActive();
            return Ok(data);
        }


        [HttpGet]
        [Route("GetAllNonActiveCenters")]
        public IActionResult GetAllNonActive()
        {
            var data = _repo.GetAllNonActive();
            return Ok(data);
        }
        //[HttpGet("{id}")]
        [HttpGet]
        [Route("GetCentersById/{id}")]
        public IActionResult GetById(int id)
        {
            var data = _repo.GetById(id);
            if (data == null) return NotFound();
            return Ok(data);
        }

        [HttpPost]
        [Route("CreateCenter")]
        public IActionResult Create(CenterRequestDto model)
        {
            var result = _repo.Create(model.ToModel<CenterModel>());
            return Ok(result);
        }

        [HttpPut]
        [Route("UpdateCenter")]
        public IActionResult Update(CenterRequestDto model)
        {
            var result = _repo.Update(model.ToModel<CenterModel>());
            return Ok(result);
        }

       // [HttpDelete("{id}")]
        [HttpDelete]
        [Route("RemoveCenter/{id}")]
        public IActionResult Delete(int id)
        {
            var result = _repo.Delete(id);
            return Ok(result);
        }
    }
}
