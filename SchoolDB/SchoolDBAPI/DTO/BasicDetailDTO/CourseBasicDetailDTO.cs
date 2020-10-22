using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolDBAPI.DTO.BasicDetailDTO
{
    public class CourseBasicDetailDTO
    {
        public string Title { get; set; }
        public string Teacher { get; set; }
        public string Subject { get; set; }
        public string CourseId { get; set; }
        public string StudentGrade { get; set; }
    }
}
