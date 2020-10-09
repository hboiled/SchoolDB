using Microsoft.EntityFrameworkCore.Migrations;

namespace SchoolDBAPI.Library.Migrations
{
    public partial class AddEmails : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Emails",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonId = table.Column<int>(nullable: false),
                    EmailAddress = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Emails", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Emails",
                columns: new[] { "Id", "EmailAddress", "PersonId" },
                values: new object[,]
                {
                    { 1, "tromp.alexzander@weber.org", 1 },
                    { 2, "keira54@yahoo.com", 2 },
                    { 3, "wilmer02@hane.com", 3 },
                    { 4, "vesta.leffler@stracke.info", 4 },
                    { 5, "kelsie.lueilwitz@gmail.com", 5 },
                    { 6, "ressie49@bernier.com", 2 },
                    { 7, "dkuhlman@yahoo.com", 1 },
                    { 8, "rhoppe@gmail.com", 6 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Emails");
        }
    }
}
