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
    }
}
