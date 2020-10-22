using SchoolDBAPI.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolDBAPI.DTO
{
    public class PhoneNumBasicDetailDTO
    {
        public string Number { get; set; }
        public PhoneNumberOwner Owner { get; set; }
        public bool IsMobile { get; set; }
        public bool IsEmergency { get; set; }
    }
}
