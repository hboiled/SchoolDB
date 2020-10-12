using SchoolDBAPI.Library.Models.SchoolBusiness;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SchoolDBAPI.Library.Models.People
{
    public class Teacher : Person, ITeacher
    {
        public List<Course> CoursesTaught { get; set; }
        [Column(TypeName = "money")]
        public decimal Salary { get; set; }
    }
}
