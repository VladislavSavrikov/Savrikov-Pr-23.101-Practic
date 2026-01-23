using CollegeSchedule.Data;
using CollegeSchedule.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CollegeSchedule.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GroupsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public GroupsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/groups
        [HttpGet]
        public async Task<IActionResult> GetAllGroups()
        {
            var groups = await _context.StudentGroups
                .Include(g => g.Specialty)
                .OrderBy(g => g.GroupName)
                .Select(g => new GroupDto
                {
                    GroupId = g.GroupId,
                    GroupName = g.GroupName,
                    Course = g.Course,
                    Specialty = g.Specialty.Name
                })
                .ToListAsync();

            return Ok(groups);
        }
    }
}