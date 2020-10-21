using Microsoft.EntityFrameworkCore.Migrations;

namespace SchoolDBAPI.Library.Migrations
{
    public partial class MajorRevamp : Migration
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
                    Gender = table.Column<int>(nullable: false),
                    StudentId = table.Column<int>(nullable: false),
                    Grade = table.Column<int>(nullable: false)
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
                    Gender = table.Column<int>(nullable: false),
                    Salary = table.Column<decimal>(type: "money", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teachers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StudentAddresses",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentId = table.Column<int>(nullable: false),
                    StreetAddress = table.Column<string>(nullable: true),
                    Suburb = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    State = table.Column<string>(nullable: true),
                    Postcode = table.Column<string>(nullable: true),
                    IsPrimary = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentAddresses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StudentAddresses_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StudentEmails",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentId = table.Column<int>(nullable: false),
                    EmailAddress = table.Column<string>(nullable: true),
                    IsSchoolEmail = table.Column<bool>(nullable: false),
                    Owner = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentEmails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StudentEmails_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StudentPhoneNumbers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentId = table.Column<int>(nullable: false),
                    Number = table.Column<string>(nullable: true),
                    Owner = table.Column<int>(nullable: false),
                    IsMobile = table.Column<bool>(nullable: false),
                    IsEmergency = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentPhoneNumbers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StudentPhoneNumbers_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                    CourseId = table.Column<string>(nullable: true)
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
                columns: new[] { "Id", "FirstName", "Gender", "Grade", "LastName", "StudentId" },
                values: new object[,]
                {
                    { 1, "Sam", 0, 100, "Lee", 203948 },
                    { 2, "Jacey", 1, 80, "Feng", 102942 },
                    { 3, "Brandon", 0, 100, "Lee", 293481 },
                    { 4, "Sue", 1, 90, "Jordan", 203941 },
                    { 5, "John", 0, 80, "Thomas", 920341 },
                    { 6, "Javier", 0, 80, "Mcgregor", 763343 }
                });

            migrationBuilder.InsertData(
                table: "Teachers",
                columns: new[] { "Id", "FirstName", "Gender", "LastName", "Salary" },
                values: new object[,]
                {
                    { 1, "Crowler", 0, "Starks", 44000m },
                    { 2, "Rima", 1, "Irving", 42000m },
                    { 3, "Jack", 0, "Bonilla", 43000m },
                    { 4, "Keisha", 1, "Higgins", 41200m }
                });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "CourseId", "Subject", "TeacherId", "Title" },
                values: new object[,]
                {
                    { 8, "O019PKV", 2, 4, "Biology 301" },
                    { 7, "L009JNA", 12, 3, "Drama 101" },
                    { 3, "E762LSH", 1, 3, "English 201" },
                    { 6, "Z918OIQ", 0, 2, "Geometry 101" },
                    { 2, "S238ICE", 2, 2, "Science 401" },
                    { 5, "N293OAI", 0, 1, "Algebra 101" },
                    { 1, "M108THT", 0, 1, "Maths 101" },
                    { 4, "H289OWJ", 11, 4, "Sports 101" }
                });

            migrationBuilder.InsertData(
                table: "StudentAddresses",
                columns: new[] { "Id", "City", "IsPrimary", "Postcode", "State", "StreetAddress", "StudentId", "Suburb" },
                values: new object[,]
                {
                    { 1, "Perth", true, "5123", "Unwepq", "123 fake st", 1, "Aowweq" },
                    { 2, "Werth", true, "8123", "Wpfepq", "128 fake st", 1, "Mngweq" },
                    { 3, "Zerth", true, "9123", "Nmeepq", "127 fake st", 1, "Louweq" },
                    { 4, "Derth", true, "0123", "Hjkepq", "126 fake st", 1, "Mzuweq" },
                    { 5, "Ferth", true, "2123", "Qrwwepq", "125 fake st", 1, "LLwweq" },
                    { 6, "Merth", true, "4123", "FWca", "124 fake st", 1, "Gweq" }
                });

            migrationBuilder.InsertData(
                table: "StudentEmails",
                columns: new[] { "Id", "EmailAddress", "IsSchoolEmail", "Owner", "StudentId" },
                values: new object[,]
                {
                    { 2, "keira54@yahoo.com", false, 2, 2 },
                    { 6, "ressie49@bernier.com", false, 2, 2 },
                    { 3, "wilmer02@hane.com", false, 2, 3 },
                    { 7, "dkuhlman@yahoo.com", false, 2, 1 },
                    { 4, "vesta.leffler@stracke.info", false, 2, 4 },
                    { 5, "kelsie.lueilwitz@gmail.com", false, 2, 5 },
                    { 8, "rhoppe@gmail.com", false, 2, 6 },
                    { 1, "203948@school.org", true, 2, 1 }
                });

            migrationBuilder.InsertData(
                table: "StudentPhoneNumbers",
                columns: new[] { "Id", "IsEmergency", "IsMobile", "Number", "Owner", "StudentId" },
                values: new object[,]
                {
                    { 6, true, false, "94104280", 4, 1 },
                    { 5, true, true, "0406936119", 3, 5 },
                    { 1, true, true, "040690660", 0, 1 },
                    { 4, true, true, "0406938120", 0, 4 },
                    { 8, true, true, "0466138120", 0, 3 },
                    { 2, true, false, "87164280", 2, 2 },
                    { 7, true, true, "0416928190", 1, 6 },
                    { 3, true, true, "048877120", 1, 3 }
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
                name: "IX_Courses_TeacherId",
                table: "Courses",
                column: "TeacherId");

            migrationBuilder.CreateIndex(
                name: "IX_Enrollments_CourseId",
                table: "Enrollments",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_Enrollments_StudentId",
                table: "Enrollments",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentAddresses_StudentId",
                table: "StudentAddresses",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentEmails_StudentId",
                table: "StudentEmails",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentPhoneNumbers_StudentId",
                table: "StudentPhoneNumbers",
                column: "StudentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Enrollments");

            migrationBuilder.DropTable(
                name: "StudentAddresses");

            migrationBuilder.DropTable(
                name: "StudentEmails");

            migrationBuilder.DropTable(
                name: "StudentPhoneNumbers");

            migrationBuilder.DropTable(
                name: "Courses");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "Teachers");
        }
    }
}
