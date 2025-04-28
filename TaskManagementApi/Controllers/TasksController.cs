using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaskManagementAPI.Data;
using TaskManagementAPI.Models;
using TaskManagementAPI.Services;

namespace TaskManagementAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TasksController : ControllerBase
    {
        private readonly AppDbContext _db;

        public TasksController(AppDbContext db)
        {
            _db = db;
        }

        private (string Username, string Role)? GetTokenInfo()
        {
            var token = Request.Headers["Authorization"].FirstOrDefault()?.Replace("Bearer ", "");
            if (string.IsNullOrEmpty(token)) return null;

            return TokenService.ValidateToken(token);
        }

        [HttpPost]
        public IActionResult CreateTask([FromBody] TaskItem task)
        {
            var tokenInfo = GetTokenInfo();
            if (tokenInfo == null) return Unauthorized();

            if (tokenInfo.Value.Role != Role.Admin.ToString())
                return Forbid();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _db.Tasks.Add(task);
            _db.SaveChanges();

            return CreatedAtAction(nameof(GetTaskById), new { id = task.Id }, task);
        }

        [HttpGet("{id}")]
        public IActionResult GetTaskById(int id)
        {
            var tokenInfo = GetTokenInfo();
            if (tokenInfo == null) return Unauthorized();

            var task = _db.Tasks.Include(t => t.AssignedUser).FirstOrDefault(t => t.Id == id);

            if (task == null)
                return NotFound();

            return Ok(task);
        }

        [HttpGet("user/{userId}")]
        public IActionResult GetTasksByUser(int userId)
        {
            var tokenInfo = GetTokenInfo();
            if (tokenInfo == null) return Unauthorized();

            var tasks = _db.Tasks.Where(t => t.UserId == userId).ToList();
            return Ok(tasks);
        }
    }
}
