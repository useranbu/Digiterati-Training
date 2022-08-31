using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Digiterati.Data.Migrations
{
    public partial class addTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    employeeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    employeeName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    status = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    manager = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    wfmManager = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    lockStatus = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    experience = table.Column<double>(type: "float", nullable: true),
                    profileId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.employeeId);
                });

            migrationBuilder.CreateTable(
                name: "Skills",
                columns: table => new
                {
                    skillId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    skillName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Skills", x => x.skillId);
                });

            migrationBuilder.CreateTable(
                name: "SoftLocks",
                columns: table => new
                {
                    lockId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    employee_Id = table.Column<int>(type: "int", nullable: false),
                    manager = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    reqdate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    lastupdated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    requestmessage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    wfmremark = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    managerstatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    mgrstatuscomment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    mgrlastupdate = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SoftLocks", x => x.lockId);
                    table.ForeignKey(
                        name: "FK_SoftLocks_Employees_employee_Id",
                        column: x => x.employee_Id,
                        principalTable: "Employees",
                        principalColumn: "employeeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SkillMaps",
                columns: table => new
                {
                    employeeId = table.Column<int>(type: "int", nullable: false),
                    skillId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SkillMaps", x => x.employeeId);
                    table.ForeignKey(
                        name: "FK_SkillMaps_Employees_employeeId",
                        column: x => x.employeeId,
                        principalTable: "Employees",
                        principalColumn: "employeeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SkillMaps_Skills_skillId",
                        column: x => x.skillId,
                        principalTable: "Skills",
                        principalColumn: "skillId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SkillMaps_skillId",
                table: "SkillMaps",
                column: "skillId");

            migrationBuilder.CreateIndex(
                name: "IX_SoftLocks_employee_Id",
                table: "SoftLocks",
                column: "employee_Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SkillMaps");

            migrationBuilder.DropTable(
                name: "SoftLocks");

            migrationBuilder.DropTable(
                name: "Skills");

            migrationBuilder.DropTable(
                name: "Employees");
        }
    }
}
