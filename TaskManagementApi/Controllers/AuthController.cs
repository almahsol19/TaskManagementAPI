using Microsoft.AspNetCore.Mvc;
using TaskManagementApi.Models;
using TaskManagementAPI.Data;
using TaskManagementAPI.Models;
using TaskManagementAPI.Services;

namespace TaskManagementAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly ApplicationDbContext _db;

        public AuthController(ApplicationDbContext db)
        {
            _db = db;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] User loginUser)
        {
           
            var user = _db.Users.SingleOrDefault(u => u.Username == loginUser.Username && u.Password == loginUser.Password);

            if (user == null)
                return Unauthorized("Invalid credentials 12");

            var token = TokenService.GenerateToken(user);

            return Ok(new { Token = token });
        }
    }
}
