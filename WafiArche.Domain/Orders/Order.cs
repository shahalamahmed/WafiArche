using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WafiArche.Domain.Customers;
using WafiArche.Domain.Employees;
using WafiArche.Domain.OrderDetails;
using WafiArche.Domain.Shippers;

namespace WafiArche.Domain.Orders
{
    public class Order
    {
        public int OrderID { get; set; } // Primary key
        public int CustomerID { get; set; } // Foreign key to Customer table
        public Customer Customer { get; set; } // Relationship to Customer entity
        public int EmployeeID { get; set; } // Foreign key to Employee table
        public Employee Employee { get; set; } // Relationship to Employee entity
        public DateTime OrderDate { get; set; } // Order date
        public int ShipperID { get; set; } // Foreign key to Shipper table
        public Shipper Shipper { get; set; } // Relationship to Shipper entity 

        // Navigation property for OrderDetails
        public ICollection<OrderDetail> OrderDetails { get; set; }

    }

}
