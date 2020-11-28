using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SchoolDBAPI.Library.Migrations
{
    public partial class MajorRevamp2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    BirthDate = table.Column<DateTime>(nullable: false),
                    Gender = table.Column<int>(nullable: false),
                    Grade = table.Column<int>(nullable: false),
                    StudentId = table.Column<int>(nullable: false),
                    PhotoImgPath = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Teachers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    BirthDate = table.Column<DateTime>(nullable: false),
                    StaffId = table.Column<string>(nullable: true),
                    PhotoImgPath = table.Column<string>(nullable: true),
                    Gender = table.Column<int>(nullable: false),
                    Salary = table.Column<decimal>(type: "money", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teachers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentId = table.Column<int>(nullable: true),
                    StaffId = table.Column<int>(nullable: true),
                    StreetAddress = table.Column<string>(nullable: true),
                    Suburb = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    State = table.Column<string>(nullable: true),
                    Postcode = table.Column<string>(nullable: true),
                    IsPrimary = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Addresses_Teachers_StaffId",
                        column: x => x.StaffId,
                        principalTable: "Teachers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Addresses_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(nullable: true),
                    TeacherId = table.Column<int>(nullable: false),
                    Subject = table.Column<int>(nullable: false),
                    CourseId = table.Column<string>(nullable: true),
                    CourseLevel = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Courses_Teachers_TeacherId",
                        column: x => x.TeacherId,
                        principalTable: "Teachers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Emails",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentId = table.Column<int>(nullable: true),
                    StaffId = table.Column<int>(nullable: true),
                    EmailAddress = table.Column<string>(nullable: true),
                    IsSchoolEmail = table.Column<bool>(nullable: false),
                    Owner = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Emails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Emails_Teachers_StaffId",
                        column: x => x.StaffId,
                        principalTable: "Teachers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Emails_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PhoneNumbers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentId = table.Column<int>(nullable: true),
                    StaffId = table.Column<int>(nullable: true),
                    Number = table.Column<string>(nullable: true),
                    Owner = table.Column<int>(nullable: false),
                    IsMobile = table.Column<bool>(nullable: false),
                    IsEmergency = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhoneNumbers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PhoneNumbers_Teachers_StaffId",
                        column: x => x.StaffId,
                        principalTable: "Teachers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PhoneNumbers_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SubjectTeachers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TeacherId = table.Column<int>(nullable: false),
                    Subject = table.Column<int>(nullable: false),
                    CourseLevel = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubjectTeachers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubjectTeachers_Teachers_TeacherId",
                        column: x => x.TeacherId,
                        principalTable: "Teachers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Enrollments",
                columns: table => new
                {
                    EnrollmentId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentId = table.Column<int>(nullable: false),
                    CourseId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enrollments", x => x.EnrollmentId);
                    table.ForeignKey(
                        name: "FK_Enrollments_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Enrollments_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "BirthDate", "FirstName", "Gender", "Grade", "LastName", "PhotoImgPath", "StudentId" },
                values: new object[,]
                {
                    { 1, new DateTime(1995, 5, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sam", 0, 100, "Lee", "https://th.bing.com/th/id/OIP.SfAt4LpgCsJGCSD6AZffigHaHa?pid=Api&rs=1", 203948 },
                    { 2, new DateTime(1996, 2, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "Jacey", 1, 80, "Feng", "https://th.bing.com/th/id/OIP.SfAt4LpgCsJGCSD6AZffigHaHa?pid=Api&rs=1", 102942 },
                    { 3, new DateTime(2019, 1, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Brandon", 0, 100, "Lee", "https://th.bing.com/th/id/OIP.SfAt4LpgCsJGCSD6AZffigHaHa?pid=Api&rs=1", 293481 },
                    { 4, new DateTime(1925, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sue", 1, 90, "Jordan", "https://th.bing.com/th/id/OIP.SfAt4LpgCsJGCSD6AZffigHaHa?pid=Api&rs=1", 203941 },
                    { 5, new DateTime(1962, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "John", 0, 80, "Thomas", "https://th.bing.com/th/id/OIP.SfAt4LpgCsJGCSD6AZffigHaHa?pid=Api&rs=1", 920341 },
                    { 6, new DateTime(1988, 10, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "Javier", 0, 80, "Mcgregor", "https://th.bing.com/th/id/OIP.SfAt4LpgCsJGCSD6AZffigHaHa?pid=Api&rs=1", 763343 }
                });

            migrationBuilder.InsertData(
                table: "Teachers",
                columns: new[] { "Id", "BirthDate", "FirstName", "Gender", "LastName", "PhotoImgPath", "Salary", "StaffId" },
                values: new object[,]
                {
                    { 1, new DateTime(1977, 10, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Crowler", 0, "Starks", null, 44000m, "812JKQ" },
                    { 2, new DateTime(1959, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Rima", 1, "Irving", null, 42000m, "7Y14IJ" },
                    { 3, new DateTime(1980, 6, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "Jack", 0, "Bonilla", null, 43000m, "M728QQ" },
                    { 4, new DateTime(1982, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Keisha", 1, "Higgins", null, 41200m, "LM7J10" }
                });

            migrationBuilder.InsertData(
                table: "Addresses",
                columns: new[] { "Id", "City", "IsPrimary", "Postcode", "StaffId", "State", "StreetAddress", "StudentId", "Suburb" },
                values: new object[,]
                {
                    { 1, "Perth", true, "5123", null, "Unwepq", "123 fake st", 1, "Aowweq" },
                    { 6, "Merth", true, "4153", null, "FWca", "123124 fake st", 6, "Newg" },
                    { 7, "Merth", true, "4100", 1, "Utjrt", "12344 fake st", null, "Grwh" },
                    { 3, "Zerth", true, "9123", null, "Nmeepq", "127 fake st", 3, "Louweq" },
                    { 4, "Derth", true, "0123", null, "Hjkepq", "126 fake st", 4, "Mzuweq" },
                    { 8, "Merth", true, "4993", 2, "GEGQ", "6124 fake st", null, "Bewe" },
                    { 9, "Merth", true, "4163", 3, "Nher", "1224 fake st", null, "Acsg" },
                    { 10, "Merth", true, "4423", 4, "FWjieg", "125 fake st", null, "Pofe" },
                    { 2, "Werth", true, "8123", null, "Wpfepq", "128 fake st", 2, "Mngweq" },
                    { 5, "Ferth", true, "2123", null, "Qrwwepq", "125 fake st", 5, "LLwweq" }
                });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "CourseId", "CourseLevel", "Subject", "TeacherId", "Title" },
                values: new object[,]
                {
                    { 6, "Z918OIQ", 1, 0, 2, "Geometry 101" },
                    { 2, "S238ICE", 1, 2, 2, "Science 401" },
                    { 5, "N293OAI", 1, 0, 1, "Algebra 101" },
                    { 3, "E762LSH", 0, 1, 3, "English 201" },
                    { 1, "M108THT", 0, 0, 1, "Maths 101" },
                    { 4, "H289OWJ", 0, 11, 4, "Sports 101" },
                    { 7, "L009JNA", 0, 12, 3, "Drama 101" },
                    { 8, "O019PKV", 2, 2, 4, "Biology 301" }
                });

            migrationBuilder.InsertData(
                table: "Emails",
                columns: new[] { "Id", "EmailAddress", "IsSchoolEmail", "Owner", "StaffId", "StudentId" },
                values: new object[,]
                {
                    { 4, "vesta.leffler@stracke.info", true, 2, null, 4 },
                    { 9, "sdfsdf.ew23t@gmail.com", true, 2, 4, null },
                    { 1, "203948@school.org", true, 2, null, 1 },
                    { 7, "dkuhlman@yahoo.com", true, 2, null, 1 },
                    { 10, "wgegweg@bernier.com", true, 2, 3, null },
                    { 2, "keira54@yahoo.com", true, 2, null, 2 },
                    { 11, "sdfdsfs@yahoo.com", true, 2, 2, null },
                    { 8, "rhoppe@gmail.com", true, 2, null, 2 },
                    { 6, "ressie49@bernier.com", true, 2, null, 2 },
                    { 5, "kelsie.lueilwitz@gmail.com", true, 2, null, 3 },
                    { 3, "wilmer02@hane.com", true, 2, null, 3 },
                    { 12, "wegewg@gmail.com", true, 2, 1, null }
                });

            migrationBuilder.InsertData(
                table: "PhoneNumbers",
                columns: new[] { "Id", "IsEmergency", "IsMobile", "Number", "Owner", "StaffId", "StudentId" },
                values: new object[,]
                {
                    { 2, true, false, "87164280", 2, null, 2 },
                    { 7, true, true, "0416928190", 1, null, 6 },
                    { 1, true, true, "040690660", 0, null, 1 },
                    { 11, true, true, "0485106172", 0, 3, null },
                    { 3, true, true, "048877120", 1, null, 3 },
                    { 6, true, false, "94104280", 4, null, 1 },
                    { 4, true, true, "0406938120", 0, null, 4 },
                    { 10, true, true, "0401357239", 0, 2, null },
                    { 12, true, true, "0401967284", 0, 4, null },
                    { 9, true, true, "0457203861", 0, 1, null },
                    { 8, true, true, "0466138120", 0, null, 3 },
                    { 5, true, true, "0406936119", 3, null, 5 }
                });

            migrationBuilder.InsertData(
                table: "SubjectTeachers",
                columns: new[] { "Id", "CourseLevel", "Subject", "TeacherId" },
                values: new object[,]
                {
                    { 6, 1, 11, 4 },
                    { 7, 2, 2, 4 },
                    { 4, 2, 1, 3 },
                    { 3, 2, 2, 2 },
                    { 2, 1, 0, 2 },
                    { 5, 0, 12, 3 },
                    { 1, 2, 0, 1 }
                });

            migrationBuilder.InsertData(
                table: "Enrollments",
                columns: new[] { "EnrollmentId", "CourseId", "StudentId" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 1, 2 },
                    { 3, 2, 3 },
                    { 6, 2, 5 },
                    { 4, 3, 4 },
                    { 5, 4, 1 },
                    { 7, 4, 6 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_StaffId",
                table: "Addresses",
                column: "StaffId");

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_StudentId",
                table: "Addresses",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_Courses_TeacherId",
                table: "Courses",
                column: "TeacherId");

            migrationBuilder.CreateIndex(
                name: "IX_Emails_StaffId",
                table: "Emails",
                column: "StaffId");

            migrationBuilder.CreateIndex(
                name: "IX_Emails_StudentId",
                table: "Emails",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_Enrollments_CourseId",
                table: "Enrollments",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_Enrollments_StudentId",
                table: "Enrollments",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_PhoneNumbers_StaffId",
                table: "PhoneNumbers",
                column: "StaffId");

            migrationBuilder.CreateIndex(
                name: "IX_PhoneNumbers_StudentId",
                table: "PhoneNumbers",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_SubjectTeachers_TeacherId",
                table: "SubjectTeachers",
                column: "TeacherId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Addresses");

            migrationBuilder.DropTable(
                name: "Emails");

            migrationBuilder.DropTable(
                name: "Enrollments");

            migrationBuilder.DropTable(
                name: "PhoneNumbers");

            migrationBuilder.DropTable(
                name: "SubjectTeachers");

            migrationBuilder.DropTable(
                name: "Courses");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "Teachers");
        }
    }
}
