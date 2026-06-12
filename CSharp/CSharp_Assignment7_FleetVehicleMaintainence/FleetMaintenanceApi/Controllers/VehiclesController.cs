using FleetMaintenanceApi.DTOs;
using FleetMaintenanceApi.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FleetMaintenanceApi.Controllers
{
    [ApiController]
    [Route("api/vehicles")]
    public class VehiclesController : ControllerBase
    {
        private readonly IVehicleService _vehicleService;

        public VehiclesController(IVehicleService vehicleService)
        {
            _vehicleService = vehicleService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var vehicles = await _vehicleService.GetAllVehiclesAsync();
            return Ok(new { statusCode = 200, message = "Vehicles retrieved successfully", data = vehicles });
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            if (id <= 0)
                return BadRequest(new { statusCode = 400, message = "Invalid id" });

            var vehicle = await _vehicleService.GetVehicleByIdAsync(id);
            if (vehicle == null)
                return NotFound(new { statusCode = 404, message = "Vehicle not found" });

            return Ok(new { statusCode = 200, message = "Vehicle retrieved successfully", data = vehicle });
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] VehicleCreateDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var (success, message, data) = await _vehicleService.AddVehicleAsync(dto);
            return Ok(new { statusCode = 200, message, data });
        }
    }
}