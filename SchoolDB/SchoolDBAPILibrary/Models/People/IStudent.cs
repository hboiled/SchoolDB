using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolDBAPI.Library.Models.People
{
    public interface IStudent
    {
        int StudentId { get; set; }
        int Grade { get; set; }
    }
}
