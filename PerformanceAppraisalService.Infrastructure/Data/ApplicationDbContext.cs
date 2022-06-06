using Create_Criteria_Group.Domain.Entities;
using Create_PA.domain.Entities;

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
        public DbSet<PA_Sheet> PA_lists { get; set; }
        public DbSet<Criteria_Group> Criteria_groups { get; set; }
        public DbSet<Criteria> Criterias { get; set; }


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

            base.OnModelCreating(modelBuilder);
        }
    }
    

}
