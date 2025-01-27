﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WafiArche.Domain.Categories;
using WafiArche.Domain.Suppliers;

namespace WafiArche.Application.Products.Dtos
{
    public class ProductDto
    {
        public string ProductName { get; set; }
        public int CategoryID { get; set; }
        public int SupplierID { get; set; }
        public string Unit { get; set; }
        public decimal Price { get; set; }
    }
}
