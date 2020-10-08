using System.Collections.Generic;

namespace SchoolDBAPI.DTO
{
    public class CourseReadDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Teacher { get; set; }
        public List<string> Students { get; set; } = new List<string>();
    }
}