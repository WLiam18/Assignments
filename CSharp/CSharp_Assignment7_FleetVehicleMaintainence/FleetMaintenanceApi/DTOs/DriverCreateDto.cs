using System.ComponentModel.DataAnnotations;

namespace FleetMaintenanceApi.DTOs
{
    public class DriverCreateDto
    {
        [Required]
        public string DriverName { get; set; }

        [Required]
        public string LicenseNumber { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

        [Required]
        public string City { get; set; }

        public bool IsAvailable { get; set; }
    }
}