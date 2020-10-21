using Microsoft.EntityFrameworkCore;
using SchoolDBAPI.Library.Models;
using SchoolDBAPI.Library.Models.People;
using SchoolDBAPI.Library.Models.SchoolBusiness;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolDBAPI.Library.DataAccess
{
    public class SchoolDBContext : DbContext
    {
        public SchoolDBContext(DbContextOptions opt) : base(opt)
        {

        }

        //*TODO: Staff and students merge into one table?

        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<Teacher> Teachers { get; set; }

        public DbSet<Address> StudentAddresses { get; set; }
        public DbSet<Email> StudentEmails { get; set; }
        public DbSet<PhoneNum> StudentPhoneNumbers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // seed data

            modelBuilder.Entity<Student>()
                .HasData(
                new Student { Id = 1, FirstName = "Sam", LastName = "Lee", Grade = 100, StudentId = 203948, Gender = Gender.Male },
                new Student { Id = 2, FirstName = "Jacey", LastName = "Feng", Grade = 80, StudentId = 102942, Gender = Gender.Female },
                new Student { Id = 3, FirstName = "Brandon", LastName = "Lee", Grade = 100, StudentId = 293481, Gender = Gender.Male },
                new Student { Id = 4, FirstName = "Sue", LastName = "Jordan", Grade = 90, StudentId = 203941, Gender = Gender.Female },
                new Student { Id = 5, FirstName = "John", LastName = "Thomas", Grade = 80, StudentId = 920341, Gender = Gender.Male },
                new Student { Id = 6, FirstName = "Javier", LastName = "Mcgregor", Grade = 80, StudentId = 763343, Gender = Gender.Male }
                );

            modelBuilder.Entity<Teacher>()
                .HasData(
                new Teacher { Id = 1, FirstName = "Crowler", LastName = "Starks", Salary = 44000 , Gender = Gender.Male},
                new Teacher { Id = 2, FirstName = "Rima", LastName = "Irving", Salary = 42000, Gender = Gender.Female },
                new Teacher { Id = 3, FirstName = "Jack", LastName = "Bonilla", Salary = 43000, Gender = Gender.Male },
                new Teacher { Id = 4, FirstName = "Keisha", LastName = "Higgins", Salary = 41200, Gender = Gender.Female }
                );

            modelBuilder.Entity<Course>()
                .HasData(
                new Course { Id = 1, TeacherId = 1, Title = "Maths 101", Subject = Subject.Maths, CourseId = "M108THT" },
                new Course { Id = 2, TeacherId = 2, Title = "Science 401", Subject = Subject.Science, CourseId = "S238ICE" },
                new Course { Id = 3, TeacherId = 3, Title = "English 201", Subject = Subject.English, CourseId = "E762LSH" },
                new Course { Id = 4, TeacherId = 4, Title = "Sports 101", Subject = Subject.Sports, CourseId = "H289OWJ" },
                new Course { Id = 5, TeacherId = 1, Title = "Algebra 101", Subject = Subject.Maths, CourseId = "N293OAI" },
                new Course { Id = 6, TeacherId = 2, Title = "Geometry 101", Subject = Subject.Maths, CourseId = "Z918OIQ" },
                new Course { Id = 7, TeacherId = 3, Title = "Drama 101", Subject = Subject.Theatre, CourseId = "L009JNA" },
                new Course { Id = 8, TeacherId = 4, Title = "Biology 301", Subject = Subject.Science, CourseId = "O019PKV" }
                );

            modelBuilder.Entity<Enrollment>()
                .HasData(
                new Enrollment { EnrollmentId = 1, CourseId = 1, StudentId = 1},
                new Enrollment { EnrollmentId = 2, CourseId = 1, StudentId = 2 },
                new Enrollment { EnrollmentId = 3, CourseId = 2, StudentId = 3 },
                new Enrollment { EnrollmentId = 4, CourseId = 3, StudentId = 4 },
                new Enrollment { EnrollmentId = 5, CourseId = 4, StudentId = 1 },
                new Enrollment { EnrollmentId = 6, CourseId = 2, StudentId = 5 },
                new Enrollment { EnrollmentId = 7, CourseId = 4, StudentId = 6 }
                );

            modelBuilder.Entity<Email>()
                .HasData(
                new Email { Id = 1, EmailAddress = "203948@school.org", StudentId = 1, IsSchoolEmail = true, Owner = EmailOwner.School},
                new Email { Id = 2, EmailAddress = "keira54@yahoo.com", StudentId = 2, IsSchoolEmail = false, Owner = EmailOwner.School },
                new Email { Id = 3, EmailAddress = "wilmer02@hane.com", StudentId = 3, IsSchoolEmail = false, Owner = EmailOwner.School },
                new Email { Id = 4, EmailAddress = "vesta.leffler@stracke.info", StudentId = 4, IsSchoolEmail = false, Owner = EmailOwner.School },
                new Email { Id = 5, EmailAddress = "kelsie.lueilwitz@gmail.com", StudentId = 5, IsSchoolEmail = false, Owner = EmailOwner.School },
                new Email { Id = 6, EmailAddress = "ressie49@bernier.com", StudentId = 2, IsSchoolEmail = false, Owner = EmailOwner.School },
                new Email { Id = 7, EmailAddress = "dkuhlman@yahoo.com", StudentId = 1, IsSchoolEmail = false, Owner = EmailOwner.School },
                new Email { Id = 8, EmailAddress = "rhoppe@gmail.com", StudentId = 6, IsSchoolEmail = false, Owner = EmailOwner.School }
                );

            modelBuilder.Entity<PhoneNum>()
                .HasData(
                new PhoneNum { Id = 1, Owner = PhoneNumberOwner.Self, StudentId = 1, IsMobile = true, Number = "040690660", IsEmergency = true},
                new PhoneNum { Id = 2, Owner = PhoneNumberOwner.Relative, StudentId = 2, IsMobile = false, Number = "87164280", IsEmergency = true },
                new PhoneNum { Id = 3, Owner = PhoneNumberOwner.Guardian, StudentId = 3, IsMobile = true, Number = "048877120", IsEmergency = true },
                new PhoneNum { Id = 4, Owner = PhoneNumberOwner.Self, StudentId = 4, IsMobile = true, Number = "0406938120", IsEmergency = true },
                new PhoneNum { Id = 5, Owner = PhoneNumberOwner.Work, StudentId = 5, IsMobile = true, Number = "0406936119", IsEmergency = true },
                new PhoneNum { Id = 6, Owner = PhoneNumberOwner.Home, StudentId = 1, IsMobile = false, Number = "94104280", IsEmergency = true },
                new PhoneNum { Id = 7, Owner = PhoneNumberOwner.Guardian, StudentId = 6, IsMobile = true, Number = "0416928190", IsEmergency = true },
                new PhoneNum { Id = 8, Owner = PhoneNumberOwner.Self, StudentId = 3, IsMobile = true, Number = "0466138120", IsEmergency = true }
                );

            modelBuilder.Entity<Address>()
                .HasData(
                new Address { Id = 1, IsPrimary = true, City = "Perth", StreetAddress = "123 fake st", 
                    Postcode = "5123", Suburb = "Aowweq", State = "Unwepq", StudentId = 1},
                new Address { Id = 2, IsPrimary = true, City = "Werth", StreetAddress = "128 fake st", 
                    Postcode = "8123", Suburb = "Mngweq", State = "Wpfepq", StudentId = 1},
                new Address { Id = 3, IsPrimary = true, City = "Zerth", StreetAddress = "127 fake st", 
                    Postcode = "9123", Suburb = "Louweq", State = "Nmeepq", StudentId = 1},
                new Address { Id = 4, IsPrimary = true, City = "Derth", StreetAddress = "126 fake st", 
                    Postcode = "0123", Suburb = "Mzuweq", State = "Hjkepq", StudentId = 1},
                new Address { Id = 5, IsPrimary = true, City = "Ferth", StreetAddress = "125 fake st", 
                    Postcode = "2123", Suburb = "LLwweq", State = "Qrwwepq", StudentId = 1},
                new Address { Id = 6, IsPrimary = true, City = "Merth", StreetAddress = "124 fake st", 
                    Postcode = "4123", Suburb = "Gweq", State = "FWca", StudentId = 1}
                );
        }
    }
}
