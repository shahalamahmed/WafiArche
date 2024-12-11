using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using WafiArche.Application.Employees.Dtos;
using WafiArche.Domain.Employees;
using WafiArche.EntityFrameworkCore.Data;

namespace WafiArche.Application.Employees
{
    public class EmployeeAppService : IEmployeeAppService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public EmployeeAppService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public EmployeeDto CreateEmployee(EmployeeDto employeeDto)
        {
            var employee = _mapper.Map<Employee>(employeeDto);
            _context.Employees.Add(employee);
            _context.SaveChanges();
            return _mapper.Map<EmployeeDto>(employee);
        }

        public EmployeeDto UpdateEmployee(int id, EmployeeDto updatedEmployeeDto)
        {
            var employee = _context.Employees.FirstOrDefault(e => e.EmployeeID == id);
            if (employee == null)
                throw new Exception($"Employee with ID {id} not found.");

            // Update only non-default values from DTO
            employee.FirstName = !string.IsNullOrEmpty(updatedEmployeeDto.FirstName) ? updatedEmployeeDto.FirstName : employee.FirstName;
            employee.LastName = !string.IsNullOrEmpty(updatedEmployeeDto.LastName) ? updatedEmployeeDto.LastName : employee.LastName;
            employee.BirthDate = updatedEmployeeDto.BirthDate != default ? updatedEmployeeDto.BirthDate : employee.BirthDate;
            employee.Notes = !string.IsNullOrEmpty(updatedEmployeeDto.Notes) ? updatedEmployeeDto.Notes : employee.Notes;

            _context.SaveChanges();
            return _mapper.Map<EmployeeDto>(employee);
        }

        public bool DeleteEmployee(int id)
        {
            var employee = _context.Employees.FirstOrDefault(e => e.EmployeeID == id);
            if (employee == null)
                throw new Exception("Employee not found");

            _context.Employees.Remove(employee);
            _context.SaveChanges();
            return true;
        }

        public IEnumerable<EmployeeDto> GetAllEmployees()
        {
            var employees = _context.Employees.ToList();
            return _mapper.Map<IEnumerable<EmployeeDto>>(employees);
        }

        public EmployeeDto GetEmployeeById(int id)
        {
            var employee = _context.Employees.FirstOrDefault(e => e.EmployeeID == id);
            if (employee == null)
                throw new Exception($"Employee with ID {id} not found.");

            return _mapper.Map<EmployeeDto>(employee);
        }
    }
}
