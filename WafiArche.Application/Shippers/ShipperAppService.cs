using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using WafiArche.Application.Shippers.Dtos;
using WafiArche.Domain.Shippers;
using WafiArche.EntityFrameworkCore.Data;

namespace WafiArche.Application.Shippers
{
    public class ShipperAppService : IShipperAppService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public ShipperAppService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public ShipperDto CreateShipper(ShipperDto shipperDto)
        {
            var shipper = _mapper.Map<Shipper>(shipperDto);
            _context.Shippers.Add(shipper);
            _context.SaveChanges();

            return _mapper.Map<ShipperDto>(shipper);
        }

        public IEnumerable<ShipperDto> GetAllShippers()
        {
            var shippers = _context.Shippers.ToList();
            return _mapper.Map<IEnumerable<ShipperDto>>(shippers);
        }

        public ShipperDto GetShipperById(int id)
        {
            var shipper = _context.Shippers.FirstOrDefault(s => s.ShipperID == id);
            if (shipper == null)
                throw new Exception($"Shipper with ID {id} not found.");

            return _mapper.Map<ShipperDto>(shipper);
        }

        public ShipperDto UpdateShipper(int id, ShipperDto updatedShipperDto)
        {
            var shipper = _context.Shippers.FirstOrDefault(s => s.ShipperID == id);
            if (shipper == null)
                throw new Exception($"Shipper with ID {id} not found.");

            shipper.ShipperName = !string.IsNullOrEmpty(updatedShipperDto.ShipperName)
                                  ? updatedShipperDto.ShipperName
                                  : shipper.ShipperName;

            shipper.Phone = !string.IsNullOrEmpty(updatedShipperDto.Phone)
                            ? updatedShipperDto.Phone
                            : shipper.Phone;

            _context.SaveChanges();

            return _mapper.Map<ShipperDto>(shipper);
        }

        public void DeleteShipper(int id)
        {
            var shipper = _context.Shippers.FirstOrDefault(s => s.ShipperID == id);
            if (shipper == null)
                throw new Exception($"Shipper with ID {id} not found.");

            _context.Shippers.Remove(shipper);
            _context.SaveChanges();
        }
    }
}
