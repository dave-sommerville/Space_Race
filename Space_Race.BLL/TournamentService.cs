using Space_Race.DAL;
using Space_Race.Models;

namespace Space_Race.BLL
{
    public class TournamentService
    {
        private readonly TournamentRepository _tournamentRepository;
        public TournamentService(TournamentRepository tournamentRepository)
        {
            _tournamentRepository = tournamentRepository;
        }
        public List<Tournament> GetTournaments()
        {
            return _tournamentRepository.GetAlTournaments();
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
