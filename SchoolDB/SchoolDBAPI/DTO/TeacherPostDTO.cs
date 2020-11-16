using SchoolDBAPI.Library.Models;
using SchoolDBAPI.Library.Models.People;
using SchoolDBAPI.Library.Models.SchoolBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolDBAPI.DTO
{
    public class TeacherPostDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Gender Gender { get; set; }
        public decimal Salary { get; set; }
        public List<SubjectsTeachersCanTeach> SubjectTeachers { get; set; }
        public List<Course> CoursesTaught { get; set; }
    }
}
