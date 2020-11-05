using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolDBUI.Library.Models
{
    public class CourseSubmitDTO
    {
        public string Title { get; set; }
        public string CourseId { get; set; }
        public Subject Department { get; set; }
        public Teacher TeacherAssigned { get; set; }
        public List<Student> EnrolledStudents { get; set; } = new List<Student>();
    }
}
