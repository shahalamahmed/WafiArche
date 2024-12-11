using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WafiArche.Domain.Orders;
using WafiArche.Domain.Products;

namespace WafiArche.Domain.OrderDetails
{
    public class OrderDetail
    {
        public int OrderDetailID { get; set; } // Primary key

        public int OrderID { get; set; } // Foreign key to Order table
        public Order Order { get; set; } // Navigation property for Order

        public int ProductID { get; set; } // Foreign key to Product table
        public Product Product { get; set; } // Navigation property for Product

        public int Quantity { get; set; } // Quantity of the product in the order
    }
}
