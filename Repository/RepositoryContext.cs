using Entities;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repository.Configuration;

namespace Repository
{
    public class RepositoryContext : DbContext
    {
        DbSet<Employee> Employees { get; set; }
        DbSet<Company> Companies { get; set; }

        public RepositoryContext(DbContextOptions options) : base(options)
        {
        }

        protected RepositoryContext()
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CompanyConfiguration());
            modelBuilder.ApplyConfiguration(new EmployeeConfiguration());
        }
    }
}
