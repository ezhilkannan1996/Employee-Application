using EmployeeAPI.Data;
using EmployeeAPI.Interfaces;
using EmployeeAPI.Models;

namespace EmployeeAPI.Services
{
    public class EmployeeServices : IEmployee
    {
        public readonly employeeApiDbContext _context;
        public EmployeeServices(employeeApiDbContext context)
        {
            _context = context;
        }

        public List<EmpData> getAll()
        {
            var list = _context.Emps.ToList();
            return list;
        }

        public EmpData GetEmployee(int id)
        {
            var employee = _context.Emps.Find(id);
            return employee;
        }

        public int AddEmployee(EmpData Obj)
        {
            _context.Emps.Add(Obj);
            _context.SaveChanges();
            return 0;
        }

        public int UpdateEmployee(EmpData Obj)
        {
            _context.Emps.Update(Obj);
            _context.SaveChanges();
            return 0;
        }

        public int DeleteEmployee(int id)
        {
            var empData = _context.Emps.Find(id);
            _context.Emps.Remove(empData);
            _context.SaveChanges();
            return 0;
        }
    }
}
