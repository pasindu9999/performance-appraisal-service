using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PerformanceAppraisalService.Domain.Entities;

namespace PerformanceAppraisalService.Infrastructure.Data
{
    public class ApplicationDbContext: IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }
        


        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<Organization> Organizations { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Designation> Designations { get; set; }
        public DbSet<Salary> Salarys { get; set; }
        public DbSet<PAsheet> PAsheets { get; set; }
        public DbSet<Criteria_Group> Criteria_groups { get; set; }
        public DbSet<Criteria> Criterias { get; set; }
        public DbSet<Panel> Panels { get; set; }
        public DbSet<Reviwer> Reviwers { get; set; }
        public DbSet<Reviwee> Reviwees { get; set; }
        public DbSet<PanelReviwer> PanelReviwers { get; set; }
        public DbSet<Result> Results { get; set; }
        public DbSet<Image> Images { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>()
                .HasOne(e => e.Department)
                .WithOne(d => d.DepartmentHead)
                .HasForeignKey<Department>(e => e.DepartmentHeadId);

            modelBuilder.Entity<Employee>()
                .HasOne(e => e.Team)
                .WithOne(t => t.TeamLeader)
                .HasForeignKey<Team>(e => e.TeamLeaderId);

           /* modelBuilder.Entity<PanelReviwer>()
                .HasKey(t => new { t.PanelId, t.ReviwerId });

            modelBuilder.Entity<PanelReviwer>()
                .HasOne(pt => pt.Panel)
                .WithMany(p => p.PanelReviwers)
                .HasForeignKey(pt => pt.PanelId);

            modelBuilder.Entity<PanelReviwer>()
                .HasOne(pt => pt.Reviwer)
                .WithMany(t => t.PanelReviwers)
                .HasForeignKey(pt => pt.ReviwerId); */

            base.OnModelCreating(modelBuilder);
        }

  

    }


}
