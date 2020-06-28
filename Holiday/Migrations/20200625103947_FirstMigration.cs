using Microsoft.EntityFrameworkCore.Migrations;

namespace Holiday.Migrations
{
    public partial class FirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Vacantions",
                columns: table => new
                {
                    VacantionId = table.Column<string>(nullable: false),
                    VacantionType = table.Column<string>(nullable: true),
                    VacantionDays = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vacantions", x => x.VacantionId);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    EmployeeId = table.Column<string>(nullable: false),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    NumberOfDays = table.Column<int>(nullable: false),
                    VacantionId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.EmployeeId);
                    table.ForeignKey(
                        name: "FK_Employees_Vacantions_VacantionId",
                        column: x => x.VacantionId,
                        principalTable: "Vacantions",
                        principalColumn: "VacantionId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Employees_VacantionId",
                table: "Employees",
                column: "VacantionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Vacantions");
        }
    }
}
