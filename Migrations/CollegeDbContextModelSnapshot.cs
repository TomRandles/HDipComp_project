﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TRHDipComp_Project.Models.Database;

namespace TRHDipComp_Project.Migrations
{
    [DbContext(typeof(CollegeDbContext))]
    partial class CollegeDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("TRHDipComp_Project.Models.Assessment", b =>
                {
                    b.Property<string>("AssessmentID")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(6);

                    b.Property<string>("AssessmentDescription")
                        .HasMaxLength(200);

                    b.Property<string>("AssessmentName")
                        .IsRequired()
                        .HasMaxLength(30);

                    b.Property<int>("AssessmentTotalMark");

                    b.Property<int>("AssessmentType");

                    b.Property<DateTime>("LastUpdated");

                    b.Property<string>("ModuleID")
                        .HasMaxLength(6);

                    b.HasKey("AssessmentID");

                    b.HasIndex("ModuleID");

                    b.ToTable("Assessments");
                });

            modelBuilder.Entity("TRHDipComp_Project.Models.AssessmentResult", b =>
                {
                    b.Property<string>("AssessmentResultID")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("AssessmentDate");

                    b.Property<string>("AssessmentID")
                        .IsRequired()
                        .HasMaxLength(6);

                    b.Property<string>("AssessmentResultDescription")
                        .HasMaxLength(200);

                    b.Property<double>("AssessmentResultMark");

                    b.Property<DateTime>("LastUpdated");

                    b.Property<string>("ModuleID")
                        .IsRequired()
                        .HasMaxLength(6);

                    b.Property<string>("ProgrammeID")
                        .IsRequired()
                        .HasMaxLength(6);

                    b.Property<string>("StudentID")
                        .IsRequired()
                        .HasMaxLength(7);

                    b.HasKey("AssessmentResultID");

                    b.HasIndex("AssessmentID");

                    b.HasIndex("StudentID");

                    b.HasIndex("ProgrammeID", "ModuleID");

                    b.ToTable("AssessmentResults");
                });

            modelBuilder.Entity("TRHDipComp_Project.Models.Module", b =>
                {
                    b.Property<string>("ModuleID")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(6);

                    b.Property<DateTime>("LastUpdated");

                    b.Property<int>("ModuleCredits");

                    b.Property<string>("ModuleDescription")
                        .HasMaxLength(200);

                    b.Property<string>("ModuleName")
                        .IsRequired();

                    b.HasKey("ModuleID");

                    b.ToTable("Modules");
                });

            modelBuilder.Entity("TRHDipComp_Project.Models.Programme", b =>
                {
                    b.Property<string>("ProgrammeID")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(6);

                    b.Property<DateTime>("LastUpdated");

                    b.Property<decimal>("ProgrammeCost")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("ProgrammeCredits");

                    b.Property<string>("ProgrammeDescription")
                        .HasMaxLength(200);

                    b.Property<string>("ProgrammeName")
                        .IsRequired();

                    b.Property<int>("ProgrammeQQILevel");

                    b.HasKey("ProgrammeID");

                    b.ToTable("Programmes");
                });

            modelBuilder.Entity("TRHDipComp_Project.Models.ProgrammeModule", b =>
                {
                    b.Property<string>("ProgrammeID")
                        .IsConcurrencyToken();

                    b.Property<string>("ModuleID")
                        .IsConcurrencyToken();

                    b.Property<DateTime>("LastUpdated");

                    b.Property<string>("TeacherID")
                        .HasMaxLength(7);

                    b.HasKey("ProgrammeID", "ModuleID");

                    b.HasIndex("ModuleID");

                    b.HasIndex("TeacherID");

                    b.ToTable("ProgrammeModules");
                });

