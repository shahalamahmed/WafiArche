using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WafiArche.Application.Products.Dtos;
using WafiArche.Application.Customers.Dtos; // Added for Customer DTO
using WafiArche.Domain.Products;
using WafiArche.Domain.Customers;
using WafiArche.Application.Categories.Dtos;
using WafiArche.Domain.Categories;
using WafiArche.Application.Suppliers.Dtos;
using WafiArche.Domain.Suppliers;
using WafiArche.Application.Employees.Dtos;
using WafiArche.Domain.Employees;
using WafiArche.Application.Shippers.Dtos;
using WafiArche.Domain.Shippers;
using WafiArche.Domain.Orders;
using WafiArche.Domain.OrderDetails;
using WafiArche.Application.Orders.Dtos;

namespace WafiArche.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ProductDto, Product>().ReverseMap();
            CreateMap<CustomerDto, Customer>().ReverseMap();
            CreateMap<CategoryDto, Category>().ReverseMap();
            CreateMap<SupplierDto, Supplier>().ReverseMap(); 
            CreateMap<EmployeeDto, Employee>().ReverseMap();
            CreateMap<ShipperDto, Shipper>().ReverseMap();
            // New mappings for Order and OrderDetail
            CreateMap<OrderDto, Order>().ReverseMap();
            CreateMap<OrderDetailDto, OrderDetail>().ReverseMap();
        }
    }
}
