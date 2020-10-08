using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolDBAPI.Library.Models.People
{
    public class Teacher : Person, ITeacher
    {
        public List<Course> CoursesTaught { get; set; }
        public decimal Salary { get; set; }
    }
}
