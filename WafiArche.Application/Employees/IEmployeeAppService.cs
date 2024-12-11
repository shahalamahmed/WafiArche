using System.Collections.Generic;
using WafiArche.Application.Employees.Dtos;

namespace WafiArche.Application.Employees
{
    public interface IEmployeeAppService
    {
        EmployeeDto CreateEmployee(EmployeeDto employeeDto);
        EmployeeDto UpdateEmployee(int id, EmployeeDto updatedEmployeeDto);
        bool DeleteEmployee(int id);
        IEnumerable<EmployeeDto> GetAllEmployees();
        EmployeeDto GetEmployeeById(int id);
    }
}
