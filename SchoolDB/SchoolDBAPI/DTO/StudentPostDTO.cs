using SchoolDBAPI.Library.Models;
using SchoolDBAPI.Library.Models.SchoolBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolDBAPI.DTO
{
    public class StudentPostDTO
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Grade { get; set; }
        public DateTime BirthDate { get; set; }
        public Gender Gender { get; set; }
        public string PhotoImgPath { get; set; }
        public List<Course> CourseEnrollments { get; set; }
        public List<Email> Emails { get; set; }
        public List<PhoneNum> PhoneNums { get; set; }
        public List<Address> Addresses { get; set; }
    }
}
