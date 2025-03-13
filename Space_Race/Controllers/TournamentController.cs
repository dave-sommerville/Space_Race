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
            return View(tournaments);
        }
        [HttpGet]
        public IActionResult Create()
        {
            var drivers = _driverService.GetDrivers();
            ViewBag.Drivers = drivers;
            return View(new Tournament{ Title = string.Empty });
        }
        [HttpPost]
        public IActionResult Create(Tournament tournament, List<int> selectedDriverIds)
        {
            if(selectedDriverIds == null)
            {
                ModelState.AddModelError("Drivers", "At least one driver must be selected.");
            }
            if (ModelState.IsValid)
            {
                tournament.Drivers = _driverService.GetDrivers()
                    .Where(d => selectedDriverIds.Contains(d.DriverId))
                    .ToList();
                _tournamentService.AddTournament(tournament);
                return RedirectToAction("Index");
            }
            ViewBag.Drivers = _driverService.GetDrivers();
            return View(tournament);
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            Tournament tournament = _tournamentService.GetTournamentById(id);
            if (tournament == null)
            {
                return NotFound();
            }
            var drivers = _driverService.GetDrivers();
            ViewBag.Drivers = drivers;
            return View(tournament);
        }

        [HttpPost]
        public IActionResult Edit(Tournament tournament, List<int> selectedDriverIds)
        {
            if (selectedDriverIds == null)
            {
                ModelState.AddModelError("Drivers", "At least one driver must be selected.");
            }
            if (ModelState.IsValid)
            {
                tournament.Drivers = _driverService.GetDrivers()
                    .Where(d => selectedDriverIds.Contains(d.DriverId))
                    .ToList();
                _tournamentService.UpdateTournament(tournament);
                return RedirectToAction("Index");
            }
            ViewBag.Drivers = _driverService.GetDrivers();
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
