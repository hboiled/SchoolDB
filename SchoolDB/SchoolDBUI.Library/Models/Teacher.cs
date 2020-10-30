using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolDBUI.Library.Models
{
    public class Teacher
    {
        public int Id { get; set; }
        public string FullName { get; set; }

        public override bool Equals(object obj)
        {
            return obj is Teacher teacher &&
                   Id == teacher.Id &&
                   FullName == teacher.FullName;
        }

        public override int GetHashCode()
        {
            int hashCode = 43716727;
            hashCode = hashCode * -1521134295 + Id.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(FullName);
            return hashCode;
        }
    }
}
