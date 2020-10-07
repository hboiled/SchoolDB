using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolDBAPI.Library.Models.People
{
    public interface ITeacher
    {
        Decimal Salary { get; set; }
        List<Course> CoursesTaught { get; set; }
    }
}
