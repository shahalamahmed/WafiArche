// OrderAppService.cs
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WafiArche.Application.Orders.Dtos;
using WafiArche.Domain.OrderDetails;
using WafiArche.Domain.Orders;
using WafiArche.EntityFrameworkCore.Data;

namespace WafiArche.Application.Services
{
    public class OrderAppService : IOrderAppService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public OrderAppService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<OrderDto>> GetAllOrdersAsync()
        {
            var orders = await _context.Orders
                .Include(o => o.Customer)
                .Include(o => o.Employee)
                .Include(o => o.Shipper)
                .Include(o => o.OrderDetails)
                .ThenInclude(od => od.Product)
                .ToListAsync();

            return _mapper.Map<List<OrderDto>>(orders);
        }

        public async Task<OrderDto> GetOrderByIdAsync(int id)
        {
            var order = await _context.Orders
                .Include(o => o.Customer)
                .Include(o => o.Employee)
                .Include(o => o.Shipper)
                .Include(o => o.OrderDetails)
                .ThenInclude(od => od.Product)
                .FirstOrDefaultAsync(o => o.OrderID == id);

            return order != null ? _mapper.Map<OrderDto>(order) : null;
        }

        public async Task<OrderDto> CreateOrderAsync(OrderDto orderDto)
        {
            ValidateOrderDependencies(orderDto);

            // Map order without adding OrderDetails yet
            var order = _mapper.Map<Order>(orderDto);
            order.OrderDetails = new List<OrderDetail>();

            // Map and add OrderDetails explicitly
            if (orderDto.OrderDetails != null && orderDto.OrderDetails.Any())
            {
                foreach (var detailDto in orderDto.OrderDetails)
                {
                    ValidateProduct(detailDto.ProductID);

                    // Map and add each detail
                    var orderDetail = _mapper.Map<OrderDetail>(detailDto);
                    order.OrderDetails.Add(orderDetail);
                }
            }

            // Add the order to the database context
            _context.Orders.Add(order);

            // Save changes to the database
            await _context.SaveChangesAsync();

            // Return the created order as a DTO
            return _mapper.Map<OrderDto>(order);
        }


        public async Task<OrderDto> UpdateOrderAsync(int id, OrderDto updatedOrderDto)
        {
            var order = await _context.Orders
                .Include(o => o.OrderDetails)
                .FirstOrDefaultAsync(o => o.OrderID == id);

            if (order == null)
                throw new Exception($"Order with ID {id} not found.");

            ValidateOrderDependencies(updatedOrderDto);

            order.CustomerID = updatedOrderDto.CustomerID;
            order.EmployeeID = updatedOrderDto.EmployeeID;
            order.OrderDate = updatedOrderDto.OrderDate;
            order.ShipperID = updatedOrderDto.ShipperID;

            order.OrderDetails.Clear();
            foreach (var detailDto in updatedOrderDto.OrderDetails)
            {
                ValidateProduct(detailDto.ProductID);
                order.OrderDetails.Add(_mapper.Map<OrderDetail>(detailDto));
            }

            await _context.SaveChangesAsync();

            return _mapper.Map<OrderDto>(order);
        }

        public async Task<bool> DeleteOrderAsync(int id)
        {
            var order = await _context.Orders.FirstOrDefaultAsync(o => o.OrderID == id);

            if (order == null)
                return false;

            _context.Orders.Remove(order);
            await _context.SaveChangesAsync();
            return true;
        }

        private void ValidateOrderDependencies(OrderDto orderDto)
        {
            if (!_context.Customers.Any(c => c.CustomerID == orderDto.CustomerID))
                throw new Exception($"Customer with ID {orderDto.CustomerID} does not exist.");

            if (!_context.Employees.Any(e => e.EmployeeID == orderDto.EmployeeID))
                throw new Exception($"Employee with ID {orderDto.EmployeeID} does not exist.");

            if (!_context.Shippers.Any(s => s.ShipperID == orderDto.ShipperID))
                throw new Exception($"Shipper with ID {orderDto.ShipperID} does not exist.");
        }

        private void ValidateProduct(int productId)
        {
            if (!_context.Products.Any(p => p.ProductID == productId))
                throw new Exception($"Product with ID {productId} does not exist.");
        }
    }
}