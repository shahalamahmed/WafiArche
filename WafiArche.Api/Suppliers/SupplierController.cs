using Microsoft.AspNetCore.Mvc;
using WafiArche.Application.Suppliers;
using WafiArche.Application.Suppliers.Dtos;

namespace WafiArche.Api.Suppliers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SupplierController : Controller
    {
        private readonly ISupplierAppService _supplierAppService;

        public SupplierController(ISupplierAppService supplierAppService)
        {
            _supplierAppService = supplierAppService;
        }

        [HttpPost]
        public ActionResult<SupplierDto> CreateSupplier(SupplierDto supplierDto)
        {
            var createdSupplier = _supplierAppService.CreateSupplier(supplierDto);
            return Ok(createdSupplier);
        }

        [HttpGet]
        public ActionResult<IEnumerable<SupplierDto>> GetAllSuppliers()
        {
            var suppliers = _supplierAppService.GetAllSuppliers();
            return Ok(suppliers);
        }

        [HttpGet("{id}")]
        public ActionResult<SupplierDto> GetSupplierById(int id)
        {
            var supplier = _supplierAppService.GetSupplierById(id);

            if (supplier == null)
            {
                return NotFound($"Supplier with ID {id} not found.");
            }

            return Ok(supplier);
        }

        [HttpPut("{id}")]
        public ActionResult<SupplierDto> UpdateSupplier(int id, SupplierDto updatedSupplierDto)
        {
            try
            {
                var supplier = _supplierAppService.UpdateSupplier(id, updatedSupplierDto);
                return Ok(supplier);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteSupplier(int id)
        {
            var deleted = _supplierAppService.DeleteSupplier(id);
            if (!deleted)
            {
                return NotFound($"Supplier with ID {id} not found.");
            }

            return NoContent();
        }
    }
}
