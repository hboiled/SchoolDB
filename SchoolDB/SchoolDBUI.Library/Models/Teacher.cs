using SchoolDBUI.Library.Models.SchoolBusiness;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolDBUI.Library.Models
{
    public class Teacher
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
        public Gender Gender { get; set; }
        public decimal Salary { get; set; }
        public string StaffId { get; set; }
        public DateTime BirthDate { get; set; }
        public string PhotoImgPath { get; set; }
        public string BirthDateString
        {
            get
            {
                return BirthDate.ToShortDateString();
            }
        }
        public int Age
        {
            get
            {
                DateTime today = DateTime.Today;
                int age = today.Year - BirthDate.Year;

                if (today.Month < BirthDate.Month ||
                   ((today.Month == BirthDate.Month) && (today.Day < BirthDate.Day)))
                {
                    age--;
                }

                return age;
            }
        }
        public List<SubjectTeachersViewModel> SubjectTeachers { get; set; }

        public override bool Equals(object obj)
        {
            return obj is Teacher teacher &&
                   Id == teacher.Id &&
                   FirstName == teacher.FirstName &&
                   LastName == teacher.LastName &&
                   Gender == teacher.Gender &&
                   Salary == teacher.Salary;
        }

        public override int GetHashCode()
        {
            int hashCode = 821027007;
            hashCode = hashCode * -1521134295 + Id.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(FirstName);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(LastName);
            hashCode = hashCode * -1521134295 + Gender.GetHashCode();
            hashCode = hashCode * -1521134295 + Salary.GetHashCode();
            return hashCode;
        }
    }
}
