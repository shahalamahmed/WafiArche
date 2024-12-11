using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WafiArche.Domain.Customers
{
    public class Customer
    {
        [Key]
        public int CustomerID { get; set; } // Matches the database column name
        [Required]
        public string CustomerName { get; set; } // Matches the database column name
        public string ContactName { get; set; } // Matches the database column name
        public string Address { get; set; } // Matches the database column name
        public string City { get; set; } // Matches the database column name
        public string PostalCode { get; set; } // Matches the database column name
        public string Country { get; set; } // Matches the database column name
    }
}
