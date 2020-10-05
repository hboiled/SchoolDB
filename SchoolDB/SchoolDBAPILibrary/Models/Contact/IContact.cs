using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolDBAPI.Library.Models
{
    public interface IContact
    {
        int Id { get; set; }
        int PersonId { get; set; }
    }
}
