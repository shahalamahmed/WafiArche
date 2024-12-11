// IOrderAppService.cs
using System.Collections.Generic;
using System.Threading.Tasks;
using WafiArche.Application.Orders.Dtos;

namespace WafiArche.Application.Services
{
    public interface IOrderAppService
    {
        Task<List<OrderDto>> GetAllOrdersAsync();
        Task<OrderDto> GetOrderByIdAsync(int id);
        Task<OrderDto> CreateOrderAsync(OrderDto orderDto);
        Task<OrderDto> UpdateOrderAsync(int id, OrderDto orderDto);
        Task<bool> DeleteOrderAsync(int id);
    }
}