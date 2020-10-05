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
        public DateTime BirthDate { get; set; }
        public int Age { 
            get
            {
                // null check
                DateTime n = DateTime.Now; 
                int age = n.Year - BirthDate.Year;

                // if this year's birthday hasn't been passed
                if (n.Month < BirthDate.Month || (n.Month == BirthDate.Month && n.Day < BirthDate.Day))
                {
                    age--;
                }                    

                return age;
            }
        }
        public List<Email> Emails { get; set; }
        public List<PhoneNum> PhoneNums { get; set; }
        public List<Address> Addresses { get; set; }
        
    }
}
