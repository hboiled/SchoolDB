using SchoolDBUI.Library.Models.Contact;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolDBUI.Library.Models
{
    public class StudentSubmitDTO
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        //public int Grade { get; set; }
        public List<Course> CourseEnrollments { get; set; }
        public List<Email> Emails { get; set; }
        public List<PhoneNum> PhoneNums { get; set; }
        public List<Address> Addresses { get; set; }
        // Update db with gender first
        //public Gender Gender { get; set; }
    }
}
