using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PerformanceAppraisalService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PerformanceAppraisalService.Infrastructure.Data
{
    public class ApplicationDbContext: IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PanelReviwer>()
                .HasKey(t => new { t.PanelId, t.ReviwerId });

            modelBuilder.Entity<PanelReviwer>()
                .HasOne(pt => pt.Panel)
                .WithMany(p => p.PanelReviwers)
                .HasForeignKey(pt => pt.PanelId);

            modelBuilder.Entity<PanelReviwer>()
                .HasOne(pt => pt.Reviwer)
                .WithMany(t => t.PanelReviwers)
                .HasForeignKey(pt => pt.ReviwerId);

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<Organization> Organizations { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Designation> Designations { get; set; }
        public DbSet<Salary> Salarys { get; set; }
        public DbSet<Panel> Panels { get; set; }
        public DbSet<Reviwer> Reviwers { get; set; }
        public DbSet<Reviwee> Reviewees { get; set; }

    }


}
