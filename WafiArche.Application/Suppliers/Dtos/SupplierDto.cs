using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WafiArche.Application.Suppliers.Dtos
{
    public class SupplierDto
    {
        public string SupplierName { get; set; } // Name of the supplier
        public string ContactName { get; set; } // Contact person at the supplier
        public string Address { get; set; } // Supplier's address
        public string City { get; set; } // City where the supplier is located
        public string PostalCode { get; set; } // Postal code of the supplier's address
        public string Country { get; set; } // Country of the supplier
        public string Phone { get; set; } // Phone number of the supplier
    }
}
