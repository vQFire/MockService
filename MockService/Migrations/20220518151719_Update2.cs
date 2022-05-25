using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MockService.Migrations
{
    public partial class Update2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrganizationalUnitScheduleGroup_OrganizationalUnits_Organiz~",
                table: "OrganizationalUnitScheduleGroup");

            migrationBuilder.DropForeignKey(
                name: "FK_OrganizationalUnitScheduleGroup_ScheduleGroup_ScheduleGroup~",
                table: "OrganizationalUnitScheduleGroup");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrganizationalUnitScheduleGroup",
                table: "OrganizationalUnitScheduleGroup");

            migrationBuilder.RenameTable(
                name: "OrganizationalUnitScheduleGroup",
                newName: "OrganizationalUnitScheduleGroups");

            migrationBuilder.RenameIndex(
                name: "IX_OrganizationalUnitScheduleGroup_ScheduleGroupId",
                table: "OrganizationalUnitScheduleGroups",
                newName: "IX_OrganizationalUnitScheduleGroups_ScheduleGroupId");

            migrationBuilder.RenameIndex(
                name: "IX_OrganizationalUnitScheduleGroup_OrganizationalUnitId",
                table: "OrganizationalUnitScheduleGroups",
                newName: "IX_OrganizationalUnitScheduleGroups_OrganizationalUnitId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrganizationalUnitScheduleGroups",
                table: "OrganizationalUnitScheduleGroups",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OrganizationalUnitScheduleGroups_OrganizationalUnits_Organi~",
                table: "OrganizationalUnitScheduleGroups",
                column: "OrganizationalUnitId",
                principalTable: "OrganizationalUnits",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrganizationalUnitScheduleGroups_ScheduleGroup_ScheduleGrou~",
                table: "OrganizationalUnitScheduleGroups",
                column: "ScheduleGroupId",
                principalTable: "ScheduleGroup",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrganizationalUnitScheduleGroups_OrganizationalUnits_Organi~",
                table: "OrganizationalUnitScheduleGroups");

            migrationBuilder.DropForeignKey(
                name: "FK_OrganizationalUnitScheduleGroups_ScheduleGroup_ScheduleGrou~",
                table: "OrganizationalUnitScheduleGroups");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrganizationalUnitScheduleGroups",
                table: "OrganizationalUnitScheduleGroups");

            migrationBuilder.RenameTable(
                name: "OrganizationalUnitScheduleGroups",
                newName: "OrganizationalUnitScheduleGroup");

            migrationBuilder.RenameIndex(
                name: "IX_OrganizationalUnitScheduleGroups_ScheduleGroupId",
                table: "OrganizationalUnitScheduleGroup",
                newName: "IX_OrganizationalUnitScheduleGroup_ScheduleGroupId");

            migrationBuilder.RenameIndex(
                name: "IX_OrganizationalUnitScheduleGroups_OrganizationalUnitId",
                table: "OrganizationalUnitScheduleGroup",
                newName: "IX_OrganizationalUnitScheduleGroup_OrganizationalUnitId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrganizationalUnitScheduleGroup",
                table: "OrganizationalUnitScheduleGroup",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OrganizationalUnitScheduleGroup_OrganizationalUnits_Organiz~",
                table: "OrganizationalUnitScheduleGroup",
                column: "OrganizationalUnitId",
                principalTable: "OrganizationalUnits",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrganizationalUnitScheduleGroup_ScheduleGroup_ScheduleGroup~",
                table: "OrganizationalUnitScheduleGroup",
                column: "ScheduleGroupId",
                principalTable: "ScheduleGroup",
                principalColumn: "Id");
        }
    }
}
