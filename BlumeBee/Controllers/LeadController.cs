using BlumeBee.IRepository;
using BlumeBee.Model;
using BlumeBee.ModelDTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlumeBee.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeadController : ControllerBase
    {
        private readonly ILeadRepository _repo;

        public LeadController(ILeadRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        [Route("GetAllLeads")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _repo.GetAllAsync());
        }

        [HttpGet("GetLeadById/{id}")]
        public async Task<IActionResult> GetById(long id)
        {
            var data = await _repo.GetByIdAsync(id);
            if (data == null) return NotFound();
            return Ok(data);
        }

        [HttpPost]
        [Route("CreateLead")]
        public async Task<IActionResult> Create(LeadRequestDto model)
        {
            var result = await _repo.CreateAsync(model.ToModel<LeadModel>());
            return Ok(result > 0 ? "Inserted" : "Failed");
        }

        [HttpPut("UpdateLead/{id}")]
        public async Task<IActionResult> Update(long id, LeadRequestDto model)
        {
            var entity = model.ToModel<LeadModel>();
            entity.Id = id;
            var result = await _repo.UpdateAsync(entity);
            return Ok(result > 0 ? "Updated" : "Failed");
        }

        [HttpDelete("DeleteLead/{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            var result = await _repo.DeleteAsync(id);
            return Ok(result > 0 ? "Deleted" : "Not Found");
        }
    }
}
