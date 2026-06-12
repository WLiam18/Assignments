using FleetMaintenanceApi.DTOs;
using FleetMaintenanceApi.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FleetMaintenanceApi.Controllers
{
    [ApiController]
    [Route("api/drivers")]
    public class DriversController : ControllerBase
    {
        private readonly IDriverService _driverService;

        public DriversController(IDriverService driverService)
        {
            _driverService = driverService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var drivers = await _driverService.GetAllDriversAsync();
            return Ok(new { statusCode = 200, message = "Drivers retrieved successfully", data = drivers });
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            if (id <= 0)
                return BadRequest(new { statusCode = 400, message = "Invalid id" });

            var driver = await _driverService.GetDriverByIdAsync(id);
            if (driver == null)
                return NotFound(new { statusCode = 404, message = "Driver not found" });

            return Ok(new { statusCode = 200, message = "Driver retrieved successfully", data = driver });
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] DriverCreateDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var (success, message, data) = await _driverService.AddDriverAsync(dto);
            return Ok(new { statusCode = 200, message, data });
        }
    }
}