using SchoolDBAPI.Library.Models.People;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolDBAPI.Library.Models
{
    public class Address
    {
        public int Id { get; set; }
        [ForeignKey("Student")]
        public int? StudentId { get; set; } // should be nullable
        [ForeignKey("Teacher")]
        public int? StaffId { get; set; } // shouled be nullable
        public Teacher Teacher { get; set; } // used by fluent api to establish one-to-many
        public Student Student { get; set; }
        public string StreetAddress { get; set; }
        public string Suburb { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Postcode { get; set; }
        public bool IsPrimary { get; set; }
        

    }
}