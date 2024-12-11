using Microsoft.AspNetCore.Mvc;
using WafiArche.Application.Products;
using WafiArche.Application.Products.Dtos;
using WafiArche.Domain.Products;

namespace WafiArche.Api.Products
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductAppService _productAppService;

        public ProductController(IProductAppService productAppService)
        {
            _productAppService = productAppService;
        }
        [HttpPost]
        public ActionResult<ProductDto> CreateProduct(ProductDto product)
        {
            var createdProduct = _productAppService.CreateProduct(product);
            return Ok(createdProduct);
        }
        [HttpGet]
        public IActionResult GetAllProducts()
        {
            var products = _productAppService.GetAllProducts();
            return Ok(products);
        }


        [HttpGet("{id}")]
        public IActionResult GetProductById(int id)
        {
            try
            {
                var product = _productAppService.GetProductById(id);
                return Ok(product);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }


        [HttpPut("{id}")]
        public IActionResult UpdateProduct(int id, [FromBody] ProductDto updatedProductDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var updatedProduct = _productAppService.UpdateProduct(id, updatedProductDto);
                return Ok(updatedProduct);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }


        // Delete Product
        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(int id)
        {
            try
            {
                _productAppService.DeleteProduct(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
