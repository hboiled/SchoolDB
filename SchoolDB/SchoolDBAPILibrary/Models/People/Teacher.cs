using SchoolDBAPI.Library.Models.SchoolBusiness;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SchoolDBAPI.Library.Models.People
{
    public class Teacher
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        //public DateTime BirthDate { get; set; }
        public string FullName
        {
            get
            {
                return $"{FirstName} {LastName}";
            }
        }
        /// disable contacts until we create dbsets for teachercontacts
        /// currently by leaving these fields active, EF will wire the teacher table to studentcontacts
        //public List<Email> Emails { get; set; }
        //public List<PhoneNum> PhoneNums { get; set; }
        //public List<Address> Addresses { get; set; }
        public Gender Gender { get; set; }
        public List<Course> CoursesTaught { get; set; }
        [Column(TypeName = "money")]
        public decimal Salary { get; set; }
    }
}
