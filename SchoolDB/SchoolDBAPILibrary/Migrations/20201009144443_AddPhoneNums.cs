using Microsoft.EntityFrameworkCore.Migrations;

namespace SchoolDBAPI.Library.Migrations
{
    public partial class AddPhoneNums : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsSchoolEmail",
                table: "Emails",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "PhoneNumbers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonId = table.Column<int>(nullable: false),
                    Number = table.Column<string>(nullable: true),
                    Owner = table.Column<int>(nullable: false),
                    IsMobile = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhoneNumbers", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "Emails",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EmailAddress", "IsSchoolEmail" },
                values: new object[] { "203948@school.org", true });

            migrationBuilder.InsertData(
                table: "PhoneNumbers",
                columns: new[] { "Id", "IsMobile", "Number", "Owner", "PersonId" },
                values: new object[,]
                {
                    { 1, true, "040690660", 0, 1 },
                    { 2, false, "87164280", 2, 2 },
                    { 3, true, "048877120", 1, 3 },
                    { 4, true, "0406938120", 0, 4 },
                    { 5, true, "0406936119", 3, 5 },
                    { 6, false, "94104280", 4, 1 },
                    { 7, true, "0416928190", 1, 6 },
                    { 8, true, "0466138120", 0, 7 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PhoneNumbers");

            migrationBuilder.DropColumn(
                name: "IsSchoolEmail",
                table: "Emails");

            migrationBuilder.UpdateData(
                table: "Emails",
                keyColumn: "Id",
                keyValue: 1,
                column: "EmailAddress",
                value: "tromp.alexzander@weber.org");
        }
    }
}
