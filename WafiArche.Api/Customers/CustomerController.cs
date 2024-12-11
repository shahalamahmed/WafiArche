using Microsoft.AspNetCore.Mvc;
using WafiArche.Application.Customers;
using WafiArche.Application.Customers.Dtos;

namespace WafiArche.Api.Customers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : Controller
    {
        private readonly ICustomerAppService _customerAppService;

        public CustomerController(ICustomerAppService customerAppService)
        {
            _customerAppService = customerAppService;
        }

        // Create a new customer
        [HttpPost]
        public ActionResult<CustomerDto> CreateCustomer(CustomerDto customerDto)
        {
            var createdCustomer = _customerAppService.CreateCustomer(customerDto);
            return Ok(createdCustomer);
        }

        // Get all customers
        [HttpGet]
        public ActionResult<IEnumerable<CustomerDto>> GetAllCustomers()
        {
            var customers = _customerAppService.GetAllCustomers();
            return Ok(customers);
        }

        // Get a single customer by ID
        [HttpGet("{id}")]
        public ActionResult<CustomerDto> GetCustomerById(int id)
        {
            try
            {
                var customer = _customerAppService.GetCustomerById(id);
                return Ok(customer);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        // Update an existing customer
        [HttpPut("{id}")]
        public ActionResult<CustomerDto> UpdateCustomer(int id, CustomerDto updatedCustomerDto)
        {
            try
            {
                var customer = _customerAppService.UpdateCustomer(id, updatedCustomerDto);
                return Ok(customer);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        // Delete a customer
        [HttpDelete("{id}")]
        public IActionResult DeleteCustomer(int id)
        {
            try
            {
                _customerAppService.DeleteCustomer(id);
                return NoContent(); // HTTP 204
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
