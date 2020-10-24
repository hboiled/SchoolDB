using SchoolDBUI.Library.Models.Contact;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolDBUI.Library.Models
{
    public class StudentSubmitDTO
    {
        // only used with put endpoint
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public int Grade { get; set; }
        public string PhotoImgPath { get; set; }
        public Gender Gender { get; set; }
        public List<Course> CourseEnrollments { get; set; }
        public List<Email> Emails { get; set; }
        public List<PhoneNum> PhoneNums { get; set; }
        public List<Address> Addresses { get; set; }
        
    }
}
