namespace FleetMaintenanceApi.DTOs
{
    public class DriverResponseDto
    {
        public int DriverId { get; set; }
        public string DriverName { get; set; }
        public string LicenseNumber { get; set; }
        public string PhoneNumber { get; set; }
        public string City { get; set; }
        public bool IsAvailable { get; set; }
    }
}