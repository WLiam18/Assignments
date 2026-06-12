using System.ComponentModel.DataAnnotations;

namespace FleetMaintenanceApi.DTOs
{
    public class MaintenanceCreateDto
    {
        public int VehicleId { get; set; }
        public int DriverId { get; set; }
        public DateOnly ServiceDate { get; set; }

        [Required]
        public string ServiceType { get; set; }

        [Range(0.01, double.MaxValue, ErrorMessage = "Service cost must be greater than 0")]
        public decimal ServiceCost { get; set; }

        [Required]
        public string ServiceStatus { get; set; }

        public string? Remarks { get; set; }
    }
}