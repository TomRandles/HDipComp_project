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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Extend Programme and Student models to include a LastUpdated shadow property
            modelBuilder.Entity<Student>()
                .Property<DateTime>("LastUpdated");
            modelBuilder.Entity<Programme>()
                .Property<DateTime>("LastUpdated");


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
                    entry.Property("LastUpdated").CurrentValue = DateTime.UtcNow;
                }
            }
            return base.SaveChanges();
        }
    }
}