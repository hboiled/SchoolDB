using SchoolDBAPI.DTO.BasicDetailDTO;
using SchoolDBAPI.Library.Models;
using SchoolDBAPI.Library.Models.People;
using System;
using System.Collections.Generic;

namespace SchoolDBAPI.DTO
{
    public class TeacherReadDTO
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public decimal Salary { get; set; }
        public Gender Gender { get; set; }
        public DateTime BirthDate { get; set; }
        public List<SubjectsTeachersCanTeach> SubjectTeachers { get; set; }
        public List<CourseBasicDetailDTO> CoursesTaught { get; set; }
        public List<Email> Emails { get; set; }
        public List<PhoneNum> PhoneNumbers { get; set; }
        public List<Address> Addresses { get; set; }
    }
}