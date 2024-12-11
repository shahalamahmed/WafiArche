using System.Collections.Generic;
using WafiArche.Application.Shippers.Dtos;

namespace WafiArche.Application.Shippers
{
    public interface IShipperAppService
    {
        ShipperDto CreateShipper(ShipperDto shipperDto);
        IEnumerable<ShipperDto> GetAllShippers();
        ShipperDto GetShipperById(int id);
        ShipperDto UpdateShipper(int id, ShipperDto updatedShipperDto);
        void DeleteShipper(int id);
    }
}
