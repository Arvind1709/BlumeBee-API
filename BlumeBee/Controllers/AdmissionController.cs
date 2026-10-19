using BlumeBee.IRepository;
using BlumeBee.Model;
using BlumeBee.ModelDTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlumeBee.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdmissionController : ControllerBase
    {
        private readonly IAdmissionRepository _repo;

        public AdmissionController(IAdmissionRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
            => Ok(await _repo.GetAllAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(long id)
        {
            var data = await _repo.GetByIdAsync(id);
            return data == null ? NotFound() : Ok(data);
        }

        [HttpPost]
        public async Task<IActionResult> Create(AdmissionRequestDto model)
        {
            var result = await _repo.CreateAsync(model.ToModel<AdmissionModel>());
            return Ok(result > 0 ? "Inserted" : "Failed");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(long id, AdmissionRequestDto model)
        {
            var entity = model.ToModel<AdmissionModel>();
            entity.Id = id;
            var result = await _repo.UpdateAsync(entity);
            return Ok(result > 0 ? "Updated" : "Failed");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            var result = await _repo.DeleteAsync(id);
            return Ok(result > 0 ? "Deleted" : "Not Found");
        }
    }
}
