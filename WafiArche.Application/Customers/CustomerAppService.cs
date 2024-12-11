using AutoMapper;
using WafiArche.Application.Customers.Dtos;
using WafiArche.Domain.Customers;
using WafiArche.EntityFrameworkCore.Data;

namespace WafiArche.Application.Customers
{
    public class CustomerAppService : ICustomerAppService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public CustomerAppService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public Customer CreateCustomer(CustomerDto customerDto)
        {
            var customer = _mapper.Map<Customer>(customerDto);

            // Do not set CustomerID manually
            _context.Customers.Add(customer);
            _context.SaveChanges();

            return customer;
        }


        public IEnumerable<CustomerDto> GetAllCustomers()
        {
            var customers = _context.Customers.ToList();
            return _mapper.Map<IEnumerable<CustomerDto>>(customers);
        }

        public CustomerDto GetCustomerById(int id)
        {
            var customer = _context.Customers.FirstOrDefault(c => c.CustomerID == id);
            if (customer == null)
                throw new Exception($"Customer with ID {id} not found.");

            return _mapper.Map<CustomerDto>(customer);
        }

        public CustomerDto UpdateCustomer(int id, CustomerDto updatedCustomerDto)
        {
            var customer = _context.Customers.FirstOrDefault(c => c.CustomerID == id);
            if (customer == null)
                throw new Exception($"Customer with ID {id} not found.");

            // Manually update the fields, excluding the primary key (CustomerID)
            customer.CustomerName = updatedCustomerDto.CustomerName;
            customer.ContactName = updatedCustomerDto.ContactName;
            customer.Address = updatedCustomerDto.Address;
            customer.City = updatedCustomerDto.City;
            customer.PostalCode = updatedCustomerDto.PostalCode;
            customer.Country = updatedCustomerDto.Country;

            _context.SaveChanges();
            return _mapper.Map<CustomerDto>(customer);
        }



        public bool DeleteCustomer(int id)
        {
            var customer = _context.Customers.FirstOrDefault(c => c.CustomerID == id);
            if (customer == null)
                throw new Exception($"Customer with ID {id} not found.");

            _context.Customers.Remove(customer);
            _context.SaveChanges();
            return true;
        }
    }
}