            modelBuilder.Entity("TRHDipComp_Project.Models.Student", b =>
                {
                    b.Property<string>("StudentID")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(7);

                    b.Property<string>("AddressOne")
                        .IsRequired();

                    b.Property<string>("AddressTwo")
                        .IsRequired();

                    b.Property<string>("County")
                        .IsRequired();

                    b.Property<DateTime>("DateOfBirth");

                    b.Property<string>("EmailAddress")
                        .IsRequired();

                    b.Property<string>("EmergencyMobilePhoneNumber")
                        .IsRequired();

                    b.Property<string>("FirstName")
                        .IsRequired();

                    b.Property<int>("FullOrPartTime");

                    b.Property<int>("GenderType");

                    b.Property<DateTime>("LastUpdated");

                    b.Property<string>("MobilePhoneNumber")
                        .IsRequired();

                    b.Property<decimal>("ProgrammeFeePaid")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("ProgrammeID")
                        .HasMaxLength(6);

                    b.Property<byte[]>("StudentImage");

                    b.Property<string>("StudentPPS")
                        .IsRequired();

                    b.Property<string>("SurName")
                        .IsRequired();

                    b.Property<string>("Town")
                        .IsRequired();

                    b.HasKey("StudentID");

                    b.HasIndex("ProgrammeID");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("TRHDipComp_Project.Models.Teacher", b =>
                {
                    b.Property<string>("TeacherID")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(7);

                    b.Property<string>("AddressOne")
                        .IsRequired();

                    b.Property<string>("AddressTwo")
                        .IsRequired();

                    b.Property<string>("County")
                        .IsRequired();

                    b.Property<string>("EmailAddress")
                        .IsRequired();

                    b.Property<string>("EmergencyMobilePhoneNumber")
                        .IsRequired();

                    b.Property<string>("FirstName")
                        .IsRequired();

                    b.Property<int>("FullOrPartTime");

                    b.Property<int>("GenderType");

                    b.Property<DateTime>("LastUpdated");

                    b.Property<string>("MobilePhoneNumber")
                        .IsRequired();

                    b.Property<string>("SurName")
                        .IsRequired();

                    b.Property<byte[]>("TeacherImage");

                    b.Property<string>("TeacherPPS")
                        .IsRequired()
                        .HasMaxLength(10);

                    b.Property<string>("Title");

                    b.Property<string>("Town")
                        .IsRequired();

                    b.HasKey("TeacherID");

                    b.ToTable("Teachers");
                });

            modelBuilder.Entity("TRHDipComp_Project.Models.Assessment", b =>
                {
                    b.HasOne("TRHDipComp_Project.Models.Module")
                        .WithMany("Assessments")
                        .HasForeignKey("ModuleID");
                });

            modelBuilder.Entity("TRHDipComp_Project.Models.AssessmentResult", b =>
                {
                    b.HasOne("TRHDipComp_Project.Models.Assessment")
                        .WithMany("AssessmentResults")
                        .HasForeignKey("AssessmentID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("TRHDipComp_Project.Models.Student")
                        .WithMany("AssessmentResults")
                        .HasForeignKey("StudentID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("TRHDipComp_Project.Models.ProgrammeModule")
                        .WithMany("AssessmentResults")
                        .HasForeignKey("ProgrammeID", "ModuleID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("TRHDipComp_Project.Models.ProgrammeModule", b =>
                {
                    b.HasOne("TRHDipComp_Project.Models.Module")
                        .WithMany("ProgrammeModules")
                        .HasForeignKey("ModuleID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("TRHDipComp_Project.Models.Programme")
                        .WithMany("ProgrammeModules")
                        .HasForeignKey("ProgrammeID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("TRHDipComp_Project.Models.Teacher")
                        .WithMany("ProgrammeModules")
                        .HasForeignKey("TeacherID");
                });

            modelBuilder.Entity("TRHDipComp_Project.Models.Student", b =>
                {
                    b.HasOne("TRHDipComp_Project.Models.Programme")
                        .WithMany("Students")
                        .HasForeignKey("ProgrammeID");
                });
#pragma warning restore 612, 618
        }
    }
}
