using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MockService.Migrations
{
    public partial class ChangedDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ScheduleGroupSchedule_ScheduleGroup_ScheduleGroupId",
                table: "ScheduleGroupSchedule");

            migrationBuilder.AlterColumn<Guid>(
                name: "ScheduleGroupId",
                table: "ScheduleGroupSchedule",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "ScheduleGroup",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ScheduleGroupSchedule_ScheduleGroup_ScheduleGroupId",
                table: "ScheduleGroupSchedule",
                column: "ScheduleGroupId",
                principalTable: "ScheduleGroup",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ScheduleGroupSchedule_ScheduleGroup_ScheduleGroupId",
                table: "ScheduleGroupSchedule");

            migrationBuilder.AlterColumn<Guid>(
                name: "ScheduleGroupId",
                table: "ScheduleGroupSchedule",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "ScheduleGroup",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddForeignKey(
                name: "FK_ScheduleGroupSchedule_ScheduleGroup_ScheduleGroupId",
                table: "ScheduleGroupSchedule",
                column: "ScheduleGroupId",
                principalTable: "ScheduleGroup",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
