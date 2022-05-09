using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MockService.Migrations
{
    public partial class Schedule_Related_Models : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "OrganizationalUnits",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Code = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrganizationalUnits", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ScheduleGroup",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    IsValid = table.Column<bool>(type: "boolean", nullable: false),
                    IgNorInCalculations = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScheduleGroup", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeContractExtensions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    EmployeeContractId = table.Column<Guid>(type: "uuid", nullable: false),
                    OrganizationalUnitId = table.Column<Guid>(type: "uuid", nullable: false),
                    Function = table.Column<string>(type: "text", nullable: false),
                    LaborMinutesPerWeekMin = table.Column<int>(type: "integer", nullable: false),
                    LaborMinutesPerWeekMax = table.Column<int>(type: "integer", nullable: false),
                    validFrom = table.Column<DateOnly>(type: "date", nullable: false),
                    validTo = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeContractExtensions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmployeeContractExtensions_EmployeeContracts_EmployeeContra~",
                        column: x => x.EmployeeContractId,
                        principalTable: "EmployeeContracts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeeContractExtensions_OrganizationalUnits_Organization~",
                        column: x => x.OrganizationalUnitId,
                        principalTable: "OrganizationalUnits",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrganizationalUnitScheduleGroup",
                columns: table => new
                {
                    OrganizationalUnitsId = table.Column<Guid>(type: "uuid", nullable: false),
                    ScheduleGroupsId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrganizationalUnitScheduleGroup", x => new { x.OrganizationalUnitsId, x.ScheduleGroupsId });
                    table.ForeignKey(
                        name: "FK_OrganizationalUnitScheduleGroup_OrganizationalUnits_Organiz~",
                        column: x => x.OrganizationalUnitsId,
                        principalTable: "OrganizationalUnits",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrganizationalUnitScheduleGroup_ScheduleGroup_ScheduleGroup~",
                        column: x => x.ScheduleGroupsId,
                        principalTable: "ScheduleGroup",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Schedule",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ScheduleType = table.Column<int>(type: "integer", nullable: false),
                    ScheduleGroupId = table.Column<Guid>(type: "uuid", nullable: false),
                    EmployeeContractId = table.Column<Guid>(type: "uuid", nullable: false),
                    Date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Start = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    End = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    HasChanged = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Schedule", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Schedule_EmployeeContracts_EmployeeContractId",
                        column: x => x.EmployeeContractId,
                        principalTable: "EmployeeContracts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Schedule_ScheduleGroup_ScheduleGroupId",
                        column: x => x.ScheduleGroupId,
                        principalTable: "ScheduleGroup",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ScheduleGroupSchedule",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ScheduleGroupId = table.Column<Guid>(type: "uuid", nullable: false),
                    ScheduleType = table.Column<int>(type: "integer", nullable: false),
                    Start = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    End = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScheduleGroupSchedule", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ScheduleGroupSchedule_ScheduleGroup_ScheduleGroupId",
                        column: x => x.ScheduleGroupId,
                        principalTable: "ScheduleGroup",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeContractExtensions_EmployeeContractId",
                table: "EmployeeContractExtensions",
                column: "EmployeeContractId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeContractExtensions_OrganizationalUnitId",
                table: "EmployeeContractExtensions",
                column: "OrganizationalUnitId");

            migrationBuilder.CreateIndex(
                name: "IX_OrganizationalUnitScheduleGroup_ScheduleGroupsId",
                table: "OrganizationalUnitScheduleGroup",
                column: "ScheduleGroupsId");

            migrationBuilder.CreateIndex(
                name: "IX_Schedule_EmployeeContractId",
                table: "Schedule",
                column: "EmployeeContractId");

            migrationBuilder.CreateIndex(
                name: "IX_Schedule_ScheduleGroupId",
                table: "Schedule",
                column: "ScheduleGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_ScheduleGroupSchedule_ScheduleGroupId",
                table: "ScheduleGroupSchedule",
                column: "ScheduleGroupId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmployeeContractExtensions");

            migrationBuilder.DropTable(
                name: "OrganizationalUnitScheduleGroup");

            migrationBuilder.DropTable(
                name: "Schedule");

            migrationBuilder.DropTable(
                name: "ScheduleGroupSchedule");

            migrationBuilder.DropTable(
                name: "OrganizationalUnits");

            migrationBuilder.DropTable(
                name: "ScheduleGroup");
        }
    }
}
