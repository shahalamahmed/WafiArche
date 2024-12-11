using WafiArche.Application.Customers.Dtos;
using WafiArche.Domain.Customers;

namespace WafiArche.Application.Customers
{
    public interface ICustomerAppService
    {
        Customer CreateCustomer(CustomerDto customerDto);
        IEnumerable<CustomerDto> GetAllCustomers(); // Get all customers
        CustomerDto GetCustomerById(int id); // Get customer by ID
        CustomerDto UpdateCustomer(int id, CustomerDto updatedCustomerDto); // Update a customer
        bool DeleteCustomer(int id); // Delete a customer
    }
}
