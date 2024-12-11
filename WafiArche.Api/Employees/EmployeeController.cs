using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WafiArche.Application.Employees;
using WafiArche.Application.Employees.Dtos;

namespace WafiArche.Api.Employees
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : Controller
    {
        private readonly IEmployeeAppService _employeeAppService;

        public EmployeeController(IEmployeeAppService employeeAppService)
        {
            _employeeAppService = employeeAppService;
        }

        [HttpPost]
        public ActionResult<EmployeeDto> CreateEmployee([FromBody] EmployeeDto employeeDto)
        {
            try
            {
                var createdEmployee = _employeeAppService.CreateEmployee(employeeDto);
                return Ok(createdEmployee);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public ActionResult<EmployeeDto> UpdateEmployee(int id, [FromBody] EmployeeDto updatedEmployeeDto)
        {
            try
            {
                var updatedEmployee = _employeeAppService.UpdateEmployee(id, updatedEmployeeDto);
                return Ok(updatedEmployee);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteEmployee(int id)
        {
            try
            {
                _employeeAppService.DeleteEmployee(id);
                return NoContent(); // HTTP 204
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpGet]
        public ActionResult<IEnumerable<EmployeeDto>> GetAllEmployees()
        {
            var employees = _employeeAppService.GetAllEmployees();
            return Ok(employees);
        }

        [HttpGet("{id}")]
        public ActionResult<EmployeeDto> GetEmployeeById(int id)
        {
            try
            {
                var employee = _employeeAppService.GetEmployeeById(id);
                return Ok(employee);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
