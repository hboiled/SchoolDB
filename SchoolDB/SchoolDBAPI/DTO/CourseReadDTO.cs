using SchoolDBAPI.DTO.BasicDetailDTO;
using SchoolDBAPI.Library.Models.SchoolBusiness;
using System.Collections.Generic;

namespace SchoolDBAPI.DTO
{
    public class CourseReadDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public TeacherBasicDetailDTO Teacher { get; set; }
        public List<StudentBasicDetailDTO> Students { get; set; } = new List<StudentBasicDetailDTO>();
        public string Subject { get; set; }
        public string CourseId { get; set; }
        public string CourseLevel { get; set; }
    }
}