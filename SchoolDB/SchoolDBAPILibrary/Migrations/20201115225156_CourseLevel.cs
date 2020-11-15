using Microsoft.EntityFrameworkCore.Migrations;

namespace SchoolDBAPI.Library.Migrations
{
    public partial class CourseLevel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CourseLevel",
                table: "SubjectTeachers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CourseLevel",
                table: "Courses",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 2,
                column: "CourseLevel",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 5,
                column: "CourseLevel",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 6,
                column: "CourseLevel",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 8,
                column: "CourseLevel",
                value: 2);

            migrationBuilder.UpdateData(
                table: "SubjectTeachers",
                keyColumn: "Id",
                keyValue: 1,
                column: "CourseLevel",
                value: 2);

            migrationBuilder.UpdateData(
                table: "SubjectTeachers",
                keyColumn: "Id",
                keyValue: 2,
                column: "CourseLevel",
                value: 1);

            migrationBuilder.UpdateData(
                table: "SubjectTeachers",
                keyColumn: "Id",
                keyValue: 3,
                column: "CourseLevel",
                value: 2);

            migrationBuilder.UpdateData(
                table: "SubjectTeachers",
                keyColumn: "Id",
                keyValue: 4,
                column: "CourseLevel",
                value: 2);

            migrationBuilder.UpdateData(
                table: "SubjectTeachers",
                keyColumn: "Id",
                keyValue: 6,
                column: "CourseLevel",
                value: 1);

            migrationBuilder.UpdateData(
                table: "SubjectTeachers",
                keyColumn: "Id",
                keyValue: 7,
                column: "CourseLevel",
                value: 2);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CourseLevel",
                table: "SubjectTeachers");

            migrationBuilder.DropColumn(
                name: "CourseLevel",
                table: "Courses");
        }
    }
}
