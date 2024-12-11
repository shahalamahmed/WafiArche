using Microsoft.AspNetCore.Mvc;
using WafiArche.Application.Shippers;
using WafiArche.Application.Shippers.Dtos;

namespace WafiArche.Api.Shippers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShipperController : ControllerBase
    {
        private readonly IShipperAppService _shipperAppService;

        public ShipperController(IShipperAppService shipperAppService)
        {
            _shipperAppService = shipperAppService;
        }

        [HttpPost]
        public ActionResult<ShipperDto> CreateShipper([FromBody] ShipperDto shipperDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var createdShipper = _shipperAppService.CreateShipper(shipperDto);
            return Ok(createdShipper);
        }

        [HttpGet]
        public ActionResult<IEnumerable<ShipperDto>> GetAllShippers()
        {
            var shippers = _shipperAppService.GetAllShippers();
            return Ok(shippers);
        }

        [HttpGet("{id}")]
        public ActionResult<ShipperDto> GetShipperById(int id)
        {
            try
            {
                var shipper = _shipperAppService.GetShipperById(id);
                return Ok(shipper);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public ActionResult<ShipperDto> UpdateShipper(int id, [FromBody] ShipperDto updatedShipperDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var updatedShipper = _shipperAppService.UpdateShipper(id, updatedShipperDto);
                return Ok(updatedShipper);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteShipper(int id)
        {
            try
            {
                _shipperAppService.DeleteShipper(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
