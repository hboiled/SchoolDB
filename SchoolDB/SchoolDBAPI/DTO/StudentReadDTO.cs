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
        public int StudentId { get; set; }
        public int Grade { get; set; }
        public List<string> CoursesEnrolledIn { get; set; } = new List<string>();
        public List<string> Emails { get; set; } = new List<string>();
        public List<PhoneNumBasicDetailDTO> PhoneNumbers { get; set; } = new List<PhoneNumBasicDetailDTO>();
    }
}
