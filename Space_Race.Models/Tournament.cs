using System.ComponentModel.DataAnnotations;

namespace Space_Race.Models
{
    public class Tournament
    {
        public int TournamentId { get; set; }
        [Required]
        public string Title { get; set; }
        public List<Driver> Drivers { get; set; } = new List<Driver>();
        public int? TourFirstPlaceId { get; set; }
        public Driver? TourFirstPlace { get; set; }
        public int? TourSecondPlaceId { get; set; }
        public Driver? TourSecondPlace { get; set; }
        public int? TourThirdPlaceId { get; set; }
        public Driver? TourThirdPlace { get; set; }

    }
}
