using SchoolDBAPI.Library.Models.SchoolBusiness;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolDBAPI.Library.Models.People
{
    public class Student : Person, IStudent
    {
        public int StudentId { get; set; }
        public int Grade { get; set; }
        public List<Enrollment> Enrollments { get; set; }
    }
}
