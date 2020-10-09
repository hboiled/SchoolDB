using Microsoft.EntityFrameworkCore;
using SchoolDBAPI.Library.Models;
using SchoolDBAPI.Library.Models.People;
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

        //public DbSet<Address> Addresses { get; set; }
        public DbSet<Email> Emails { get; set; }
        public DbSet<PhoneNum> PhoneNumbers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // seed data

            modelBuilder.Entity<Student>()
                .HasData(
                new Student { Id = 1, FirstName = "Sam", LastName = "Lee", Grade = 100, StudentId = 203948 },
                new Student { Id = 2, FirstName = "Jacey", LastName = "Feng", Grade = 80, StudentId = 102942 },
                new Student { Id = 3, FirstName = "Brandon", LastName = "Lee", Grade = 100, StudentId = 293481 },
                new Student { Id = 4, FirstName = "Sue", LastName = "Jordan", Grade = 90, StudentId = 203941 },
                new Student { Id = 5, FirstName = "John", LastName = "Thomas", Grade = 80, StudentId = 920341 },
                new Student { Id = 6, FirstName = "Javier", LastName = "Mcgregor", Grade = 80, StudentId = 763343 }
                );

            modelBuilder.Entity<Teacher>()
                .HasData(
                new Teacher { Id = 1, FirstName = "Crowler", LastName = "Starks", Salary = 44000},
                new Teacher { Id = 2, FirstName = "Rima", LastName = "Irving", Salary = 42000 },
                new Teacher { Id = 3, FirstName = "Jack", LastName = "Bonilla", Salary = 43000 },
                new Teacher { Id = 4, FirstName = "Keisha", LastName = "Higgins", Salary = 41200 }
                );

            modelBuilder.Entity<Course>()
                .HasData(
                new Course { Id = 1, TeacherId = 1, Title = "Maths 101" },
                new Course { Id = 2, TeacherId = 2, Title = "Science 401" },
                new Course { Id = 3, TeacherId = 3, Title = "English 201" },
                new Course { Id = 4, TeacherId = 4, Title = "Sports 101" }
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
                new Email { Id = 1, EmailAddress = "203948@school.org", PersonId = 1, IsSchoolEmail = true},
                new Email { Id = 2, EmailAddress = "keira54@yahoo.com", PersonId = 2, IsSchoolEmail = false },
                new Email { Id = 3, EmailAddress = "wilmer02@hane.com", PersonId = 3, IsSchoolEmail = false },
                new Email { Id = 4, EmailAddress = "vesta.leffler@stracke.info", PersonId = 4, IsSchoolEmail = false },
                new Email { Id = 5, EmailAddress = "kelsie.lueilwitz@gmail.com", PersonId = 5, IsSchoolEmail = false },
                new Email { Id = 6, EmailAddress = "ressie49@bernier.com", PersonId = 2, IsSchoolEmail = false },
                new Email { Id = 7, EmailAddress = "dkuhlman@yahoo.com", PersonId = 1, IsSchoolEmail = false },
                new Email { Id = 8, EmailAddress = "rhoppe@gmail.com", PersonId = 6, IsSchoolEmail = false }
                );

            modelBuilder.Entity<PhoneNum>()
                .HasData(
                new PhoneNum { Id = 1, Owner = Owner.Self, PersonId = 1, IsMobile = true, Number = "040690660"},
                new PhoneNum { Id = 2, Owner = Owner.Relative, PersonId = 2, IsMobile = false, Number = "87164280" },
                new PhoneNum { Id = 3, Owner = Owner.Guardian, PersonId = 3, IsMobile = true, Number = "048877120" },
                new PhoneNum { Id = 4, Owner = Owner.Self, PersonId = 4, IsMobile = true, Number = "0406938120" },
                new PhoneNum { Id = 5, Owner = Owner.Work, PersonId = 5, IsMobile = true, Number = "0406936119" },
                new PhoneNum { Id = 6, Owner = Owner.Home, PersonId = 1, IsMobile = false, Number = "94104280" },
                new PhoneNum { Id = 7, Owner = Owner.Guardian, PersonId = 6, IsMobile = true, Number = "0416928190" },
                new PhoneNum { Id = 8, Owner = Owner.Self, PersonId = 3, IsMobile = true, Number = "0466138120" }
                );
        }
    }
}
