using Microsoft.AspNetCore.Mvc;
using Space_Race.BLL;
using Space_Race.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Space_Race.Controllers
{
    public class TournamentController : Controller
    {
        private readonly TournamentService _tournamentService;
        private readonly DriverService _driverService;
        public TournamentController(TournamentService tournamentService, DriverService driverService)
        {
            _tournamentService = tournamentService;
            _driverService = driverService;
        }
        [HttpGet]
        public IActionResult Index()
        {
            List<Tournament> tournaments = _tournamentService.GetTournaments();
            return View();
        }
        [HttpGet]
        public IActionResult Create()
        {
            List<Tournament> tournaments = _tournamentService.GetTournaments();
            return View();
        }
        [HttpPost]
        public IActionResult Create(Tournament tournament)
        {
            if (ModelState.IsValid)
            {
                _tournamentService.AddTournament(tournament);
                return RedirectToAction("Index");
            }
            List<Tournament> tournaments = _tournamentService.GetTournaments();
            return View(tournament);
        }
        [HttpPost]
        public IActionResult Edit(int id)
        {
            Tournament tournament = _tournamentService.GetTournamentById(id);
            if(tournament == null)
            {
                return NotFound();
            }
            List<Tournament> tournaments = _tournamentService.GetTournaments();
            return View(tournament);
        }
        [HttpPost]
        public IActionResult Edit(Tournament tournament)
        {
            if (ModelState.IsValid)
            {
                _tournamentService.UpdateTournament(tournament);
                return RedirectToAction("Index");
            }
            List<Tournament> tournaments = _tournamentService.GetTournaments();
            return View(tournament);
        }
        [HttpPost]
        public IActionResult Delete(int id)
        {
            _tournamentService.DeleteTournament(id);
            return RedirectToAction("Index");
        }
    }
}
