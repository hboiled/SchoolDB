using SchoolDBAPI.Library.Models.People;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolDBAPI.DTO
{
    public class EnrollmentReadDTO
    {
        public int EnrollmentId { get; set; }        
        public string StudentName { get; set; }
        public string CourseTitle { get; set; }
    }
}
