using Microsoft.EntityFrameworkCore.Migrations;

namespace Holiday.Migrations
{
    public partial class ThirdMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ConsumedDays",
                table: "Vacantions",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DaysLeft",
                table: "Vacantions",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "VacantionRequests",
                columns: table => new
                {
                    VacantionRequestId = table.Column<string>(nullable: false),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Type = table.Column<string>(nullable: true),
                    NoOfDays = table.Column<int>(nullable: false),
                    Cause = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VacantionRequests", x => x.VacantionRequestId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VacantionRequests");

            migrationBuilder.DropColumn(
                name: "ConsumedDays",
                table: "Vacantions");

            migrationBuilder.DropColumn(
                name: "DaysLeft",
                table: "Vacantions");
        }
    }
}
