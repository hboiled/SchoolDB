﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SchoolDBAPI.Library.DataAccess;

namespace SchoolDBAPI.Library.Migrations
{
    [DbContext(typeof(SchoolDBContext))]
    partial class SchoolDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SchoolDBAPI.Library.Models.Address", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsPrimary")
                        .HasColumnType("bit");

                    b.Property<string>("Postcode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("State")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StreetAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("StudentId")
                        .HasColumnType("int");

                    b.Property<string>("Suburb")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("StudentId");

                    b.ToTable("StudentAddresses");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            City = "Perth",
                            IsPrimary = true,
                            Postcode = "5123",
                            State = "Unwepq",
                            StreetAddress = "123 fake st",
                            StudentId = 1,
                            Suburb = "Aowweq"
                        },
                        new
                        {
                            Id = 2,
                            City = "Werth",
                            IsPrimary = true,
                            Postcode = "8123",
                            State = "Wpfepq",
                            StreetAddress = "128 fake st",
                            StudentId = 2,
                            Suburb = "Mngweq"
                        },
                        new
                        {
                            Id = 3,
                            City = "Zerth",
                            IsPrimary = true,
                            Postcode = "9123",
                            State = "Nmeepq",
                            StreetAddress = "127 fake st",
                            StudentId = 3,
                            Suburb = "Louweq"
                        },
                        new
                        {
                            Id = 4,
                            City = "Derth",
                            IsPrimary = true,
                            Postcode = "0123",
                            State = "Hjkepq",
                            StreetAddress = "126 fake st",
                            StudentId = 4,
                            Suburb = "Mzuweq"
                        },
                        new
                        {
                            Id = 5,
                            City = "Ferth",
                            IsPrimary = true,
                            Postcode = "2123",
                            State = "Qrwwepq",
                            StreetAddress = "125 fake st",
                            StudentId = 5,
                            Suburb = "LLwweq"
                        },
                        new
                        {
                            Id = 6,
                            City = "Merth",
                            IsPrimary = true,
                            Postcode = "4123",
                            State = "FWca",
                            StreetAddress = "124 fake st",
                            StudentId = 6,
                            Suburb = "Gweq"
                        });
                });

            modelBuilder.Entity("SchoolDBAPI.Library.Models.Email", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("EmailAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsSchoolEmail")
                        .HasColumnType("bit");

                    b.Property<int>("Owner")
                        .HasColumnType("int");

                    b.Property<int>("StudentId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("StudentId");

                    b.ToTable("StudentEmails");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            EmailAddress = "203948@school.org",
                            IsSchoolEmail = true,
                            Owner = 2,
                            StudentId = 1
                        },
                        new
                        {
                            Id = 2,
                            EmailAddress = "keira54@yahoo.com",
                            IsSchoolEmail = false,
                            Owner = 2,
                            StudentId = 2
                        },
                        new
                        {
                            Id = 3,
                            EmailAddress = "wilmer02@hane.com",
                            IsSchoolEmail = false,
                            Owner = 2,
                            StudentId = 3
                        },
                        new
                        {
                            Id = 4,
                            EmailAddress = "vesta.leffler@stracke.info",
                            IsSchoolEmail = false,
                            Owner = 2,
                            StudentId = 4
                        },
                        new
                        {
                            Id = 5,
                            EmailAddress = "kelsie.lueilwitz@gmail.com",
                            IsSchoolEmail = false,
                            Owner = 2,
                            StudentId = 5
                        },
                        new
                        {
                            Id = 6,
                            EmailAddress = "ressie49@bernier.com",
                            IsSchoolEmail = false,
                            Owner = 2,
                            StudentId = 2
                        },
                        new
                        {
                            Id = 7,
                            EmailAddress = "dkuhlman@yahoo.com",
                            IsSchoolEmail = false,
                            Owner = 2,
                            StudentId = 1
                        },
                        new
                        {
                            Id = 8,
                            EmailAddress = "rhoppe@gmail.com",
                            IsSchoolEmail = false,
                            Owner = 2,
                            StudentId = 6
                        });
                });

            modelBuilder.Entity("SchoolDBAPI.Library.Models.People.Student", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Gender")
                        .HasColumnType("int");

                    b.Property<int>("Grade")
                        .HasColumnType("int");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhotoImgPath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("StudentId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Students");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            BirthDate = new DateTime(1995, 5, 26, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "Sam",
                            Gender = 0,
                            Grade = 100,
                            LastName = "Lee",
                            PhotoImgPath = "https://th.bing.com/th/id/OIP.SfAt4LpgCsJGCSD6AZffigHaHa?pid=Api&rs=1",
                            StudentId = 203948
                        },
                        new
                        {
                            Id = 2,
                            BirthDate = new DateTime(1996, 2, 7, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "Jacey",
                            Gender = 1,
                            Grade = 80,
                            LastName = "Feng",
                            PhotoImgPath = "https://th.bing.com/th/id/OIP.SfAt4LpgCsJGCSD6AZffigHaHa?pid=Api&rs=1",
                            StudentId = 102942
                        },
                        new
                        {
                            Id = 3,
                            BirthDate = new DateTime(2019, 1, 4, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "Brandon",
                            Gender = 0,
                            Grade = 100,
                            LastName = "Lee",
                            PhotoImgPath = "https://th.bing.com/th/id/OIP.SfAt4LpgCsJGCSD6AZffigHaHa?pid=Api&rs=1",
                            StudentId = 293481
                        },
                        new
                        {
                            Id = 4,
                            BirthDate = new DateTime(1925, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "Sue",
                            Gender = 1,
                            Grade = 90,
                            LastName = "Jordan",
                            PhotoImgPath = "https://th.bing.com/th/id/OIP.SfAt4LpgCsJGCSD6AZffigHaHa?pid=Api&rs=1",
                            StudentId = 203941
                        },
                        new
                        {
                            Id = 5,
                            BirthDate = new DateTime(1962, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "John",
                            Gender = 0,
                            Grade = 80,
                            LastName = "Thomas",
                            PhotoImgPath = "https://th.bing.com/th/id/OIP.SfAt4LpgCsJGCSD6AZffigHaHa?pid=Api&rs=1",
                            StudentId = 920341
                        },
                        new
                        {
                            Id = 6,
                            BirthDate = new DateTime(1988, 10, 7, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "Javier",
                            Gender = 0,
                            Grade = 80,
                            LastName = "Mcgregor",
                            PhotoImgPath = "https://th.bing.com/th/id/OIP.SfAt4LpgCsJGCSD6AZffigHaHa?pid=Api&rs=1",
                            StudentId = 763343
                        });
                });

            modelBuilder.Entity("SchoolDBAPI.Library.Models.People.SubjectsTeachersCanTeach", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CourseLevel")
                        .HasColumnType("int");

                    b.Property<int>("Subject")
                        .HasColumnType("int");

                    b.Property<int>("TeacherId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TeacherId");

                    b.ToTable("SubjectTeachers");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CourseLevel = 2,
                            Subject = 0,
                            TeacherId = 1
                        },
                        new
                        {
                            Id = 2,
                            CourseLevel = 1,
                            Subject = 0,
                            TeacherId = 2
                        },
                        new
                        {
                            Id = 3,
                            CourseLevel = 2,
                            Subject = 2,
                            TeacherId = 2
                        },
                        new
                        {
                            Id = 4,
                            CourseLevel = 2,
                            Subject = 1,
                            TeacherId = 3
                        },
                        new
                        {
                            Id = 5,
                            CourseLevel = 0,
                            Subject = 12,
                            TeacherId = 3
                        },
                        new
                        {
                            Id = 6,
                            CourseLevel = 1,
                            Subject = 11,
                            TeacherId = 4
                        },
                        new
                        {
                            Id = 7,
                            CourseLevel = 2,
                            Subject = 2,
                            TeacherId = 4
                        });
                });

            modelBuilder.Entity("SchoolDBAPI.Library.Models.People.Teacher", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Gender")
                        .HasColumnType("int");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Salary")
                        .HasColumnType("money");

                    b.HasKey("Id");

                    b.ToTable("Teachers");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            FirstName = "Crowler",
                            Gender = 0,
                            LastName = "Starks",
                            Salary = 44000m
                        },
                        new
                        {
                            Id = 2,
                            FirstName = "Rima",
                            Gender = 1,
                            LastName = "Irving",
                            Salary = 42000m
                        },
                        new
                        {
                            Id = 3,
                            FirstName = "Jack",
                            Gender = 0,
                            LastName = "Bonilla",
                            Salary = 43000m
                        },
                        new
                        {
                            Id = 4,
                            FirstName = "Keisha",
                            Gender = 1,
                            LastName = "Higgins",
                            Salary = 41200m
                        });
                });

            modelBuilder.Entity("SchoolDBAPI.Library.Models.PhoneNum", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("IsEmergency")
                        .HasColumnType("bit");

                    b.Property<bool>("IsMobile")
                        .HasColumnType("bit");

                    b.Property<string>("Number")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Owner")
                        .HasColumnType("int");

                    b.Property<int>("StudentId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("StudentId");

                    b.ToTable("StudentPhoneNumbers");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            IsEmergency = true,
                            IsMobile = true,
                            Number = "040690660",
                            Owner = 0,
                            StudentId = 1
                        },
                        new
                        {
                            Id = 2,
                            IsEmergency = true,
                            IsMobile = false,
                            Number = "87164280",
                            Owner = 2,
                            StudentId = 2
                        },
                        new
                        {
                            Id = 3,
                            IsEmergency = true,
                            IsMobile = true,
                            Number = "048877120",
                            Owner = 1,
                            StudentId = 3
                        },
                        new
                        {
                            Id = 4,
                            IsEmergency = true,
                            IsMobile = true,
                            Number = "0406938120",
                            Owner = 0,
                            StudentId = 4
                        },
                        new
                        {
                            Id = 5,
                            IsEmergency = true,
                            IsMobile = true,
                            Number = "0406936119",
                            Owner = 3,
                            StudentId = 5
                        },
                        new
                        {
                            Id = 6,
                            IsEmergency = true,
                            IsMobile = false,
                            Number = "94104280",
                            Owner = 4,
                            StudentId = 1
                        },
                        new
                        {
                            Id = 7,
                            IsEmergency = true,
                            IsMobile = true,
                            Number = "0416928190",
                            Owner = 1,
                            StudentId = 6
                        },
                        new
                        {
                            Id = 8,
                            IsEmergency = true,
                            IsMobile = true,
                            Number = "0466138120",
                            Owner = 0,
                            StudentId = 3
                        });
                });

            modelBuilder.Entity("SchoolDBAPI.Library.Models.SchoolBusiness.Course", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CourseId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CourseLevel")
                        .HasColumnType("int");

                    b.Property<int>("Subject")
                        .HasColumnType("int");

                    b.Property<int>("TeacherId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("TeacherId");

                    b.ToTable("Courses");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CourseId = "M108THT",
                            CourseLevel = 0,
                            Subject = 0,
                            TeacherId = 1,
                            Title = "Maths 101"
                        },
                        new
                        {
                            Id = 2,
                            CourseId = "S238ICE",
                            CourseLevel = 1,
                            Subject = 2,
                            TeacherId = 2,
                            Title = "Science 401"
                        },
                        new
                        {
                            Id = 3,
                            CourseId = "E762LSH",
                            CourseLevel = 0,
                            Subject = 1,
                            TeacherId = 3,
                            Title = "English 201"
                        },
                        new
                        {
                            Id = 4,
                            CourseId = "H289OWJ",
                            CourseLevel = 0,
                            Subject = 11,
                            TeacherId = 4,
                            Title = "Sports 101"
                        },
                        new
                        {
                            Id = 5,
                            CourseId = "N293OAI",
                            CourseLevel = 1,
                            Subject = 0,
                            TeacherId = 1,
                            Title = "Algebra 101"
                        },
                        new
                        {
                            Id = 6,
                            CourseId = "Z918OIQ",
                            CourseLevel = 1,
                            Subject = 0,
                            TeacherId = 2,
                            Title = "Geometry 101"
                        },
                        new
                        {
                            Id = 7,
                            CourseId = "L009JNA",
                            CourseLevel = 0,
                            Subject = 12,
                            TeacherId = 3,
                            Title = "Drama 101"
                        },
                        new
                        {
                            Id = 8,
                            CourseId = "O019PKV",
                            CourseLevel = 2,
                            Subject = 2,
                            TeacherId = 4,
                            Title = "Biology 301"
                        });
                });

            modelBuilder.Entity("SchoolDBAPI.Library.Models.SchoolBusiness.Enrollment", b =>
                {
                    b.Property<int>("EnrollmentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CourseId")
                        .HasColumnType("int");

                    b.Property<int>("StudentId")
                        .HasColumnType("int");

                    b.HasKey("EnrollmentId");

                    b.HasIndex("CourseId");

                    b.HasIndex("StudentId");

                    b.ToTable("Enrollments");

                    b.HasData(
                        new
                        {
                            EnrollmentId = 1,
                            CourseId = 1,
                            StudentId = 1
                        },
                        new
                        {
                            EnrollmentId = 2,
                            CourseId = 1,
                            StudentId = 2
                        },
                        new
                        {
                            EnrollmentId = 3,
                            CourseId = 2,
                            StudentId = 3
                        },
                        new
                        {
                            EnrollmentId = 4,
                            CourseId = 3,
                            StudentId = 4
                        },
                        new
                        {
                            EnrollmentId = 5,
                            CourseId = 4,
                            StudentId = 1
                        },
                        new
                        {
                            EnrollmentId = 6,
                            CourseId = 2,
                            StudentId = 5
                        },
                        new
                        {
                            EnrollmentId = 7,
                            CourseId = 4,
                            StudentId = 6
                        });
                });

            modelBuilder.Entity("SchoolDBAPI.Library.Models.Address", b =>
                {
                    b.HasOne("SchoolDBAPI.Library.Models.People.Student", null)
                        .WithMany("Addresses")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SchoolDBAPI.Library.Models.Email", b =>
                {
                    b.HasOne("SchoolDBAPI.Library.Models.People.Student", null)
                        .WithMany("Emails")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SchoolDBAPI.Library.Models.People.SubjectsTeachersCanTeach", b =>
                {
                    b.HasOne("SchoolDBAPI.Library.Models.People.Teacher", "Teacher")
                        .WithMany()
                        .HasForeignKey("TeacherId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SchoolDBAPI.Library.Models.PhoneNum", b =>
                {
                    b.HasOne("SchoolDBAPI.Library.Models.People.Student", null)
                        .WithMany("PhoneNums")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SchoolDBAPI.Library.Models.SchoolBusiness.Course", b =>
                {
                    b.HasOne("SchoolDBAPI.Library.Models.People.Teacher", "Teacher")
                        .WithMany("CoursesTaught")
                        .HasForeignKey("TeacherId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SchoolDBAPI.Library.Models.SchoolBusiness.Enrollment", b =>
                {
                    b.HasOne("SchoolDBAPI.Library.Models.SchoolBusiness.Course", "Course")
                        .WithMany()
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SchoolDBAPI.Library.Models.People.Student", "Student")
                        .WithMany("Enrollments")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
