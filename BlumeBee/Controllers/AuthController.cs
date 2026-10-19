using BlumeBee.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using BlumeBee.Model;

namespace BlumeBee.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly ITokenService _tokenService;
        public AuthController(ITokenService tokenService) => _tokenService = tokenService;

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginRequestDto req)
        {
            // TODO: validate credentials against your user store
            if (req.UserName == "admin" && req.Password == "password")
            {
                var token = _tokenService.GenerateToken("1", "admin", new[] { "Admin" });
                return Ok(new { token });
            }

            if (req.UserName == "staff" && req.Password == "password")
            {
                var token = _tokenService.GenerateToken("2", "staff", new[] { "Staff" });
                return Ok(new { token });
            }

            return Unauthorized();
        }
    }
}
