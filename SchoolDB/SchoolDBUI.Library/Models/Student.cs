using SchoolDBUI.Library.Models.Contact;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolDBUI.Library.Models
{
    public class Student
    {
        public int Id { get; set; }        
        public string FirstName { get; set; }        
        public string LastName { get; set; }        
        public int StudentId { get; set; }        
        public int Grade { get; set; }
        public Gender Gender { get; set; }
        public DateTime BirthDate { get; set; }
        public string PhotoImgPath { get; set; }
        public string BirthDateString 
        { 
            get
            {
                return BirthDate.ToShortDateString();
            }
        }
        public int Age
        {
            get
            {
                DateTime today = DateTime.Today;
                int age = today.Year - BirthDate.Year;

                if (today.Month < BirthDate.Month ||
                   ((today.Month == BirthDate.Month) && (today.Day < BirthDate.Day)))
                {
                    age--;
                }

                return age;
            }
        }
        public string FullName
        {
            get
            {
                return $"{FirstName} {LastName}";
            }
        }
        public List<Course> CoursesEnrolledIn { get; set; }
        public List<Email> Emails { get; set; }
        public List<Address> Addresses { get; set; }
        public List<PhoneNum> PhoneNumbers { get; set; }
    }
}
