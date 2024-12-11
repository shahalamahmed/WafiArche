using WafiArche.Application.Products.Dtos;
using WafiArche.Domain.Products;

namespace WafiArche.Application.Products
{
    public interface IProductAppService
    {
        ProductDto CreateProduct(ProductDto productDto);
        bool DeleteProduct(int id);
        IEnumerable<Product> GetAllProducts();
        Product GetProductById(int id);
        ProductDto UpdateProduct(int id, ProductDto updatedProductDto);
    }
}
