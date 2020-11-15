using SchoolDBAPI.Library.Models.People;
using SchoolDBAPI.Library.Models.SchoolBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolDBAPI.DTO
{
    public class CoursePostDTO
    {
        public string Title { get; set; }
        public string CourseId { get; set; }
        public Subject Department { get; set; }
        public Teacher TeacherAssigned { get; set; }
        public List<Student> EnrolledStudents { get; set; } = new List<Student>();
        public CourseLevel CourseLevel { get; set; }
    }
}
