using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


namespace TRHDipComp_Project.Models.Database
{
    public class CollegeDbContext : DbContext
    {
        #region ctr_properties
        public CollegeDbContext(DbContextOptions<CollegeDbContext> options)
    : base(options)
        { }

        public DbSet<Student> Students { get; set; }

        public DbSet<Teacher> Teachers { get; set; }

        public DbSet<Programme> Programmes { get; set; }

        public DbSet<Module> Modules { get; set; }

        public DbSet<ProgrammeModule> ProgrammeModules { get; set; }

        public DbSet<Assessment> Assessments { get; set; }

        public DbSet<AssessmentResult> AssessmentResults { get; set; }

        #endregion

        #region model_creating
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            // Configure ProgrammeModule composite primary key
            modelBuilder.Entity<ProgrammeModule>().HasKey(t => new { t.ProgrammeID, t.ModuleID });

            // Extend models to include a LastUpdated date shadow property
            modelBuilder.Entity<Student>()
                .Property<DateTime>("LastUpdated");
            modelBuilder.Entity<Teacher>()
                .Property<DateTime>("LastUpdated");
            modelBuilder.Entity<Programme>()
                .Property<DateTime>("LastUpdated");
            modelBuilder.Entity<ProgrammeModule>()
                .Property<DateTime>("LastUpdated");
            modelBuilder.Entity<Module>()
                .Property<DateTime>("LastUpdated");
            modelBuilder.Entity<Assessment>()
                .Property<DateTime>("LastUpdated");
            modelBuilder.Entity<AssessmentResult>()
                .Property<DateTime>("LastUpdated");

        }
        #endregion

        #region save_changes
        // Set values via the ChangeTracker API through its Entries() method. 
        // Update "LastUpdated" property value for all entities by overriding the SaveChangesAsync method

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            ChangeTracker.DetectChanges();

            foreach (var entry in ChangeTracker.Entries())
            {
                if (entry.State == EntityState.Added || entry.State == EntityState.Modified)
                {
                    entry.Property("LastUpdated").CurrentValue = DateTime.Now;
                }
            }
            return await base.SaveChangesAsync(cancellationToken);
        }
        #endregion
    }
}