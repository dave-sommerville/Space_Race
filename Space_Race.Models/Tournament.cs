namespace Space_Race.Models
{
    public class Tournament
    {
        public int TournamentId { get; set; }
        public string Title { get; set; }
        public List<int> RaceWinners { get; set; }
        public List<Driver> Drivers { get; set; }
        public int? TourFirstPlaceId { get; set; }
        public Driver? TourFirstPlace { get; set; }
        public int? TourSecondPlaceId { get; set; }
        public Driver? TourSecondPlace { get; set; }
        public int? TourThirdPlaceId { get; set; }
        public Driver? TourThirdPlace { get; set; }

    }
}
