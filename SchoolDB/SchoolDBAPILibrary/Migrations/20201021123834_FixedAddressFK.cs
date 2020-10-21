using Microsoft.EntityFrameworkCore.Migrations;

namespace SchoolDBAPI.Library.Migrations
{
    public partial class FixedAddressFK : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "StudentAddresses",
                keyColumn: "Id",
                keyValue: 2,
                column: "StudentId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "StudentAddresses",
                keyColumn: "Id",
                keyValue: 3,
                column: "StudentId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "StudentAddresses",
                keyColumn: "Id",
                keyValue: 4,
                column: "StudentId",
                value: 4);

            migrationBuilder.UpdateData(
                table: "StudentAddresses",
                keyColumn: "Id",
                keyValue: 5,
                column: "StudentId",
                value: 5);

            migrationBuilder.UpdateData(
                table: "StudentAddresses",
                keyColumn: "Id",
                keyValue: 6,
                column: "StudentId",
                value: 6);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "StudentAddresses",
                keyColumn: "Id",
                keyValue: 2,
                column: "StudentId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "StudentAddresses",
                keyColumn: "Id",
                keyValue: 3,
                column: "StudentId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "StudentAddresses",
                keyColumn: "Id",
                keyValue: 4,
                column: "StudentId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "StudentAddresses",
                keyColumn: "Id",
                keyValue: 5,
                column: "StudentId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "StudentAddresses",
                keyColumn: "Id",
                keyValue: 6,
                column: "StudentId",
                value: 1);
        }
    }
}
