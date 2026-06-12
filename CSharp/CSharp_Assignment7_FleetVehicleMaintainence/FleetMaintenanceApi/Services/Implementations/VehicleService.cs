using FleetMaintenanceApi.DTOs;
using FleetMaintenanceApi.Models;
using FleetMaintenanceApi.Repositories.Interfaces;
using FleetMaintenanceApi.Services.Interfaces;

namespace FleetMaintenanceApi.Services.Implementations
{
    public class VehicleService : IVehicleService
    {
        private readonly IVehicleRepository _vehicleRepo;

        public VehicleService(IVehicleRepository vehicleRepo)
        {
            _vehicleRepo = vehicleRepo;
        }

        public async Task<List<VehicleResponseDto>> GetAllVehiclesAsync()
        {
            var vehicles = await _vehicleRepo.GetAllVehiclesAsync();
            var result = new List<VehicleResponseDto>();

            foreach (var v in vehicles)
            {
                result.Add(new VehicleResponseDto
                {
                    VehicleId = v.VehicleId,
                    VehicleNumber = v.VehicleNumber,
                    VehicleType = v.VehicleType,
                    Brand = v.Brand,
                    Model = v.Model,
                    PurchaseYear = v.PurchaseYear,
                    IsActive = v.IsActive
                });
            }

            return result;
        }

        public async Task<VehicleResponseDto?> GetVehicleByIdAsync(int vehicleId)
        {
            var vehicle = await _vehicleRepo.GetVehicleByIdAsync(vehicleId);
            if (vehicle == null)
                return null;

            return new VehicleResponseDto
            {
                VehicleId = vehicle.VehicleId,
                VehicleNumber = vehicle.VehicleNumber,
                VehicleType = vehicle.VehicleType,
                Brand = vehicle.Brand,
                Model = vehicle.Model,
                PurchaseYear = vehicle.PurchaseYear,
                IsActive = vehicle.IsActive
            };
        }

        public async Task<(bool Success, string Message, VehicleResponseDto? Data)> AddVehicleAsync(VehicleCreateDto dto)
        {
            var vehicle = new Vehicle
            {
                VehicleNumber = dto.VehicleNumber,
                VehicleType = dto.VehicleType,
                Brand = dto.Brand,
                Model = dto.Model,
                PurchaseYear = dto.PurchaseYear,
                IsActive = dto.IsActive
            };

            await _vehicleRepo.AddVehicleAsync(vehicle);

            var response = new VehicleResponseDto
            {
                VehicleId = vehicle.VehicleId,
                VehicleNumber = vehicle.VehicleNumber,
                VehicleType = vehicle.VehicleType,
                Brand = vehicle.Brand,
                Model = vehicle.Model,
                PurchaseYear = vehicle.PurchaseYear,
                IsActive = vehicle.IsActive
            };

            return (true, "Vehicle added successfully", response);
        }
    }
}