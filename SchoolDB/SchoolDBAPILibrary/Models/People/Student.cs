using SchoolDBAPI.Library.Models.SchoolBusiness;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SchoolDBAPI.Library.Models.People
{
    public class Student
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public Gender Gender { get; set; }                
        public int Grade { get; set; }
        public int StudentId { get; set; }
        public string PhotoImgPath { get; set; } // temporary solution, find out how to store images
        public string FullName
        {
            get
            {
                return $"{FirstName} {LastName}";
            }
        }
        public List<Email> Emails { get; set; }
        public List<PhoneNum> PhoneNums { get; set; }
        public List<Address> Addresses { get; set; }        
        public List<Enrollment> Enrollments { get; set; }
    }
}
