using AutoMapper;
using WafiArche.Application.Suppliers.Dtos;
using WafiArche.Domain.Suppliers;
using WafiArche.EntityFrameworkCore.Data;

namespace WafiArche.Application.Suppliers
{
    public class SupplierAppService : ISupplierAppService
    {
        private readonly AppDbContext _dbContext;
        private readonly IMapper _mapper;

        public SupplierAppService(AppDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public SupplierDto CreateSupplier(SupplierDto supplierDto)
        {
            var supplier = _mapper.Map<Supplier>(supplierDto);

            _dbContext.Suppliers.Add(supplier);
            _dbContext.SaveChanges();

            return _mapper.Map<SupplierDto>(supplier);
        }

        public bool DeleteSupplier(int id)
        {
            var supplier = _dbContext.Suppliers.Find(id);
            if (supplier == null)
            {
                return false;
            }

            _dbContext.Suppliers.Remove(supplier);
            _dbContext.SaveChanges();
            return true;
        }

        public IEnumerable<SupplierDto> GetAllSuppliers()
        {
            var suppliers = _dbContext.Suppliers.ToList();
            return _mapper.Map<IEnumerable<SupplierDto>>(suppliers);
        }

        public SupplierDto GetSupplierById(int id)
        {
            var supplier = _dbContext.Suppliers.Find(id);
            if (supplier == null) return null;

            return _mapper.Map<SupplierDto>(supplier);
        }

        public SupplierDto UpdateSupplier(int id, SupplierDto updatedSupplierDto)
        {
            var supplier = _dbContext.Suppliers.Find(id);
            if (supplier == null)
            {
                throw new Exception($"Supplier with ID {id} not found.");
            }

            _mapper.Map(updatedSupplierDto, supplier);
            _dbContext.SaveChanges();

            return _mapper.Map<SupplierDto>(supplier);
        }
    }
}
