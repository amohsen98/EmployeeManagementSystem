using Microsoft.EntityFrameworkCore;

namespace EmployeeManagementSystem.Models
{
    public class ApplicationDbContext : DbContext

    {//
        public ApplicationDbContext() : base()
        {
            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server= .; Database = Company; Trusted_Connection=True; TrustServerCertificate=True");

            base.OnConfiguring(optionsBuilder);
        }
        public DbSet<Employee> Employee { get; set; }

        public DbSet<Department> Department { get; set; }  
    }
}
