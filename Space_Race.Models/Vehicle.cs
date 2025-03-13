using System.ComponentModel.DataAnnotations;
namespace Space_Race.Models
{
    public class Vehicle
    {
        public int VehicleId { get; set; }
        [Required]
        public required string Model { get; set; }
        public Driver? Driver { get; set; }
    }
}
