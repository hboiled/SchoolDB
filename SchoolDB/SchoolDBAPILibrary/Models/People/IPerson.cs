using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolDBAPI.Library.Models
{
    public interface IPerson
    {
        int Id { get; set; }
        string FirstName { get; set; }
        string LastName { get; set; }
        //DateTime BirthDate { get; set; }
        //Gender Gender { get; set; }
        List<Email> Emails { get; set; }
        List<PhoneNum> PhoneNums { get; set; }
        List<Address> Addresses { get; set; }
    }
}
