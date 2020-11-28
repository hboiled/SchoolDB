using SchoolDBAPI.Library.Models.People;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolDBAPI.Library.Models
{
    public enum EmailOwner
    {
        Personal,
        Guardian,
        School
    }
    public class Email
    {
        public int Id { get; set; }
        [ForeignKey("Student")]
        public int? StudentId { get; set; }
        [ForeignKey("Teacher")]
        public int? StaffId { get; set; } // shouled be nullable
        public Teacher Teacher { get; set; } // used by fluent api to establish one-to-many
        public Student Student { get; set; }
        public string EmailAddress { get; set; }
        public bool IsSchoolEmail { get; set; }
        public EmailOwner Owner { get; set; }
    }
}