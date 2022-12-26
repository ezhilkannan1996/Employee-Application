using Microsoft.AspNetCore.Mvc;
using EmployeeAPI.Data;
using EmployeeAPI.Models;
using EmployeeAPI.Interfaces;

namespace EmployeeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpDatasController : ControllerBase
    {
        private readonly IEmployee _IContext;

        private readonly EmployeeDataContext _context;

        public EmpDatasController(EmployeeDataContext context, IEmployee IContext)
        {
            _context = context;
            _IContext = IContext;
        }

        // GET: api/EmpDatas
        [HttpGet]
        public List<EmpData> GetAllEmployee()
        {
            var employees = _IContext.getAll();
            return employees;
        }

        //GET: api/EmpDatas/5
        [HttpGet("{id}")]
        public EmpData GetEmpById([Bind] int id)
        {
            EmpData employee = _IContext.GetEmployee(id);
            return employee;
        }

        // PUT: api/EmpDatas/5
        [HttpPut("{id}")]
        public EmpData UpdateEmployee([Bind] EmpData Obj)
        {
            _IContext.UpdateEmployee(Obj);
            return Obj;
        }

        // POST: api/EmpDatas
        [HttpPost]
        public EmpData AddEmployee([FromBody] EmpData Obj)
        {
            _IContext.AddEmployee(Obj);
            return Obj;
        }

        // DELETE: api/EmpDatas/5
        [HttpDelete("{id}")]
        public IActionResult DeleteEmployee([Bind] int id)
        {
            _IContext.DeleteEmployee(id);
            return NoContent();
        }
    }
}
