using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MockService.Migrations
{
    public partial class RemoveScheduleGroupChildWrapper : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CompetenceScheduleGroups_ScheduleGroup_ScheduleGroupId",
                table: "CompetenceScheduleGroups");

            migrationBuilder.DropForeignKey(
                name: "FK_OrganizationalUnitScheduleGroups_ScheduleGroup_ScheduleGrou~",
                table: "OrganizationalUnitScheduleGroups");

            migrationBuilder.DropIndex(
                name: "IX_OrganizationalUnitScheduleGroups_ScheduleGroupId",
                table: "OrganizationalUnitScheduleGroups");

            migrationBuilder.DropIndex(
                name: "IX_CompetenceScheduleGroups_ScheduleGroupId",
                table: "CompetenceScheduleGroups");

            migrationBuilder.DropColumn(
                name: "ScheduleGroupId",
                table: "OrganizationalUnitScheduleGroups");

            migrationBuilder.DropColumn(
                name: "ScheduleGroupId",
                table: "CompetenceScheduleGroups");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "ScheduleGroup",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ScheduleGroupId",
                table: "OrganizationalUnits",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ScheduleGroupId",
                table: "Competences",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_OrganizationalUnits_ScheduleGroupId",
                table: "OrganizationalUnits",
                column: "ScheduleGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Competences_ScheduleGroupId",
                table: "Competences",
                column: "ScheduleGroupId");

            migrationBuilder.AddForeignKey(
                name: "FK_Competences_ScheduleGroup_ScheduleGroupId",
                table: "Competences",
                column: "ScheduleGroupId",
                principalTable: "ScheduleGroup",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OrganizationalUnits_ScheduleGroup_ScheduleGroupId",
                table: "OrganizationalUnits",
                column: "ScheduleGroupId",
                principalTable: "ScheduleGroup",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Competences_ScheduleGroup_ScheduleGroupId",
                table: "Competences");

            migrationBuilder.DropForeignKey(
                name: "FK_OrganizationalUnits_ScheduleGroup_ScheduleGroupId",
                table: "OrganizationalUnits");

            migrationBuilder.DropIndex(
                name: "IX_OrganizationalUnits_ScheduleGroupId",
                table: "OrganizationalUnits");

            migrationBuilder.DropIndex(
                name: "IX_Competences_ScheduleGroupId",
                table: "Competences");

            migrationBuilder.DropColumn(
                name: "ScheduleGroupId",
                table: "OrganizationalUnits");

            migrationBuilder.DropColumn(
                name: "ScheduleGroupId",
                table: "Competences");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "ScheduleGroup",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddColumn<Guid>(
                name: "ScheduleGroupId",
                table: "OrganizationalUnitScheduleGroups",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ScheduleGroupId",
                table: "CompetenceScheduleGroups",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_OrganizationalUnitScheduleGroups_ScheduleGroupId",
                table: "OrganizationalUnitScheduleGroups",
                column: "ScheduleGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_CompetenceScheduleGroups_ScheduleGroupId",
                table: "CompetenceScheduleGroups",
                column: "ScheduleGroupId");

            migrationBuilder.AddForeignKey(
                name: "FK_CompetenceScheduleGroups_ScheduleGroup_ScheduleGroupId",
                table: "CompetenceScheduleGroups",
                column: "ScheduleGroupId",
                principalTable: "ScheduleGroup",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OrganizationalUnitScheduleGroups_ScheduleGroup_ScheduleGrou~",
                table: "OrganizationalUnitScheduleGroups",
                column: "ScheduleGroupId",
                principalTable: "ScheduleGroup",
                principalColumn: "Id");
        }
    }
}
