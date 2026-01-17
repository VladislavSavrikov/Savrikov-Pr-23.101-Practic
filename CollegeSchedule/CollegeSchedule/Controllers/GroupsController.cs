using CollegeSchedule.Data;
using CollegeSchedule.Models;
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
                .Include(g => g.Specialty)  // Загружаем связанную специальность
                .OrderBy(g => g.GroupName)  // Сортируем по названию группы
                .Select(g => new
                {
                    g.GroupId,
                    g.GroupName,
                    g.Course,
                    Specialty = g.Specialty.Name  // Берем только название специальности
                })
                .ToListAsync();

            return Ok(groups);
        }
    }
}