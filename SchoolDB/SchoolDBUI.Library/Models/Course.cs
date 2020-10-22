using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolDBUI.Library.Models
{
    public class Course
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Teacher { get; set; }        
        public string Subject { get; set; }
        public string CourseId { get; set; }
        public string StudentGrade { get; set; }
        public List<string> Students { get; set; } = new List<string>();
    }    
    
}
