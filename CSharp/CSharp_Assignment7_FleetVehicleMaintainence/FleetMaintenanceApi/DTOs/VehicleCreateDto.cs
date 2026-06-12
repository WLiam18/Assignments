using System.ComponentModel.DataAnnotations;

namespace FleetMaintenanceApi.DTOs
{
    public class VehicleCreateDto
    {
        [Required]
        public string VehicleNumber { get; set; }

        [Required]
        public string VehicleType { get; set; }

        [Required]
        public string Brand { get; set; }

        [Required]
        public string Model { get; set; }

        [Range(2001, 9999, ErrorMessage = "Purchase year must be greater than 2000")]
        public int PurchaseYear { get; set; }

        public bool IsActive { get; set; }
    }
}