﻿using System;
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
                    ModuleName = table.Column<string>(nullable: false),
                    ModuleDescription = table.Column<string>(maxLength: 200, nullable: true),
                    ModuleCredits = table.Column<int>(nullable: false),
                    LastUpdated = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Modules", x => x.ModuleID);
                });

            migrationBuilder.CreateTable(
                name: "Programmes",
                columns: table => new
                {
                    ProgrammeID = table.Column<string>(maxLength: 6, nullable: false),
                    ProgrammeName = table.Column<string>(nullable: false),
                    ProgrammeDescription = table.Column<string>(maxLength: 200, nullable: true),
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
                name: "Teachers",
                columns: table => new
                {
                    TeacherID = table.Column<string>(maxLength: 7, nullable: false),
                    Title = table.Column<string>(nullable: true),
                    FirstName = table.Column<string>(nullable: false),
                    SurName = table.Column<string>(nullable: false),
                    AddressOne = table.Column<string>(nullable: false),
                    AddressTwo = table.Column<string>(nullable: false),
                    Town = table.Column<string>(nullable: false),
                    County = table.Column<string>(nullable: false),
                    MobilePhoneNumber = table.Column<string>(nullable: false),
                    EmailAddress = table.Column<string>(nullable: false),
                    EmergencyMobilePhoneNumber = table.Column<string>(nullable: false),
                    TeacherPPS = table.Column<string>(maxLength: 10, nullable: false),
                    GenderType = table.Column<int>(nullable: false),
                    FullOrPartTime = table.Column<int>(nullable: false),
                    TeacherImage = table.Column<byte[]>(nullable: true),
                    LastUpdated = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teachers", x => x.TeacherID);
                });

            migrationBuilder.CreateTable(
                name: "Assessments",
                columns: table => new
                {
                    AssessmentID = table.Column<string>(maxLength: 6, nullable: false),
                    AssessmentName = table.Column<string>(maxLength: 30, nullable: false),
                    AssessmentDescription = table.Column<string>(maxLength: 200, nullable: true),
                    AssessmentTotalMark = table.Column<int>(nullable: false),
                    AssessmentType = table.Column<int>(nullable: false),
                    ModuleID = table.Column<string>(maxLength: 6, nullable: true),
                    LastUpdated = table.Column<DateTime>(nullable: false)
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
                name: "Students",
                columns: table => new
                {
                    StudentID = table.Column<string>(maxLength: 7, nullable: false),
                    FirstName = table.Column<string>(nullable: false),
                    SurName = table.Column<string>(nullable: false),
                    AddressOne = table.Column<string>(nullable: false),
                    AddressTwo = table.Column<string>(nullable: false),
                    Town = table.Column<string>(nullable: false),
                    County = table.Column<string>(nullable: false),
                    MobilePhoneNumber = table.Column<string>(nullable: false),
                    EmailAddress = table.Column<string>(nullable: false),
                    EmergencyMobilePhoneNumber = table.Column<string>(nullable: false),
                    StudentPPS = table.Column<string>(nullable: false),
                    ProgrammeFeePaid = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DateOfBirth = table.Column<DateTime>(nullable: false),
                    GenderType = table.Column<int>(nullable: false),
                    FullOrPartTime = table.Column<int>(nullable: false),
                    StudentImage = table.Column<byte[]>(nullable: true),
                    ProgrammeID = table.Column<string>(maxLength: 6, nullable: true),
                    LastUpdated = table.Column<DateTime>(nullable: false)
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

            migrationBuilder.CreateTable(
                name: "ProgrammeModules",
                columns: table => new
                {
                    ProgrammeID = table.Column<string>(nullable: false),
                    ModuleID = table.Column<string>(nullable: false),
                    TeacherID = table.Column<string>(maxLength: 7, nullable: true),
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
                    table.ForeignKey(
                        name: "FK_ProgrammeModules_Teachers_TeacherID",
                        column: x => x.TeacherID,
                        principalTable: "Teachers",
                        principalColumn: "TeacherID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AssessmentResults",
                columns: table => new
                {
                    AssessmentResultID = table.Column<string>(nullable: false),
                    AssessmentResultDescription = table.Column<string>(maxLength: 200, nullable: true),
                    AssessmentResultMark = table.Column<double>(nullable: false),
                    StudentID = table.Column<string>(maxLength: 7, nullable: false),
                    ProgrammeID = table.Column<string>(maxLength: 6, nullable: false),
                    AssessmentDate = table.Column<DateTime>(nullable: false),
                    ModuleID = table.Column<string>(maxLength: 6, nullable: false),
                    AssessmentID = table.Column<string>(maxLength: 6, nullable: false),
                    LastUpdated = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssessmentResults", x => x.AssessmentResultID);
                    table.ForeignKey(
                        name: "FK_AssessmentResults_Assessments_AssessmentID",
                        column: x => x.AssessmentID,
                        principalTable: "Assessments",
                        principalColumn: "AssessmentID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AssessmentResults_Students_StudentID",
                        column: x => x.StudentID,
                        principalTable: "Students",
                        principalColumn: "StudentID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AssessmentResults_ProgrammeModules_ProgrammeID_ModuleID",
                        columns: x => new { x.ProgrammeID, x.ModuleID },
                        principalTable: "ProgrammeModules",
                        principalColumns: new[] { "ProgrammeID", "ModuleID" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AssessmentResults_AssessmentID",
                table: "AssessmentResults",
                column: "AssessmentID");

            migrationBuilder.CreateIndex(
                name: "IX_AssessmentResults_StudentID",
                table: "AssessmentResults",
                column: "StudentID");

            migrationBuilder.CreateIndex(
                name: "IX_AssessmentResults_ProgrammeID_ModuleID",
                table: "AssessmentResults",
                columns: new[] { "ProgrammeID", "ModuleID" });

            migrationBuilder.CreateIndex(
                name: "IX_Assessments_ModuleID",
                table: "Assessments",
                column: "ModuleID");

            migrationBuilder.CreateIndex(
                name: "IX_ProgrammeModules_ModuleID",
                table: "ProgrammeModules",
                column: "ModuleID");

            migrationBuilder.CreateIndex(
                name: "IX_ProgrammeModules_TeacherID",
                table: "ProgrammeModules",
                column: "TeacherID");

            migrationBuilder.CreateIndex(
                name: "IX_Students_ProgrammeID",
                table: "Students",
                column: "ProgrammeID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AssessmentResults");

            migrationBuilder.DropTable(
                name: "Assessments");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "ProgrammeModules");

            migrationBuilder.DropTable(
                name: "Modules");

            migrationBuilder.DropTable(
                name: "Programmes");

            migrationBuilder.DropTable(
                name: "Teachers");
        }
    }
}
