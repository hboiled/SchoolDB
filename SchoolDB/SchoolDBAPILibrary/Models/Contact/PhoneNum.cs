using SchoolDBAPI.Library.Models.People;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolDBAPI.Library.Models
{
    public enum PhoneNumberOwner
    {
        Self,
        Guardian,
        Relative,
        Work,
        Home
    }

    public class PhoneNum
    {
        public int Id { get; set; }
        [ForeignKey("Student")]
        public int? StudentId { get; set; }
        [ForeignKey("Teacher")]
        public int? StaffId { get; set; } // shouled be nullable
        public Teacher Teacher { get; set; } // used by fluent api to establish one-to-many
        public Student Student { get; set; }
        public string Number { get; set; }
        public PhoneNumberOwner Owner { get; set; }
        public bool IsMobile { get; set; }
        public bool IsEmergency { get; set; }
    }
}