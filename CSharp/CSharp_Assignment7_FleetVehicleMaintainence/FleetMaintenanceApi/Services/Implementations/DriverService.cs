using FleetMaintenanceApi.DTOs;
using FleetMaintenanceApi.Models;
using FleetMaintenanceApi.Repositories.Interfaces;
using FleetMaintenanceApi.Services.Interfaces;

namespace FleetMaintenanceApi.Services.Implementations
{
    public class DriverService : IDriverService
    {
        private readonly IDriverRepository _driverRepo;

        public DriverService(IDriverRepository driverRepo)
        {
            _driverRepo = driverRepo;
        }

        public async Task<List<DriverResponseDto>> GetAllDriversAsync()
        {
            var drivers = await _driverRepo.GetAllDriversAsync();
            var result = new List<DriverResponseDto>();

            foreach (var d in drivers)
            {
                result.Add(new DriverResponseDto
                {
                    DriverId = d.DriverId,
                    DriverName = d.DriverName,
                    LicenseNumber = d.LicenseNumber,
                    PhoneNumber = d.PhoneNumber,
                    City = d.City,
                    IsAvailable = d.IsAvailable
                });
            }

            return result;
        }

        public async Task<DriverResponseDto?> GetDriverByIdAsync(int driverId)
        {
            var driver = await _driverRepo.GetDriverByIdAsync(driverId);
            if (driver == null)
                return null;

            return new DriverResponseDto
            {
                DriverId = driver.DriverId,
                DriverName = driver.DriverName,
                LicenseNumber = driver.LicenseNumber,
                PhoneNumber = driver.PhoneNumber,
                City = driver.City,
                IsAvailable = driver.IsAvailable
            };
        }

        public async Task<(bool Success, string Message, DriverResponseDto? Data)> AddDriverAsync(DriverCreateDto dto)
        {
            var driver = new Driver
            {
                DriverName = dto.DriverName,
                LicenseNumber = dto.LicenseNumber,
                PhoneNumber = dto.PhoneNumber,
                City = dto.City,
                IsAvailable = dto.IsAvailable
            };

            await _driverRepo.AddDriverAsync(driver);

            var response = new DriverResponseDto
            {
                DriverId = driver.DriverId,
                DriverName = driver.DriverName,
                LicenseNumber = driver.LicenseNumber,
                PhoneNumber = driver.PhoneNumber,
                City = driver.City,
                IsAvailable = driver.IsAvailable
            };

            return (true, "Driver added successfully", response);
        }
    }
}