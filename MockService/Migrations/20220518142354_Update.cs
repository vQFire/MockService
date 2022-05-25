using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MockService.Migrations
{
    public partial class Update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CompetenceScheduleGroup_Competences_CompetenceId",
                table: "CompetenceScheduleGroup");

            migrationBuilder.DropForeignKey(
                name: "FK_CompetenceScheduleGroup_ScheduleGroup_ScheduleGroupId",
                table: "CompetenceScheduleGroup");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CompetenceScheduleGroup",
                table: "CompetenceScheduleGroup");

            migrationBuilder.RenameTable(
                name: "CompetenceScheduleGroup",
                newName: "CompetenceScheduleGroups");

            migrationBuilder.RenameIndex(
                name: "IX_CompetenceScheduleGroup_ScheduleGroupId",
                table: "CompetenceScheduleGroups",
                newName: "IX_CompetenceScheduleGroups_ScheduleGroupId");

            migrationBuilder.RenameIndex(
                name: "IX_CompetenceScheduleGroup_CompetenceId",
                table: "CompetenceScheduleGroups",
                newName: "IX_CompetenceScheduleGroups_CompetenceId");

            migrationBuilder.AlterColumn<DateTime>(
                name: "validTo",
                table: "EmployeeContractExtensions",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateOnly),
                oldType: "date");

            migrationBuilder.AlterColumn<DateTime>(
                name: "validFrom",
                table: "EmployeeContractExtensions",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateOnly),
                oldType: "date");

            migrationBuilder.AlterColumn<DateTime>(
                name: "validTo",
                table: "EmployeeContractCompetences",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateOnly),
                oldType: "date");

            migrationBuilder.AlterColumn<DateTime>(
                name: "validFrom",
                table: "EmployeeContractCompetences",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateOnly),
                oldType: "date");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CompetenceScheduleGroups",
                table: "CompetenceScheduleGroups",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CompetenceScheduleGroups_Competences_CompetenceId",
                table: "CompetenceScheduleGroups",
                column: "CompetenceId",
                principalTable: "Competences",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CompetenceScheduleGroups_ScheduleGroup_ScheduleGroupId",
                table: "CompetenceScheduleGroups",
                column: "ScheduleGroupId",
                principalTable: "ScheduleGroup",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CompetenceScheduleGroups_Competences_CompetenceId",
                table: "CompetenceScheduleGroups");

            migrationBuilder.DropForeignKey(
                name: "FK_CompetenceScheduleGroups_ScheduleGroup_ScheduleGroupId",
                table: "CompetenceScheduleGroups");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CompetenceScheduleGroups",
                table: "CompetenceScheduleGroups");

            migrationBuilder.RenameTable(
                name: "CompetenceScheduleGroups",
                newName: "CompetenceScheduleGroup");

            migrationBuilder.RenameIndex(
                name: "IX_CompetenceScheduleGroups_ScheduleGroupId",
                table: "CompetenceScheduleGroup",
                newName: "IX_CompetenceScheduleGroup_ScheduleGroupId");

            migrationBuilder.RenameIndex(
                name: "IX_CompetenceScheduleGroups_CompetenceId",
                table: "CompetenceScheduleGroup",
                newName: "IX_CompetenceScheduleGroup_CompetenceId");

            migrationBuilder.AlterColumn<DateOnly>(
                name: "validTo",
                table: "EmployeeContractExtensions",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<DateOnly>(
                name: "validFrom",
                table: "EmployeeContractExtensions",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<DateOnly>(
                name: "validTo",
                table: "EmployeeContractCompetences",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<DateOnly>(
                name: "validFrom",
                table: "EmployeeContractCompetences",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CompetenceScheduleGroup",
                table: "CompetenceScheduleGroup",
                column: "Id");

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
        }
    }
}
