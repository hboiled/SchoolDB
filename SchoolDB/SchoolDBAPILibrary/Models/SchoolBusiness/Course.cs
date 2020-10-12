using SchoolDBAPI.Library.Models.People;
using System.Collections.Generic;

namespace SchoolDBAPI.Library.Models.SchoolBusiness
{
    public class Course
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int TeacherId { get; set; }
        public Teacher Teacher { get; set; } // is this really needed?
        public Subject Subject { get; set; }
    }
}