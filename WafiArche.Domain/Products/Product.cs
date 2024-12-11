using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using WafiArche.Domain.Categories;
using WafiArche.Domain.Suppliers;

namespace WafiArche.Domain.Products
{
    public class Product
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public int CategoryID { get; set; }
        public Category Category { get; set; }
        public int SupplierID { get; set; }
        public Supplier Supplier { get; set; }
        public string Unit { get; set; }
        public decimal Price { get; set; }

        // Navigation properties
    }
}

