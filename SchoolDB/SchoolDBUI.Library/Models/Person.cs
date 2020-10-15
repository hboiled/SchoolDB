using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolDBUI.Library.Models
{
    public abstract class Person
    {
        public DateTime BirthDate { get; set; }
        public int Age
        {
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
    }
}
