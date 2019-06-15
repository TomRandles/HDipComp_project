using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TRHDipComp_Project.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Modules",
                columns: table => new
                {
                    ModuleID = table.Column<string>(maxLength: 6, nullable: false),
                    ModuleName = table.Column<string>(maxLength: 20, nullable: false),
                    ModuleDescription = table.Column<string>(maxLength: 50, nullable: true),
                    ModuleCredits = table.Column<int>(nullable: false),
                    LastUpdated = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Modules", x => x.ModuleID);
                });

            migrationBuilder.CreateTable(
                name: "NewModules",
                columns: table => new
                {
                    ModuleID = table.Column<string>(nullable: false),
                    ModuleName = table.Column<string>(nullable: true),
                    ModuleDescription = table.Column<string>(nullable: true),
                    ModuleCredits = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NewModules", x => x.ModuleID);
                });

            migrationBuilder.CreateTable(
                name: "Programmes",
                columns: table => new
                {
                    ProgrammeID = table.Column<string>(maxLength: 6, nullable: false),
                    ProgrammeName = table.Column<string>(maxLength: 20, nullable: false),
                    ProgrammeDescription = table.Column<string>(maxLength: 50, nullable: true),
                    ProgrammeQQILevel = table.Column<int>(nullable: false),
                    ProgrammeCredits = table.Column<int>(nullable: false),
                    ProgrammeCost = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    LastUpdated = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Programmes", x => x.ProgrammeID);
                });

            migrationBuilder.CreateTable(
                name: "Assessments",
                columns: table => new
                {
                    AssessmentID = table.Column<string>(maxLength: 6, nullable: false),
                    AssessmentName = table.Column<string>(maxLength: 20, nullable: false),
                    AssessmentDescription = table.Column<string>(maxLength: 50, nullable: true),
                    AssessmentTotalMarks = table.Column<int>(nullable: false),
                    AssessmentType = table.Column<int>(nullable: false),
                    AssessmentModuleID = table.Column<string>(maxLength: 6, nullable: true),
                    LastUpdated = table.Column<DateTime>(nullable: false),
                    ModuleID = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Assessments", x => x.AssessmentID);
                    table.ForeignKey(
                        name: "FK_Assessments_Modules_ModuleID",
                        column: x => x.ModuleID,
                        principalTable: "Modules",
                        principalColumn: "ModuleID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProgrammeModules",
                columns: table => new
                {
                    ProgrammeID = table.Column<string>(maxLength: 6, nullable: false),
                    ModuleID = table.Column<string>(maxLength: 6, nullable: false),
                    LastUpdated = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProgrammeModules", x => new { x.ProgrammeID, x.ModuleID });
                    table.ForeignKey(
                        name: "FK_ProgrammeModules_Modules_ModuleID",
                        column: x => x.ModuleID,
                        principalTable: "Modules",
                        principalColumn: "ModuleID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProgrammeModules_Programmes_ProgrammeID",
                        column: x => x.ProgrammeID,
                        principalTable: "Programmes",
                        principalColumn: "ProgrammeID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    StudentID = table.Column<string>(maxLength: 7, nullable: false),
                    FirstName = table.Column<string>(maxLength: 20, nullable: false),
                    SurName = table.Column<string>(maxLength: 20, nullable: false),
                    AddressOne = table.Column<string>(maxLength: 30, nullable: false),
                    AddressTwo = table.Column<string>(maxLength: 30, nullable: false),
                    Town = table.Column<string>(maxLength: 30, nullable: false),
                    County = table.Column<string>(maxLength: 30, nullable: false),
                    MobilePhoneNumber = table.Column<string>(maxLength: 12, nullable: false),
                    EmailAddress = table.Column<string>(nullable: false),
                    EmergencyMobilePhoneNumber = table.Column<string>(maxLength: 12, nullable: false),
                    StudentPPS = table.Column<string>(maxLength: 8, nullable: false),
                    ProgrammeFeePaid = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DateOfBirth = table.Column<DateTime>(nullable: false),
                    GenderType = table.Column<int>(nullable: false),
                    FullOrPartTime = table.Column<int>(nullable: false),
                    StudentProgrammeID = table.Column<string>(maxLength: 6, nullable: true),
                    LastUpdated = table.Column<DateTime>(nullable: false),
                    ProgrammeID = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.StudentID);
                    table.ForeignKey(
                        name: "FK_Students_Programmes_ProgrammeID",
                        column: x => x.ProgrammeID,
                        principalTable: "Programmes",
                        principalColumn: "ProgrammeID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Assessments_ModuleID",
                table: "Assessments",
                column: "ModuleID");

            migrationBuilder.CreateIndex(
                name: "IX_ProgrammeModules_ModuleID",
                table: "ProgrammeModules",
                column: "ModuleID");

            migrationBuilder.CreateIndex(
                name: "IX_Students_ProgrammeID",
                table: "Students",
                column: "ProgrammeID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Assessments");

            migrationBuilder.DropTable(
                name: "NewModules");

            migrationBuilder.DropTable(
                name: "ProgrammeModules");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "Modules");

            migrationBuilder.DropTable(
                name: "Programmes");
        }
    }
}
