using Microsoft.EntityFrameworkCore.Migrations;

namespace SchoolDBAPI.Library.Migrations
{
    public partial class UpdateContacts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsEmergency",
                table: "PhoneNumbers",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "StudentId",
                table: "PhoneNumbers",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TeacherId",
                table: "PhoneNumbers",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Owner",
                table: "Emails",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "StudentId",
                table: "Emails",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TeacherId",
                table: "Emails",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Address",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonId = table.Column<int>(nullable: false),
                    StreetAddress = table.Column<string>(nullable: true),
                    Suburb = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    State = table.Column<string>(nullable: true),
                    Postcode = table.Column<string>(nullable: true),
                    IsPrimary = table.Column<bool>(nullable: false),
                    StudentId = table.Column<int>(nullable: true),
                    TeacherId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Address_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Address_Teachers_TeacherId",
                        column: x => x.TeacherId,
                        principalTable: "Teachers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.UpdateData(
                table: "Emails",
                keyColumn: "Id",
                keyValue: 1,
                column: "Owner",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Emails",
                keyColumn: "Id",
                keyValue: 2,
                column: "Owner",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Emails",
                keyColumn: "Id",
                keyValue: 3,
                column: "Owner",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Emails",
                keyColumn: "Id",
                keyValue: 4,
                column: "Owner",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Emails",
                keyColumn: "Id",
                keyValue: 5,
                column: "Owner",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Emails",
                keyColumn: "Id",
                keyValue: 6,
                column: "Owner",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Emails",
                keyColumn: "Id",
                keyValue: 7,
                column: "Owner",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Emails",
                keyColumn: "Id",
                keyValue: 8,
                column: "Owner",
                value: 2);

            migrationBuilder.UpdateData(
                table: "PhoneNumbers",
                keyColumn: "Id",
                keyValue: 1,
                column: "IsEmergency",
                value: true);

            migrationBuilder.UpdateData(
                table: "PhoneNumbers",
                keyColumn: "Id",
                keyValue: 2,
                column: "IsEmergency",
                value: true);

            migrationBuilder.UpdateData(
                table: "PhoneNumbers",
                keyColumn: "Id",
                keyValue: 3,
                column: "IsEmergency",
                value: true);

            migrationBuilder.UpdateData(
                table: "PhoneNumbers",
                keyColumn: "Id",
                keyValue: 4,
                column: "IsEmergency",
                value: true);

            migrationBuilder.UpdateData(
                table: "PhoneNumbers",
                keyColumn: "Id",
                keyValue: 5,
                column: "IsEmergency",
                value: true);

            migrationBuilder.UpdateData(
                table: "PhoneNumbers",
                keyColumn: "Id",
                keyValue: 6,
                column: "IsEmergency",
                value: true);

            migrationBuilder.UpdateData(
                table: "PhoneNumbers",
                keyColumn: "Id",
                keyValue: 7,
                column: "IsEmergency",
                value: true);

            migrationBuilder.UpdateData(
                table: "PhoneNumbers",
                keyColumn: "Id",
                keyValue: 8,
                column: "IsEmergency",
                value: true);

            migrationBuilder.CreateIndex(
                name: "IX_PhoneNumbers_StudentId",
                table: "PhoneNumbers",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_PhoneNumbers_TeacherId",
                table: "PhoneNumbers",
                column: "TeacherId");

            migrationBuilder.CreateIndex(
                name: "IX_Emails_StudentId",
                table: "Emails",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_Emails_TeacherId",
                table: "Emails",
                column: "TeacherId");

            migrationBuilder.CreateIndex(
                name: "IX_Address_StudentId",
                table: "Address",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_Address_TeacherId",
                table: "Address",
                column: "TeacherId");

            migrationBuilder.AddForeignKey(
                name: "FK_Emails_Students_StudentId",
                table: "Emails",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Emails_Teachers_TeacherId",
                table: "Emails",
                column: "TeacherId",
                principalTable: "Teachers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PhoneNumbers_Students_StudentId",
                table: "PhoneNumbers",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PhoneNumbers_Teachers_TeacherId",
                table: "PhoneNumbers",
                column: "TeacherId",
                principalTable: "Teachers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Emails_Students_StudentId",
                table: "Emails");

            migrationBuilder.DropForeignKey(
                name: "FK_Emails_Teachers_TeacherId",
                table: "Emails");

            migrationBuilder.DropForeignKey(
                name: "FK_PhoneNumbers_Students_StudentId",
                table: "PhoneNumbers");

            migrationBuilder.DropForeignKey(
                name: "FK_PhoneNumbers_Teachers_TeacherId",
                table: "PhoneNumbers");

            migrationBuilder.DropTable(
                name: "Address");

            migrationBuilder.DropIndex(
                name: "IX_PhoneNumbers_StudentId",
                table: "PhoneNumbers");

            migrationBuilder.DropIndex(
                name: "IX_PhoneNumbers_TeacherId",
                table: "PhoneNumbers");

            migrationBuilder.DropIndex(
                name: "IX_Emails_StudentId",
                table: "Emails");

            migrationBuilder.DropIndex(
                name: "IX_Emails_TeacherId",
                table: "Emails");

            migrationBuilder.DropColumn(
                name: "IsEmergency",
                table: "PhoneNumbers");

            migrationBuilder.DropColumn(
                name: "StudentId",
                table: "PhoneNumbers");

            migrationBuilder.DropColumn(
                name: "TeacherId",
                table: "PhoneNumbers");

            migrationBuilder.DropColumn(
                name: "Owner",
                table: "Emails");

            migrationBuilder.DropColumn(
                name: "StudentId",
                table: "Emails");

            migrationBuilder.DropColumn(
                name: "TeacherId",
                table: "Emails");
        }
    }
}
