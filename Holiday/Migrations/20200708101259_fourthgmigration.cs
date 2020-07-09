using Microsoft.EntityFrameworkCore.Migrations;

namespace Holiday.Migrations
{
    public partial class fourthgmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "NumberOfDaysConsumed",
                table: "Employees",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "NumberOfDaysLeft",
                table: "Employees",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NumberOfDaysConsumed",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "NumberOfDaysLeft",
                table: "Employees");
        }
    }
}
