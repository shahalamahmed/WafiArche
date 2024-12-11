using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WafiArche.Application.Products.Dtos;
using WafiArche.Domain.Products;
using WafiArche.EntityFrameworkCore.Data;

namespace WafiArche.Application.Products
{
    public class ProductAppService : IProductAppService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public ProductAppService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public ProductDto CreateProduct(ProductDto productDto)
        {
            var categoryExists = _context.Categories.Any(c => c.CategoryID == productDto.CategoryID);
            if (!categoryExists)
            {
                throw new Exception($"Category with ID {productDto.CategoryID} does not exist.");
            }

            var supplierExists = _context.Suppliers.Any(s => s.SupplierID == productDto.SupplierID);
            if (!supplierExists)
            {
                throw new Exception($"Supplier with ID {productDto.SupplierID} does not exist.");
            }

            var product = _mapper.Map<Product>(productDto);

            _context.Products.Add(product);

            _context.SaveChanges();

            return _mapper.Map<ProductDto>(product);
        }



        public bool DeleteProduct(int id)
        {
            var product = _context.Products.FirstOrDefault(p => p.ProductID == id);
            if (product == null)
                throw new Exception($"Product with ID {id} not found.");

            _context.Products.Remove(product);
            _context.SaveChanges();
            return true;
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return _context.Products
                .Include(p => p.Category)
                .Include(p => p.Supplier)
                .ToList();
        }

        public Product GetProductById(int id)
        {
            var product = _context.Products
                .Include(p => p.Category)
                .Include(p => p.Supplier)
                .FirstOrDefault(p => p.ProductID == id);
            if (product == null)
                throw new Exception($"Product with ID {id} not found.");

            return product;
        }


        public ProductDto UpdateProduct(int id, ProductDto updatedProductDto)
        {
            var product = _context.Products.FirstOrDefault(p => p.ProductID == id);
            if (product == null)
            {
                throw new Exception($"Product with ID {id} not found.");
            }

            if (!_context.Categories.Any(c => c.CategoryID == updatedProductDto.CategoryID))
            {
                throw new Exception($"Category with ID {updatedProductDto.CategoryID} does not exist.");
            }

            if (!_context.Suppliers.Any(s => s.SupplierID == updatedProductDto.SupplierID))
            {
                throw new Exception($"Supplier with ID {updatedProductDto.SupplierID} does not exist.");
            }

            product.ProductName = !string.IsNullOrEmpty(updatedProductDto.ProductName) ? updatedProductDto.ProductName : product.ProductName;
            product.SupplierID = updatedProductDto.SupplierID != 0 ? updatedProductDto.SupplierID : product.SupplierID;
            product.CategoryID = updatedProductDto.CategoryID != 0 ? updatedProductDto.CategoryID : product.CategoryID;
            product.Unit = !string.IsNullOrEmpty(updatedProductDto.Unit) ? updatedProductDto.Unit : product.Unit;
            product.Price = updatedProductDto.Price != 0 ? updatedProductDto.Price : product.Price;

            _context.SaveChanges();

            return _mapper.Map<ProductDto>(product);
        }

    }
}
