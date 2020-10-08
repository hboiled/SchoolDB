using System.Collections.Generic;

namespace SchoolDBAPI.DTO
{
    public class TeacherReadDTO
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public decimal Salary { get; set; }
        public List<string> CoursesTaught { get; set; }
    }
}