using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolDBAPI.Library.Models.People
{
    public interface ITeacher
    {
        Decimal Salary { get; set; }
        // rework to courses assigned to -> new model courses taught - list of
        List<Course> CoursesTaught { get; set; }
    }
}
