using SchoolDBUI.Library.Models.SchoolBusiness;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolDBUI.Library.Models
{
    public class Course
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public Teacher Teacher { get; set; }        
        public Subject Subject { get; set; }
        public string Department
        {
            get
            {
                return Subject.ToString();
            }
        }
        public string AssignedTeacher
        {
            get
            {
                return Teacher?.FullName;
            }
        }
        public string CourseId { get; set; }
        public CourseLevel CourseLevel { get; set; }
        public string StudentGrade { get; set; }
        public List<Student> Students { get; set; } = new List<Student>();
    }    
    
}
