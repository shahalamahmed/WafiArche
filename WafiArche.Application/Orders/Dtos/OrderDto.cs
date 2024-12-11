// OrderDto.cs
using System;
using System.Collections.Generic;

namespace WafiArche.Application.Orders.Dtos
{
    public class OrderDto
    {
        public int OrderID { get; set; }
        public int CustomerID { get; set; }
        public int EmployeeID { get; set; }
        public DateTime OrderDate { get; set; }
        public int ShipperID { get; set; }
        public List<OrderDetailDto> OrderDetails { get; set; }
    }

    public class OrderDetailDto
    {
        public int ProductID { get; set; }
        public int Quantity { get; set; }
    }
}