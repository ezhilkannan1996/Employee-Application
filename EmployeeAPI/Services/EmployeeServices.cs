using EmployeeAPI.Data;
using EmployeeAPI.Interfaces;
using EmployeeAPI.Models;

namespace EmployeeAPI.Services
{
    public class EmployeeServices : IEmployee
    {
        public readonly EmployeeDataContext _context;
        public EmployeeServices(EmployeeDataContext context)
        {
            _context = context;
        }

        public List<EmpData> getAll()
        {
            var list = _context.Emp.ToList();
            return list;
        }

        public EmpData GetEmployee(int id)
        {
            var employee = _context.Emp.Find(id);
            return employee;
        }

        public int AddEmployee(EmpData Obj)
        {
            _context.Emp.Add(Obj);
            _context.SaveChanges();
            return 0;
        }

        public int UpdateEmployee(EmpData Obj)
        {
            _context.Emp.Update(Obj);
            _context.SaveChanges();
            return 0;
        }

        public int DeleteEmployee(int id)
        {
            var empData = _context.Emp.Find(id);
            _context.Emp.Remove(empData);
            _context.SaveChanges();
            return 0;
        }
    }
}
