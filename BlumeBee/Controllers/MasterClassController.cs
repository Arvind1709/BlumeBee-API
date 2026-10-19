using BlumeBee.IRepository;
using BlumeBee.Model;
using BlumeBee.ModelDTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlumeBee.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MasterClassController : ControllerBase
    {
        private readonly IMasterClassRepository _repo;

        public MasterClassController(IMasterClassRepository repo)
        {
            _repo = repo;
        }

        [HttpGet("GetAllClasses")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _repo.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var data = await _repo.GetByIdAsync(id);
            if (data == null) return NotFound();
            return Ok(data);
        }

        [HttpPost]
        public async Task<IActionResult> Create(MasterClassRequestDto model)
        {
            var result = await _repo.CreateAsync(model.ToModel<MasterClassModel>());
            return Ok(result > 0 ? "Inserted" : "Failed");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, MasterClassRequestDto model)
        {
            var entity = model.ToModel<MasterClassModel>();
            entity.Id = id;
            var result = await _repo.UpdateAsync(entity);
            return Ok(result > 0 ? "Updated" : "Failed");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _repo.DeleteAsync(id);
            return Ok(result > 0 ? "Deleted" : "Not Found");
        }
    }
}
