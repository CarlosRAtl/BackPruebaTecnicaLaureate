using BackEndPruebaTecnicsLaureate.Business;
using BackEndPruebaTecnicsLaureate.Models.Request;
using BackEndPruebaTecnicsLaureate.Models.ViewModel;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace BackEndPruebaTecnicsLaureate.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : Controller
    {
        [HttpGet("GetEmpleados")]
        public async ValueTask<ActionResult<VMEmployees>> GetEmployees()
        {
            BEmployee response = new();
            var listEmployees = await response.GetEmployees();
            if (!listEmployees.code)
            {
                return BadRequest(listEmployees);
            }
            return Ok(listEmployees);
        }

        [HttpPost("PostEmpleados")]
        public async ValueTask<ActionResult<VMGeneric>> PostEmployees([FromForm] RQEmloyee emloyee)
        {
            BEmployee response = new();
            var addEmployee = await response.PostEmployee(emloyee);
            if (!addEmployee.code)
            {
                return BadRequest(addEmployee);
            }
            return Ok(addEmployee);
        }

        [HttpPut("PutEmpleados")]
        public async ValueTask<ActionResult<VMGeneric>> PutEmployees(string id, [FromForm] UPEmployee employees)
        {
            BEmployee response = new();
            var updEmployee = await response.PutEmployee(id, employees);
            if (!updEmployee.code)
            {
                return BadRequest(updEmployee);
            }
            return Ok(updEmployee);
        }
        [HttpGet("GetEmpleadosById")]
        public async ValueTask<ActionResult<VMEmployees>> GetEmployeesById(string id)
        {
            BEmployee response = new();
            var getEmployeeById = await response.GetEmployeeById(id);
            if (!getEmployeeById.code)
            {
                return BadRequest(getEmployeeById);
            }
            return Ok(getEmployeeById);
        }
    }
}
