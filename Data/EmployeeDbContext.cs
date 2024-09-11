using employee_management_backend.Models.Domains;
using Microsoft.EntityFrameworkCore;

namespace employee_management_backend.Data
{
    public class EmployeeDbContext : DbContext
    {
        public EmployeeDbContext(DbContextOptions<EmployeeDbContext> dbContextOptions) : base(dbContextOptions)
        {
        }

        public DbSet<Department> Departments { get; set; }

        public DbSet<GenderType> GenderTypes { get; set; }

        public DbSet<Employee> Employees { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Department>().HasData(
                new Department { Id = Guid.NewGuid(), DepartmentName = "IT" },
                new Department { Id = Guid.NewGuid(), DepartmentName = "Accounting" },
                new Department { Id = Guid.NewGuid(), DepartmentName = "HR" },
                new Department { Id = Guid.NewGuid(), DepartmentName = "Management" }
            );

            modelBuilder.Entity<GenderType>().HasData(
                new GenderType { Id = Guid.NewGuid(), Gender = "Male" },
                new GenderType { Id = Guid.NewGuid(), Gender = "Female" },
                new GenderType { Id = Guid.NewGuid(), Gender = "Other" }
            );

            base.OnModelCreating(modelBuilder);
        }
    }
}
