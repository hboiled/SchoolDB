using Microsoft.EntityFrameworkCore.Migrations;

namespace SchoolDBAPI.Library.Migrations
{
    public partial class FixIncorrectPhoneAssignment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "PhoneNumbers",
                keyColumn: "Id",
                keyValue: 8,
                column: "PersonId",
                value: 3);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "PhoneNumbers",
                keyColumn: "Id",
                keyValue: 8,
                column: "PersonId",
                value: 7);
        }
    }
}
