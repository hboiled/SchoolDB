using SchoolDBAPI.Library.Models.SchoolBusiness;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SchoolDBAPI.Library.Models.People
{
    public class SubjectsTeachersCanTeach
    {
        public int Id { get; set; }
        public Teacher Teacher { get; set; }
        [ForeignKey("Teacher")]
        public int TeacherId { get; set; }
        public Subject Subject { get; set; }
    }
}
