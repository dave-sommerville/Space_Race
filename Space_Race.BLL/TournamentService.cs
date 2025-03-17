using Space_Race.DAL;
using Space_Race.Models;

namespace Space_Race.BLL
{
    public class TournamentService
    {
        private readonly TournamentRepository _tournamentRepository;
        private readonly DriverService _driverService;
        public TournamentService(TournamentRepository tournamentRepository, DriverService driverService)
        {
            _tournamentRepository = tournamentRepository;
            _driverService = driverService;
        }
        public void RandomlyAssignDrivers(Tournament tournament)
        {
            var drivers = tournament.Drivers.OrderBy(x => Guid.NewGuid()).ToList();
            if (drivers.Count >= 3)
            {
                tournament.TourFirstPlace = drivers[0];
                tournament.TourSecondPlace = drivers[1];
                tournament.TourThirdPlace = drivers[2];
            }
            _tournamentRepository.UpdateTournament(tournament);
        }
        public int GetTournamentCount()
        {
            return _tournamentRepository.GetAllTournaments().Count;
        }

        public List<Driver> GetNumberOneDrivers()
        {
            return _tournamentRepository.GetAllTournaments()
                .Where(t => t.TourFirstPlace != null)
                .Select(t => t.TourFirstPlace)
                .Distinct()
                .ToList();
        }

        public List<Tournament> GetTournaments()
        {
            return _tournamentRepository.GetAllTournaments();
        }
        public Tournament GetTournamentById(int id)
        {
            return _tournamentRepository.GetTournamentById(id);
        }
        public void AddTournament(Tournament tournament)
        {
            if (string.IsNullOrWhiteSpace(tournament.Title))
            {
                throw new ArgumentException("Title is required");
            }
            _tournamentRepository.AddTournament(tournament);
        }
        public void UpdateTournament(Tournament tournament)
        {
            if (string.IsNullOrWhiteSpace(tournament.Title))
            {
                throw new ArgumentException("Title is required");
            }
            _tournamentRepository.UpdateTournament(tournament);
        }
        public void DeleteTournament(int id)
        {
            _tournamentRepository.DeleteTournament(id);
        }
    }
}
