using EmployeeAPI.Models;

namespace EmployeeAPI.Interfaces
{
    public interface IEmployee
    {
        List<EmpData> getAll();
        EmpData GetEmployee(int id);
        int AddEmployee(EmpData Obj);
        int UpdateEmployee(EmpData Obj);
        int DeleteEmployee(int id);      
    }
}
