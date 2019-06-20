using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


namespace TRHDipComp_Project.Models
{
    public class CollegeDbContext : DbContext
    {
        public CollegeDbContext(DbContextOptions<CollegeDbContext> options)
    : base(options)
        { }

        public DbSet<Student> Students { get; set; }

        public DbSet<Programme> Programmes { get; set; }

        public DbSet<Module> Modules { get; set; }

        public DbSet<ProgrammeModule> ProgrammeModules { get; set; }

        public DbSet<Assessment> Assessments { get; set; }

        public DbSet<AssessmentResult> AssessmentResults { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            // Configure ProgrammeModule composite key
            modelBuilder.Entity<ProgrammeModule>().HasKey(t => new { t.ProgrammeID, t.ModuleID });

            // Configure ProgrammeModule composite key
            // modelBuilder.Entity<AssessmentResult>().HasForeignKey(t => new { t.ProgrammeID, t.ModuleID });
            // modelBuilder.Entity<AssessmentResult>().HasMany(t => t.ProgrammeID);
            // modelBuilder.Entity<ProgrammeModule>().HasOne(p => p.AssessmentResults).HasForeignKey            

            //.HasForeignKey(t => t.ProgrammeID);

            //builder.Entity<Person>().HasOne(v => v.Address).HasForeignKey(v => v.AddressId); 
            // modelBuilder.Entity<AssessmentResult>().HasForeignKey()

            // Extend models to include a LastUpdated date shadow property
            modelBuilder.Entity<Student>()
                .Property<DateTime>("LastUpdated");
            modelBuilder.Entity<Programme>()
                .Property<DateTime>("LastUpdated");
            modelBuilder.Entity<ProgrammeModule>()
                .Property<DateTime>("LastUpdated");
            modelBuilder.Entity<Module>()
                .Property<DateTime>("LastUpdated");
            modelBuilder.Entity<Assessment>()
                .Property<DateTime>("LastUpdated");

            // modelBuilder.Entity<Course>()
            //   .HasRequired(c => c.Department)
            //   .WithMany(t => t.Courses)
            //   .Map(m => m.MapKey("ChangedDepartmentID"));


            // modelBuilder.Entity<Programme>()
            //    .HasRequired(c => c.ProgrammeModule)
            //    .WithMany(t => t.Courses)
            //    .Map(m => m.MapKey("ChangedDepartmentID"));

            // modelBuilder.Entity<Student>().H

            //            .HasRequired(p => p.Programme)
            //            .WithMany()
            //            .HasForeignKey(p => p.ProgrammeID)
            //            .WillCascadeOnDelete(false);

        }

        // Set values via the ChangeTracker API through its Entries() method. 
        // Update "LastUpdated" property value for all entities by overriding the SaveChanges method.
        public override int SaveChanges()
        {
            ChangeTracker.DetectChanges();

            foreach (var entry in ChangeTracker.Entries())
            {
                if (entry.State == EntityState.Added || entry.State == EntityState.Modified)
                {
                    entry.Property("LastUpdated").CurrentValue = DateTime.UtcNow.Date;
                }
            }
            return base.SaveChanges();
        }
    }
}