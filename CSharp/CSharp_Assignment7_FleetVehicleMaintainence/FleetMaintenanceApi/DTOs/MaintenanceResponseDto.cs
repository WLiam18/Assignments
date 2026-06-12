namespace FleetMaintenanceApi.DTOs
{
    public class MaintenanceResponseDto
    {
        public int MaintenanceId { get; set; }
        public int VehicleId { get; set; }
        public string VehicleNumber { get; set; }
        public string VehicleType { get; set; }
        public int DriverId { get; set; }
        public string DriverName { get; set; }
        public DateOnly ServiceDate { get; set; }
        public string ServiceType { get; set; }
        public decimal ServiceCost { get; set; }
        public string ServiceStatus { get; set; }
        public string? Remarks { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}