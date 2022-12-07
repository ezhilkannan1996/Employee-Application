using EmployeeAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeAPI.Data
{
    public class employeeApiDbContext:DbContext
    {
        public employeeApiDbContext(DbContextOptions options):base(options) 
        {

        }

        public DbSet<EmpData> Emps { get; set; }
    }
}
