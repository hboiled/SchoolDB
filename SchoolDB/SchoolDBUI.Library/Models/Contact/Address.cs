using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolDBUI.Library.Models.Contact
{
    public class Address
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public string StreetAddress { get; set; }
        public string Suburb { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Postcode { get; set; }
        public bool IsPrimary { get; set; }
        // prop for full address format
        public string FullAddress
        {
            get
            {
                return $"{StreetAddress}, {Suburb}, {City}, {State} {Postcode}";
            }
        }
        public string AddressStatus
        {
            get
            {
                return IsPrimary ? "Primary" : "Alternative";
            }
        }
    }
}
