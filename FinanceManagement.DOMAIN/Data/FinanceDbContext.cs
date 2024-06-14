using FinanceManagement.DATA.Models;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace FinanceManagement.DOMAIN.Data
{
    public class FinanceDbContext : DbContext
    {
        public FinanceDbContext(DbContextOptions<FinanceDbContext> options) : base(options) {   }

        public DbSet<Project> Projects { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<EmployeeProjectsList> EmployeeProjectsList { get; set; }
        public DbSet<TimeSheets> TimeSheets { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure Role entity
            modelBuilder.Entity<Role>()
                .HasKey(r => r.RoleId); // Define RoleId as primary key

            // Configure Employee entity
            modelBuilder.Entity<Employee>()
                .HasOne(e => e.Roles)
                .WithMany(r => r.Employees)
                .HasForeignKey(e => e.RoleId)
                .OnDelete(DeleteBehavior.Restrict); // Ensures no cascade delete on Role deletion

            modelBuilder.Entity<Employee>()
                .HasOne(e => e.ProjectManager)
                .WithMany(e => e.ManagedEmployees)
                .HasForeignKey(e => e.ProjectManagerId)
                .OnDelete(DeleteBehavior.Restrict); // Ensures no cascade delete on ProjectManager deletion
        }
    }
}
