using Microsoft.EntityFrameworkCore;
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

        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<Teacher> Teachers { get; set; }

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
        }
    }
}
