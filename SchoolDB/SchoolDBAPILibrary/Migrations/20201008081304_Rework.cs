using Microsoft.EntityFrameworkCore.Migrations;

namespace SchoolDBAPI.Library.Migrations
{
    public partial class Rework : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Salary",
                table: "Teachers",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.UpdateData(
                table: "Enrollments",
                keyColumn: "EnrollmentId",
                keyValue: 4,
                column: "StudentId",
                value: 4);

            migrationBuilder.InsertData(
                table: "Enrollments",
                columns: new[] { "EnrollmentId", "CourseId", "StudentId" },
                values: new object[] { 6, 2, 5 });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "FirstName", "Grade", "LastName" },
                values: new object[] { "Sue", 90, "Jordan" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "FirstName", "Grade", "LastName" },
                values: new object[] { "John", 80, "Thomas" });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "FirstName", "Grade", "LastName", "StudentId" },
                values: new object[] { 6, "Javier", 80, "Mcgregor", 763343 });

            migrationBuilder.UpdateData(
                table: "Teachers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "FirstName", "LastName" },
                values: new object[] { "Crowler", "Starks" });

            migrationBuilder.UpdateData(
                table: "Teachers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "FirstName", "LastName" },
                values: new object[] { "Rima", "Irving" });

            migrationBuilder.UpdateData(
                table: "Teachers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "FirstName", "LastName" },
                values: new object[] { "Jack", "Bonilla" });

            migrationBuilder.InsertData(
                table: "Teachers",
                columns: new[] { "Id", "FirstName", "LastName", "Salary" },
                values: new object[] { 4, "Keisha", "Higgins", 0m });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "TeacherId", "Title" },
                values: new object[] { 4, 4, "Sports 101" });

            migrationBuilder.UpdateData(
                table: "Enrollments",
                keyColumn: "EnrollmentId",
                keyValue: 5,
                column: "CourseId",
                value: 4);

            migrationBuilder.InsertData(
                table: "Enrollments",
                columns: new[] { "EnrollmentId", "CourseId", "StudentId" },
                values: new object[] { 7, 4, 6 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Enrollments",
                keyColumn: "EnrollmentId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Enrollments",
                keyColumn: "EnrollmentId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Enrollments",
                keyColumn: "EnrollmentId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Teachers",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DropColumn(
                name: "Salary",
                table: "Teachers");

            migrationBuilder.UpdateData(
                table: "Enrollments",
                keyColumn: "EnrollmentId",
                keyValue: 4,
                column: "StudentId",
                value: 2);

            migrationBuilder.InsertData(
                table: "Enrollments",
                columns: new[] { "EnrollmentId", "CourseId", "StudentId" },
                values: new object[] { 5, 2, 1 });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "FirstName", "Grade", "LastName" },
                values: new object[] { "BWPIff", 2, "kfnae" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "FirstName", "Grade", "LastName" },
                values: new object[] { "ZKXsoi", 45, "glwiej" });

            migrationBuilder.UpdateData(
                table: "Teachers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "FirstName", "LastName" },
                values: new object[] { "Aoigjwor", "klndcv" });

            migrationBuilder.UpdateData(
                table: "Teachers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "FirstName", "LastName" },
                values: new object[] { "Zzvjsn", "woego" });

            migrationBuilder.UpdateData(
                table: "Teachers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "FirstName", "LastName" },
                values: new object[] { "Pvjep", "siweq3r" });
        }
    }
}
