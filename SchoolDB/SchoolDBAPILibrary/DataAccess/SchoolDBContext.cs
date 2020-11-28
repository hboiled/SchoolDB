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

        public DbSet<Address> Addresses { get; set; }
        public DbSet<Email> Emails { get; set; }
        public DbSet<PhoneNum> PhoneNumbers { get; set; }

        public DbSet<SubjectsTeachersCanTeach> SubjectTeachers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Address>().
            //    HasOne<Teacher>(a => a.Teacher)
            //    .WithMany(t => t.Addresses)
            //    .HasForeignKey(a => a.StaffId);

            //modelBuilder.Entity<Email>().
            //    HasOne<Teacher>(a => a.Teacher)
            //    .WithMany(t => t.Emails)
            //    .HasForeignKey(a => a.StaffId);

            //modelBuilder.Entity<PhoneNum>().
            //    HasOne<Teacher>(a => a.Teacher)
            //    .WithMany(t => t.PhoneNums)
            //    .HasForeignKey(a => a.StaffId);


            SeedData(modelBuilder);   
        }

        private void SeedData(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>()
                .HasData(
                new Student
                {
                    Id = 1,
                    FirstName = "Sam",
                    LastName = "Lee",
                    Grade = 100,
                    StudentId = 203948,
                    Gender = Gender.Male,
                    BirthDate = new DateTime(1995, 5, 26),
                    PhotoImgPath = @"https://th.bing.com/th/id/OIP.SfAt4LpgCsJGCSD6AZffigHaHa?pid=Api&rs=1"
                },
                new Student
                {
                    Id = 2,
                    FirstName = "Jacey",
                    LastName = "Feng",
                    Grade = 80,
                    StudentId = 102942,
                    Gender = Gender.Female,
                    BirthDate = new DateTime(1996, 2, 7),
                    PhotoImgPath = @"https://th.bing.com/th/id/OIP.SfAt4LpgCsJGCSD6AZffigHaHa?pid=Api&rs=1"
                },
                new Student
                {
                    Id = 3,
                    FirstName = "Brandon",
                    LastName = "Lee",
                    Grade = 100,
                    StudentId = 293481,
                    Gender = Gender.Male,
                    BirthDate = new DateTime(2019, 1, 4),
                    PhotoImgPath = @"https://th.bing.com/th/id/OIP.SfAt4LpgCsJGCSD6AZffigHaHa?pid=Api&rs=1"
                },
                new Student
                {
                    Id = 4,
                    FirstName = "Sue",
                    LastName = "Jordan",
                    Grade = 90,
                    StudentId = 203941,
                    Gender = Gender.Female,
                    BirthDate = new DateTime(1925, 8, 12),
                    PhotoImgPath = @"https://th.bing.com/th/id/OIP.SfAt4LpgCsJGCSD6AZffigHaHa?pid=Api&rs=1"
                },
                new Student
                {
                    Id = 5,
                    FirstName = "John",
                    LastName = "Thomas",
                    Grade = 80,
                    StudentId = 920341,
                    Gender = Gender.Male,
                    BirthDate = new DateTime(1962, 12, 18),
                    PhotoImgPath = @"https://th.bing.com/th/id/OIP.SfAt4LpgCsJGCSD6AZffigHaHa?pid=Api&rs=1"
                },
                new Student
                {
                    Id = 6,
                    FirstName = "Javier",
                    LastName = "Mcgregor",
                    Grade = 80,
                    StudentId = 763343,
                    Gender = Gender.Male,
                    BirthDate = new DateTime(1988, 10, 7),
                    PhotoImgPath = @"https://th.bing.com/th/id/OIP.SfAt4LpgCsJGCSD6AZffigHaHa?pid=Api&rs=1"
                }
                );

            modelBuilder.Entity<Teacher>()
                .HasData(
                new Teacher { Id = 1, FirstName = "Crowler", LastName = "Starks", Salary = 44000, Gender = Gender.Male, BirthDate = new DateTime(1977,10,3), StaffId = "812JKQ" },
                new Teacher { Id = 2, FirstName = "Rima", LastName = "Irving", Salary = 42000, Gender = Gender.Female, BirthDate = new DateTime(1959, 12, 12), StaffId = "7Y14IJ" },
                new Teacher { Id = 3, FirstName = "Jack", LastName = "Bonilla", Salary = 43000, Gender = Gender.Male, BirthDate = new DateTime(1980, 6, 13), StaffId = "M728QQ" },
                new Teacher { Id = 4, FirstName = "Keisha", LastName = "Higgins", Salary = 41200, Gender = Gender.Female, BirthDate = new DateTime(1982, 1, 5), StaffId = "LM7J10" }
                );

            modelBuilder.Entity<SubjectsTeachersCanTeach>()
                .HasData(
                new SubjectsTeachersCanTeach { Id = 1, TeacherId = 1, Subject = Subject.Maths, CourseLevel = CourseLevel.Advanced },
                new SubjectsTeachersCanTeach { Id = 2, TeacherId = 2, Subject = Subject.Maths, CourseLevel = CourseLevel.Intermediate },
                new SubjectsTeachersCanTeach { Id = 3, TeacherId = 2, Subject = Subject.Science, CourseLevel = CourseLevel.Advanced },
                new SubjectsTeachersCanTeach { Id = 4, TeacherId = 3, Subject = Subject.English, CourseLevel = CourseLevel.Advanced },
                new SubjectsTeachersCanTeach { Id = 5, TeacherId = 3, Subject = Subject.Theatre, CourseLevel = CourseLevel.Beginner },
                new SubjectsTeachersCanTeach { Id = 6, TeacherId = 4, Subject = Subject.Sports, CourseLevel = CourseLevel.Intermediate },
                new SubjectsTeachersCanTeach { Id = 7, TeacherId = 4, Subject = Subject.Science, CourseLevel = CourseLevel.Advanced }
                );

            modelBuilder.Entity<Course>()
                .HasData(
                new Course { Id = 1, TeacherId = 1, Title = "Maths 101", Subject = Subject.Maths, CourseId = "M108THT", CourseLevel = CourseLevel.Beginner },
                new Course { Id = 2, TeacherId = 2, Title = "Science 401", Subject = Subject.Science, CourseId = "S238ICE", CourseLevel = CourseLevel.Intermediate },
                new Course { Id = 3, TeacherId = 3, Title = "English 201", Subject = Subject.English, CourseId = "E762LSH", CourseLevel = CourseLevel.Beginner },
                new Course { Id = 4, TeacherId = 4, Title = "Sports 101", Subject = Subject.Sports, CourseId = "H289OWJ", CourseLevel = CourseLevel.Beginner },
                new Course { Id = 5, TeacherId = 1, Title = "Algebra 101", Subject = Subject.Maths, CourseId = "N293OAI", CourseLevel = CourseLevel.Intermediate },
                new Course { Id = 6, TeacherId = 2, Title = "Geometry 101", Subject = Subject.Maths, CourseId = "Z918OIQ", CourseLevel = CourseLevel.Intermediate },
                new Course { Id = 7, TeacherId = 3, Title = "Drama 101", Subject = Subject.Theatre, CourseId = "L009JNA", CourseLevel = CourseLevel.Beginner },
                new Course { Id = 8, TeacherId = 4, Title = "Biology 301", Subject = Subject.Science, CourseId = "O019PKV", CourseLevel = CourseLevel.Advanced }
                );

            modelBuilder.Entity<Enrollment>()
                .HasData(
                new Enrollment { EnrollmentId = 1, CourseId = 1, StudentId = 1 },
                new Enrollment { EnrollmentId = 2, CourseId = 1, StudentId = 2 },
                new Enrollment { EnrollmentId = 3, CourseId = 2, StudentId = 3 },
                new Enrollment { EnrollmentId = 4, CourseId = 3, StudentId = 4 },
                new Enrollment { EnrollmentId = 5, CourseId = 4, StudentId = 1 },
                new Enrollment { EnrollmentId = 6, CourseId = 2, StudentId = 5 },
                new Enrollment { EnrollmentId = 7, CourseId = 4, StudentId = 6 }
                );

            modelBuilder.Entity<Email>()
                .HasData(
                new Email { Id = 1, EmailAddress = "203948@school.org", StudentId = 1, IsSchoolEmail = true, Owner = EmailOwner.School },
                new Email { Id = 2, EmailAddress = "keira54@yahoo.com", StudentId = 2, IsSchoolEmail = true, Owner = EmailOwner.School },
                new Email { Id = 3, EmailAddress = "wilmer02@hane.com", StudentId = 3, IsSchoolEmail = true, Owner = EmailOwner.School },
                new Email { Id = 4, EmailAddress = "vesta.leffler@stracke.info", StudentId = 4, IsSchoolEmail = true, Owner = EmailOwner.School },
                new Email { Id = 5, EmailAddress = "kelsie.lueilwitz@gmail.com", StudentId = 3, IsSchoolEmail = true, Owner = EmailOwner.School },
                new Email { Id = 6, EmailAddress = "ressie49@bernier.com", StudentId = 2, IsSchoolEmail = true, Owner = EmailOwner.School },
                new Email { Id = 7, EmailAddress = "dkuhlman@yahoo.com", StudentId = 1, IsSchoolEmail = true, Owner = EmailOwner.School },
                new Email { Id = 8, EmailAddress = "rhoppe@gmail.com", StudentId = 2, IsSchoolEmail = true, Owner = EmailOwner.School },
                new Email { Id = 9, EmailAddress = "sdfsdf.ew23t@gmail.com", StaffId = 4, IsSchoolEmail = true, Owner = EmailOwner.School },
                new Email { Id = 10, EmailAddress = "wgegweg@bernier.com", StaffId = 3, IsSchoolEmail = true, Owner = EmailOwner.School },
                new Email { Id = 11, EmailAddress = "sdfdsfs@yahoo.com", StaffId = 2, IsSchoolEmail = true, Owner = EmailOwner.School },
                new Email { Id = 12, EmailAddress = "wegewg@gmail.com", StaffId = 1, IsSchoolEmail = true, Owner = EmailOwner.School }
                );

            modelBuilder.Entity<PhoneNum>()
                .HasData(
                new PhoneNum { Id = 1, Owner = PhoneNumberOwner.Self, StudentId = 1, IsMobile = true, Number = "040690660", IsEmergency = true },
                new PhoneNum { Id = 2, Owner = PhoneNumberOwner.Relative, StudentId = 2, IsMobile = false, Number = "87164280", IsEmergency = true },
                new PhoneNum { Id = 3, Owner = PhoneNumberOwner.Guardian, StudentId = 3, IsMobile = true, Number = "048877120", IsEmergency = true },
                new PhoneNum { Id = 4, Owner = PhoneNumberOwner.Self, StudentId = 4, IsMobile = true, Number = "0406938120", IsEmergency = true },
                new PhoneNum { Id = 5, Owner = PhoneNumberOwner.Work, StudentId = 5, IsMobile = true, Number = "0406936119", IsEmergency = true },
                new PhoneNum { Id = 6, Owner = PhoneNumberOwner.Home, StudentId = 1, IsMobile = false, Number = "94104280", IsEmergency = true },
                new PhoneNum { Id = 7, Owner = PhoneNumberOwner.Guardian, StudentId = 6, IsMobile = true, Number = "0416928190", IsEmergency = true },
                new PhoneNum { Id = 8, Owner = PhoneNumberOwner.Self, StudentId = 3, IsMobile = true, Number = "0466138120", IsEmergency = true },
                new PhoneNum { Id = 9, Owner = PhoneNumberOwner.Self, StaffId = 1, IsMobile = true, Number = "0457203861", IsEmergency = true },
                new PhoneNum { Id = 10, Owner = PhoneNumberOwner.Self, StaffId = 2, IsMobile = true, Number = "0401357239", IsEmergency = true },
                new PhoneNum { Id = 11, Owner = PhoneNumberOwner.Self, StaffId = 3, IsMobile = true, Number = "0485106172", IsEmergency = true },
                new PhoneNum { Id = 12, Owner = PhoneNumberOwner.Self, StaffId = 4, IsMobile = true, Number = "0401967284", IsEmergency = true }
                );

            modelBuilder.Entity<Address>()
                .HasData(
                new Address
                {
                    Id = 1,
                    IsPrimary = true,
                    City = "Perth",
                    StreetAddress = "123 fake st",
                    Postcode = "5123",
                    Suburb = "Aowweq",
                    State = "Unwepq",
                    StudentId = 1
                },
                new Address
                {
                    Id = 2,
                    IsPrimary = true,
                    City = "Werth",
                    StreetAddress = "128 fake st",
                    Postcode = "8123",
                    Suburb = "Mngweq",
                    State = "Wpfepq",
                    StudentId = 2
                },
                new Address
                {
                    Id = 3,
                    IsPrimary = true,
                    City = "Zerth",
                    StreetAddress = "127 fake st",
                    Postcode = "9123",
                    Suburb = "Louweq",
                    State = "Nmeepq",
                    StudentId = 3
                },
                new Address
                {
                    Id = 4,
                    IsPrimary = true,
                    City = "Derth",
                    StreetAddress = "126 fake st",
                    Postcode = "0123",
                    Suburb = "Mzuweq",
                    State = "Hjkepq",
                    StudentId = 4
                },
                new Address
                {
                    Id = 5,
                    IsPrimary = true,
                    City = "Ferth",
                    StreetAddress = "125 fake st",
                    Postcode = "2123",
                    Suburb = "LLwweq",
                    State = "Qrwwepq",
                    StudentId = 5
                },
                new Address
                {
                    Id = 6,
                    IsPrimary = true,
                    City = "Merth",
                    StreetAddress = "123124 fake st",
                    Postcode = "4153",
                    Suburb = "Newg",
                    State = "FWca",
                    StudentId = 6
                },
                new Address
                {
                    Id = 7,
                    IsPrimary = true,
                    City = "Merth",
                    StreetAddress = "12344 fake st",
                    Postcode = "4100",
                    Suburb = "Grwh",
                    State = "Utjrt",
                    StaffId = 1
                },
                new Address
                {
                    Id = 8,
                    IsPrimary = true,
                    City = "Merth",
                    StreetAddress = "6124 fake st",
                    Postcode = "4993",
                    Suburb = "Bewe",
                    State = "GEGQ",
                    StaffId = 2
                },
                new Address
                {
                    Id = 9,
                    IsPrimary = true,
                    City = "Merth",
                    StreetAddress = "1224 fake st",
                    Postcode = "4163",
                    Suburb = "Acsg",
                    State = "Nher",
                    StaffId = 3
                },
                new Address
                {
                    Id = 10,
                    IsPrimary = true,
                    City = "Merth",
                    StreetAddress = "125 fake st",
                    Postcode = "4423",
                    Suburb = "Pofe",
                    State = "FWjieg",
                    StaffId = 4
                }
                );
        }
    }
}
