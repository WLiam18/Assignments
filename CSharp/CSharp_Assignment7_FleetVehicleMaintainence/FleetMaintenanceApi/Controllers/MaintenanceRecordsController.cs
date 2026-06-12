using FleetMaintenanceApi.DTOs;
using FleetMaintenanceApi.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FleetMaintenanceApi.Controllers
{
    [ApiController]
    [Route("api/maintenanceRecords")]
    public class MaintenanceRecordsController : ControllerBase
    {
        private readonly IMaintenanceService _maintenanceService;

        public MaintenanceRecordsController(IMaintenanceService maintenanceService)
        {
            _maintenanceService = maintenanceService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] MaintenanceFilterRequestDto filter)
        {
            var (success, message, data) = await _maintenanceService.GetPagedMaintenanceRecordsAsync(filter);

            if (!success)
                return BadRequest(new { statusCode = 400, message });

            return Ok(data);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] MaintenanceCreateDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var (success, message, data) = await _maintenanceService.AddMaintenanceRecordAsync(dto);

            if (!success)
                return BadRequest(new { statusCode = 400, message });

            return Ok(new { statusCode = 200, message, data });
        }

        // bonus 4 - update status
        [HttpPut("{id}/status")]
        public async Task<IActionResult> UpdateStatus(int id, [FromBody] string serviceStatus)
        {
            if (id <= 0)
                return BadRequest(new { statusCode = 400, message = "Invalid id" });

            if (string.IsNullOrWhiteSpace(serviceStatus))
                return BadRequest(new { statusCode = 400, message = "Status is required" });

            var (success, message, data) = await _maintenanceService.UpdateStatusAsync(id, serviceStatus);

            if (!success)
                return BadRequest(new { statusCode = 400, message });

            return Ok(new { statusCode = 200, message, data });
        }

        // bonus 5 - delete
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (id <= 0)
                return BadRequest(new { statusCode = 400, message = "Invalid id" });

            var (success, message) = await _maintenanceService.DeleteMaintenanceRecordAsync(id);

            if (!success)
                return BadRequest(new { statusCode = 400, message });

            return Ok(new { statusCode = 200, message });
        }
    }
}