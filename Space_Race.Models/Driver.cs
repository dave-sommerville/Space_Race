using System.ComponentModel.DataAnnotations;

namespace Space_Race.Models
{
    public class Driver
    {
        public int DriverId { get; set; }
        [Required]
        public required string Name { get; set; }
        public int? VehicleId { get; set; }
        public Vehicle? Vehicle { get; set; }
        public List<Tournament>? Tournaments { get; set; }
    }
}
