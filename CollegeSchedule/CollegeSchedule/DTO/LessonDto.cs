using CollegeSchedule.Models;

namespace CollegeSchedule.DTO
{
    public class LessonDto
    {
        public int LessonNumber { get; set; }
        public string? Time { get; set; }
        public string? Subject { get; set; }
        public string? Teacher { get; set; }
        public string? TeacherPosition { get; set; }
        public string? Classroom { get; set; }
        public string? Building { get; set; }
        public string? Address { get; set; }
        public Dictionary<LessonGroupPart, LessonPartDto?> GroupParts { get; set; } = new();
    }
}