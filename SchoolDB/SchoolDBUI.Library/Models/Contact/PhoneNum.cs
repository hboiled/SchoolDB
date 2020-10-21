using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolDBUI.Library.Models.Contact
{
    public class PhoneNum
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public string Number { get; set; }
        public PhoneNumberOwner Owner { get; set; }
        public bool IsMobile { get; set; }
        public bool IsEmergency { get; set; }
        public string Emergency
        {
            get
            {
                return IsEmergency ? "E" : "C";
            }
        }
        public string Mobile
        {
            get
            {
                return IsMobile ? "M" : "L";
            }
        }
    }
}
