using Space_Race.Models;
using Microsoft.EntityFrameworkCore;
namespace Space_Race.DAL
{
    public class TournamentRepository
    {
        private readonly SpRaceDbContext _context;

        public TournamentRepository(SpRaceDbContext context)
        {
            _context = context;
        }
        public List<Tournament> GetAllTournaments()
        {
            return _context.Tournaments
                .Include(t => t.TourFirstPlace)
                .Include(t => t.TourSecondPlace)
                .Include(t => t.TourThirdPlace)
                .Include(t => t.Drivers)
                .ToList();
        }
        public Tournament GetTournamentById(int id)
        {
            return _context.Tournaments
                .Include(t => t.Drivers)
                .FirstOrDefault(t => t.TournamentId == id);
        }
        public void AddTournament(Tournament tournament)
        {
            _context.Tournaments.Add(tournament);
            _context.SaveChanges();
        }
        public void UpdateTournament(Tournament tournament)
        {
            _context.Tournaments.Update(tournament);
            _context.SaveChanges();
        }
        public void DeleteTournament(int id)
        {
            var tournament = _context.Tournaments.FirstOrDefault(t => t.TournamentId == id);
            if (tournament != null)
            {
                _context.Tournaments.Remove(tournament);
                _context.SaveChanges();
            }
        }
    }
}
