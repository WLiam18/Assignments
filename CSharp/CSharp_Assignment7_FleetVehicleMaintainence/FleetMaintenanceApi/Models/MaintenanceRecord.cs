using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FleetMaintenanceApi.Models
{
    public class MaintenanceRecord
    {
        [Key]
        public int MaintenanceId { get; set; }
        public int VehicleId { get; set; }
        public int DriverId { get; set; }
        public DateOnly ServiceDate { get; set; }
        public string ServiceType { get; set; }
        public decimal ServiceCost { get; set; }
        public string ServiceStatus { get; set; }
        public string? Remarks { get; set; }
        public DateTime CreatedDate { get; set; }

        public Vehicle Vehicle { get; set; }
        public Driver Driver { get; set; }
    }
}