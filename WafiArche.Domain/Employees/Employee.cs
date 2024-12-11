using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WafiArche.Domain.Employees
{
    public class Employee
    {
        [Key]
        public int EmployeeID { get; set; } // Primary Key
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public DateTime BirthDate { get; set; }
        public string Notes { get; set; } // Additional information about the employee
    }
}
