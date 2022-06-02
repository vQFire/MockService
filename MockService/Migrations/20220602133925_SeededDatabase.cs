using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MockService.Migrations
{
    public partial class SeededDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IgNorInCalculations",
                table: "ScheduleGroup",
                newName: "IgnoreInCalculations");

            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "ScheduleGroup",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Code",
                table: "ScheduleGroup");

            migrationBuilder.RenameColumn(
                name: "IgnoreInCalculations",
                table: "ScheduleGroup",
                newName: "IgNorInCalculations");
        }
    }
}
