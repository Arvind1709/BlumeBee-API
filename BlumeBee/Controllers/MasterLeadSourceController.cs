using BlumeBee.IRepository;
using BlumeBee.Model;
using BlumeBee.ModelDTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlumeBee.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MasterLeadSourceController : ControllerBase
    {
        private readonly IMasterLeadSourceRepository _repo;

        public MasterLeadSourceController(IMasterLeadSourceRepository repo)
        {
            _repo = repo;
        }

        [HttpGet("GetAllLeadSources")]
        public IActionResult GetAllLeadSources()
        {
            return Ok(_repo.GetAll());
        }

        [HttpGet("GetLeadSourceById/{id}")]
        public IActionResult GetLeadSourceById(int id)
        {
            return Ok(_repo.GetById(id));
        }

        [HttpPost("CreateLeadSource")]
        public IActionResult CreateLeadSource([FromBody] MasterLeadSourceRequestDto model)
        {
            return Ok(_repo.Insert(model.ToModel<MasterLeadSourceModel>()));
        }

        [HttpPut("UpdateLeadSource")]
        public IActionResult UpdateLeadSource([FromBody] MasterLeadSourceRequestDto model)
        {
            return Ok(_repo.Update(model.ToModel<MasterLeadSourceModel>()));
        }

        [HttpDelete("DeleteLeadSource/{id}")]
        public IActionResult DeleteLeadSource(int id)
        {
            return Ok(_repo.Delete(id));
        }
    }
}
