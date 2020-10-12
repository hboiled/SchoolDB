using SchoolDBAPI.Library.Models.SchoolBusiness;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolDBAPI.Library.Models.People
{
    public interface IStudent
    {
        // unique id for students, unrelated to db primary key
        int StudentId { get; set; }
        int Grade { get; set; }
        List<Enrollment> Enrollments { get; set; }
    }
}
