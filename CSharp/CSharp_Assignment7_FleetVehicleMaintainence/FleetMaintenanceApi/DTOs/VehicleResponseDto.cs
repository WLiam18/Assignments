namespace FleetMaintenanceApi.DTOs
{
    public class VehicleResponseDto
    {
        public int VehicleId { get; set; }
        public string VehicleNumber { get; set; }
        public string VehicleType { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public int PurchaseYear { get; set; }
        public bool IsActive { get; set; }
    }
}