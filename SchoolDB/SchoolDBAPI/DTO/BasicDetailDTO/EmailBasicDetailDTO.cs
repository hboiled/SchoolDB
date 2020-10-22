using SchoolDBAPI.Library.Models;

namespace SchoolDBAPI.DTO
{
    public class EmailBasicDetailDTO
    {
        public string EmailAddress { get; set; }
        public bool IsSchoolEmail { get; set; } = true; // remove this?
        public EmailOwner Owner { get; set; }
    }
}