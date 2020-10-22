using SchoolDBAPI.DTO.BasicDetailDTO;
using SchoolDBAPI.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolDBAPI.DTO
{
    public class StudentReadDTO
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public int StudentId { get; set; }
        public int Grade { get; set; }
        public Gender Gender { get; set; }
        public List<CourseBasicDetailDTO> CoursesEnrolledIn { get; set; }
        public List<EmailBasicDetailDTO> Emails { get; set; }
        public List<AddressBasicDetailDTO> Addresses { get; set; }
        public List<PhoneNumBasicDetailDTO> PhoneNumbers { get; set; }
    }
}
