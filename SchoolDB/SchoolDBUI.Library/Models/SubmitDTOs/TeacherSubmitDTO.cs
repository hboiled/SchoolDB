using SchoolDBUI.Library.Models.SchoolBusiness;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolDBUI.Library.Models.SubmitDTOs
{
    public class TeacherSubmitDTO
    {
        //public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Gender Gender { get; set; }
        public decimal Salary { get; set; }
        public List<SubjectTeachersViewModel> SubjectTeachers { get; set; }
        public List<Course> CoursesTaught { get; set; }
    }
}
