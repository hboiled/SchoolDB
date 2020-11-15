using SchoolDBAPI.Library.Models.People;
using System.Collections.Generic;

namespace SchoolDBAPI.Library.Models.SchoolBusiness
{
    public class Course
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int TeacherId { get; set; }
        public Teacher Teacher { get; set; } 
        public Subject Subject { get; set; }
        public string CourseId { get; set; }
        public CourseLevel CourseLevel { get; set; }
    }
}