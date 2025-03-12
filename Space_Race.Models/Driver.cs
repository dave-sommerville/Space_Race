namespace Space_Race.Models
{
    public class Driver
    {
        public int DriverId { get; set; }
        public string Name { get; set; }
        public int? VehicleId { get; set; }
        public Vehicle? Vehicle { get; set; }
        public int TournamentId { get; set; }
    }
}
