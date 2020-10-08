using System.Collections.Generic;

namespace SchoolDBAPI.Library.Models.People
{
    public class Course
    {
        public int Id { get; set; }
        public string Title { get; set; }
        //public List<Enrollment> Enrollments { get; set; }
        public int TeacherId { get; set; }
        public Teacher Teacher { get; set; }
    }
}