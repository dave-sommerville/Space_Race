namespace Space_Race.Models
{
    public class Vehicle
    {
        public int VehicleId { get; set; }
        public string Model { get; set; }
        public int? DriverId { get; set; }
        public Driver? Driver { get; set; }
    }
}
