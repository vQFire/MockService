using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MockService.Migrations
{
    public partial class ScheduleCompetence : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CompetenceScheduleGroup",
                columns: table => new
                {
                    ScheduleCompetencesId = table.Column<Guid>(type: "uuid", nullable: false),
                    ScheduleGroupsId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompetenceScheduleGroup", x => new { x.ScheduleCompetencesId, x.ScheduleGroupsId });
                    table.ForeignKey(
                        name: "FK_CompetenceScheduleGroup_Competences_ScheduleCompetencesId",
                        column: x => x.ScheduleCompetencesId,
                        principalTable: "Competences",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CompetenceScheduleGroup_ScheduleGroup_ScheduleGroupsId",
                        column: x => x.ScheduleGroupsId,
                        principalTable: "ScheduleGroup",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CompetenceScheduleGroup_ScheduleGroupsId",
                table: "CompetenceScheduleGroup",
                column: "ScheduleGroupsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CompetenceScheduleGroup");
        }
    }
}
