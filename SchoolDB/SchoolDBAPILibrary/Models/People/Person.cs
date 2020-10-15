using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolDBAPI.Library.Models
{
    public abstract class Person : IPerson
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { 
            get
            {
                return $"{FirstName} {LastName}";
            }
        }
        //public DateTime BirthDate { get; set; }
        public List<Email> Emails { get; set; }
        public List<PhoneNum> PhoneNums { get; set; }
        public List<Address> Addresses { get; set; }

        //public List<Email> Emails { get; set; }
        //public List<PhoneNum> PhoneNums { get; set; }
        //public List<Address> Addresses { get; set; }

    }
}
