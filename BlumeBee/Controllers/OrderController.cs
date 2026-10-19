using BlumeBee.IRepository;
using BlumeBee.Model;
using BlumeBee.ModelDTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlumeBee.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _service;

        public OrderController(IOrderService service)
        {
            _service = service;
        }

        [HttpPost("process")]
        public IActionResult Process(OrderRequestDto order)
        {
            var result = _service.ProcessOrder(order.ToModel<OrderModel>());
            return Ok(new { FinalAmount = result });
        }
    }
}
