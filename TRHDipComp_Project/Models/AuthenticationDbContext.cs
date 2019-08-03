using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TRHDipComp_Project.Models
{
    // This class creates the DB context for the exclusive Authentication database instance
    // Identity Framework is used for Authentication. IdentityDbContext is the base class 
    // for the Entity Framework database
    public class AuthenticationDbContext : IdentityDbContext<IdentityUser>
    {
        public AuthenticationDbContext(DbContextOptions<AuthenticationDbContext> options)
    : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            #region  "Seed Data"

            // Seed data for authorisation management
            // Establish the identity roles required for the project
            modelBuilder.Entity<IdentityRole>().HasData(
                new { Id = "1", Name = "Student", NormalizedName = "STUDENT" },
                new { Id = "2", Name = "Teacher", NormalizedName = "TEACHER" },
                new { Id = "3", Name = "Admin", NormalizedName = "ADMIN" }
            );

            #endregion
        }
    }
}
