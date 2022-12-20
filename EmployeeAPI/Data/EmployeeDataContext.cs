using EmployeeAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeAPI.Data
{
    public class EmployeeDataContext:DbContext
    {
        public EmployeeDataContext(DbContextOptions options):base(options) 
        {

        }

        public DbSet<EmpData> Emp { get; set; }
    }
}
