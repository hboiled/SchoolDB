using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolDBUI.Library.Models.SchoolBusiness
{
    public class SubjectTeachersViewModel
    {
        public int TeacherId { get; set; }
        public Subject Subject { get; set; }
        public CourseLevel CourseLevel { get; set; }

    }
}
