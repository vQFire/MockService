using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MockService.Migrations
{
    public partial class OneWayRelations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CompetenceScheduleGroup_Competences_ScheduleCompetencesId",
                table: "CompetenceScheduleGroup");

            migrationBuilder.DropForeignKey(
                name: "FK_CompetenceScheduleGroup_ScheduleGroup_ScheduleGroupsId",
                table: "CompetenceScheduleGroup");

            migrationBuilder.DropForeignKey(
                name: "FK_OrganizationalUnitScheduleGroup_OrganizationalUnits_Organiz~",
                table: "OrganizationalUnitScheduleGroup");

            migrationBuilder.DropForeignKey(
                name: "FK_OrganizationalUnitScheduleGroup_ScheduleGroup_ScheduleGroup~",
                table: "OrganizationalUnitScheduleGroup");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrganizationalUnitScheduleGroup",
                table: "OrganizationalUnitScheduleGroup");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CompetenceScheduleGroup",
                table: "CompetenceScheduleGroup");

            migrationBuilder.RenameColumn(
                name: "ScheduleGroupsId",
                table: "OrganizationalUnitScheduleGroup",
                newName: "OrganizationalUnitId");

            migrationBuilder.RenameColumn(
                name: "OrganizationalUnitsId",
                table: "OrganizationalUnitScheduleGroup",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_OrganizationalUnitScheduleGroup_ScheduleGroupsId",
                table: "OrganizationalUnitScheduleGroup",
                newName: "IX_OrganizationalUnitScheduleGroup_OrganizationalUnitId");

            migrationBuilder.RenameColumn(
                name: "ScheduleGroupsId",
                table: "CompetenceScheduleGroup",
                newName: "CompetenceId");

            migrationBuilder.RenameColumn(
                name: "ScheduleCompetencesId",
                table: "CompetenceScheduleGroup",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_CompetenceScheduleGroup_ScheduleGroupsId",
                table: "CompetenceScheduleGroup",
                newName: "IX_CompetenceScheduleGroup_CompetenceId");

            migrationBuilder.AddColumn<Guid>(
                name: "ScheduleGroupId",
                table: "OrganizationalUnitScheduleGroup",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ScheduleGroupId",
                table: "CompetenceScheduleGroup",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrganizationalUnitScheduleGroup",
                table: "OrganizationalUnitScheduleGroup",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CompetenceScheduleGroup",
                table: "CompetenceScheduleGroup",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_OrganizationalUnitScheduleGroup_ScheduleGroupId",
                table: "OrganizationalUnitScheduleGroup",
                column: "ScheduleGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_CompetenceScheduleGroup_ScheduleGroupId",
                table: "CompetenceScheduleGroup",
                column: "ScheduleGroupId");

            migrationBuilder.AddForeignKey(
                name: "FK_CompetenceScheduleGroup_Competences_CompetenceId",
                table: "CompetenceScheduleGroup",
                column: "CompetenceId",
                principalTable: "Competences",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CompetenceScheduleGroup_ScheduleGroup_ScheduleGroupId",
                table: "CompetenceScheduleGroup",
                column: "ScheduleGroupId",
                principalTable: "ScheduleGroup",
                principalColumn: "Id");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CompetenceScheduleGroup_Competences_CompetenceId",
                table: "CompetenceScheduleGroup");

            migrationBuilder.DropForeignKey(
                name: "FK_CompetenceScheduleGroup_ScheduleGroup_ScheduleGroupId",
                table: "CompetenceScheduleGroup");

            migrationBuilder.DropForeignKey(
                name: "FK_OrganizationalUnitScheduleGroup_OrganizationalUnits_Organiz~",
                table: "OrganizationalUnitScheduleGroup");

            migrationBuilder.DropForeignKey(
                name: "FK_OrganizationalUnitScheduleGroup_ScheduleGroup_ScheduleGroup~",
                table: "OrganizationalUnitScheduleGroup");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrganizationalUnitScheduleGroup",
                table: "OrganizationalUnitScheduleGroup");

            migrationBuilder.DropIndex(
                name: "IX_OrganizationalUnitScheduleGroup_ScheduleGroupId",
                table: "OrganizationalUnitScheduleGroup");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CompetenceScheduleGroup",
                table: "CompetenceScheduleGroup");

            migrationBuilder.DropIndex(
                name: "IX_CompetenceScheduleGroup_ScheduleGroupId",
                table: "CompetenceScheduleGroup");

            migrationBuilder.DropColumn(
                name: "ScheduleGroupId",
                table: "OrganizationalUnitScheduleGroup");

            migrationBuilder.DropColumn(
                name: "ScheduleGroupId",
                table: "CompetenceScheduleGroup");

            migrationBuilder.RenameColumn(
                name: "OrganizationalUnitId",
                table: "OrganizationalUnitScheduleGroup",
                newName: "ScheduleGroupsId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "OrganizationalUnitScheduleGroup",
                newName: "OrganizationalUnitsId");

            migrationBuilder.RenameIndex(
                name: "IX_OrganizationalUnitScheduleGroup_OrganizationalUnitId",
                table: "OrganizationalUnitScheduleGroup",
                newName: "IX_OrganizationalUnitScheduleGroup_ScheduleGroupsId");

            migrationBuilder.RenameColumn(
                name: "CompetenceId",
                table: "CompetenceScheduleGroup",
                newName: "ScheduleGroupsId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "CompetenceScheduleGroup",
                newName: "ScheduleCompetencesId");

            migrationBuilder.RenameIndex(
                name: "IX_CompetenceScheduleGroup_CompetenceId",
                table: "CompetenceScheduleGroup",
                newName: "IX_CompetenceScheduleGroup_ScheduleGroupsId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrganizationalUnitScheduleGroup",
                table: "OrganizationalUnitScheduleGroup",
                columns: new[] { "OrganizationalUnitsId", "ScheduleGroupsId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_CompetenceScheduleGroup",
                table: "CompetenceScheduleGroup",
                columns: new[] { "ScheduleCompetencesId", "ScheduleGroupsId" });

            migrationBuilder.AddForeignKey(
                name: "FK_CompetenceScheduleGroup_Competences_ScheduleCompetencesId",
                table: "CompetenceScheduleGroup",
                column: "ScheduleCompetencesId",
                principalTable: "Competences",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CompetenceScheduleGroup_ScheduleGroup_ScheduleGroupsId",
                table: "CompetenceScheduleGroup",
                column: "ScheduleGroupsId",
                principalTable: "ScheduleGroup",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrganizationalUnitScheduleGroup_OrganizationalUnits_Organiz~",
                table: "OrganizationalUnitScheduleGroup",
                column: "OrganizationalUnitsId",
                principalTable: "OrganizationalUnits",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrganizationalUnitScheduleGroup_ScheduleGroup_ScheduleGroup~",
                table: "OrganizationalUnitScheduleGroup",
                column: "ScheduleGroupsId",
                principalTable: "ScheduleGroup",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
