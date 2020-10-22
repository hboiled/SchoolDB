using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolDBUI.Library.Models.Contact
{

    public class Email
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public string EmailAddress { get; set; }
        public bool IsSchoolEmail { get; set; } = true; // remove this?
        public EmailOwner Owner { get; set; }
        
    }
}
