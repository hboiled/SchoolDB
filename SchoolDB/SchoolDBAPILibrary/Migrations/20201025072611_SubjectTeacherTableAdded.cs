using Microsoft.EntityFrameworkCore.Migrations;

namespace SchoolDBAPI.Library.Migrations
{
    public partial class SubjectTeacherTableAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "photoImgPath",
                table: "Students",
                newName: "PhotoImgPath");

            migrationBuilder.CreateTable(
                name: "SubjectTeachers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TeacherId = table.Column<int>(nullable: false),
                    Subject = table.Column<int>(nullable: false)
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

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 1,
                column: "PhotoImgPath",
                value: "https://th.bing.com/th/id/OIP.SfAt4LpgCsJGCSD6AZffigHaHa?pid=Api&rs=1");

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 2,
                column: "PhotoImgPath",
                value: "https://th.bing.com/th/id/OIP.SfAt4LpgCsJGCSD6AZffigHaHa?pid=Api&rs=1");

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 3,
                column: "PhotoImgPath",
                value: "https://th.bing.com/th/id/OIP.SfAt4LpgCsJGCSD6AZffigHaHa?pid=Api&rs=1");

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 4,
                column: "PhotoImgPath",
                value: "https://th.bing.com/th/id/OIP.SfAt4LpgCsJGCSD6AZffigHaHa?pid=Api&rs=1");

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 5,
                column: "PhotoImgPath",
                value: "https://th.bing.com/th/id/OIP.SfAt4LpgCsJGCSD6AZffigHaHa?pid=Api&rs=1");

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 6,
                column: "PhotoImgPath",
                value: "https://th.bing.com/th/id/OIP.SfAt4LpgCsJGCSD6AZffigHaHa?pid=Api&rs=1");

            migrationBuilder.InsertData(
                table: "SubjectTeachers",
                columns: new[] { "Id", "Subject", "TeacherId" },
                values: new object[,]
                {
                    { 1, 0, 1 },
                    { 2, 0, 2 },
                    { 3, 2, 2 },
                    { 4, 1, 3 },
                    { 5, 12, 3 },
                    { 6, 11, 4 },
                    { 7, 2, 4 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_SubjectTeachers_TeacherId",
                table: "SubjectTeachers",
                column: "TeacherId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SubjectTeachers");

            migrationBuilder.RenameColumn(
                name: "PhotoImgPath",
                table: "Students",
                newName: "photoImgPath");

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 1,
                column: "photoImgPath",
                value: null);

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 2,
                column: "photoImgPath",
                value: null);

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 3,
                column: "photoImgPath",
                value: null);

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 4,
                column: "photoImgPath",
                value: null);

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 5,
                column: "photoImgPath",
                value: null);

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 6,
                column: "photoImgPath",
                value: null);
        }
    }
}
