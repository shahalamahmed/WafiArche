using WafiArche.Application.Suppliers.Dtos;

namespace WafiArche.Application.Suppliers
{
    public interface ISupplierAppService
    {
        SupplierDto CreateSupplier(SupplierDto supplierDto);
        bool DeleteSupplier(int id);
        IEnumerable<SupplierDto> GetAllSuppliers();
        SupplierDto GetSupplierById(int id);
        SupplierDto UpdateSupplier(int id, SupplierDto updatedSupplierDto);
    }
}
