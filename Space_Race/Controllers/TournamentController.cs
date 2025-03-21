﻿using Microsoft.AspNetCore.Mvc;
using Space_Race.BLL;
using Space_Race.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Space_Race.Controllers
{
    public class TournamentController : Controller
    {
        private readonly TournamentService _tournamentService;
        private readonly DriverService _driverService;
        private readonly UserManager<IdentityUser> _userManager;
        
        public TournamentController(TournamentService tournamentService, DriverService driverService, UserManager<IdentityUser> userManager)
        {
            _tournamentService = tournamentService;
            _driverService = driverService;
            _userManager = userManager;
        }
        [Authorize]
        [HttpGet]
        public IActionResult Index()
        {
            List<Tournament> tournaments = _tournamentService.GetTournaments();
            return View(tournaments);
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult RandomlyAssignDrivers(int id)
        {
            var tournament = _tournamentService.GetTournamentById(id);
            if (tournament == null)
            {
                return NotFound();
            }
            _tournamentService.RandomlyAssignDrivers(tournament);
            return RedirectToAction("Edit", new { id = tournament.TournamentId });
        }
        [Authorize(Roles = "Admin")]

        [HttpGet]
        public  IActionResult Create()
        {
            var drivers = _driverService.GetDrivers();
            ViewBag.Drivers = drivers;
            return View(new Tournament { Title = string.Empty });
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult Create(Tournament tournament, List<int> selectedDriverIds)
        {
            if (selectedDriverIds == null || !selectedDriverIds.Any())
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
            var drivers = _driverService.GetDrivers();
            ViewBag.Drivers = drivers;
            return View(tournament);
        }
        [Authorize(Roles = "Admin")]
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
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult Edit(Tournament tournament, List<int> selectedDriverIds)
        {
            if (selectedDriverIds == null || !selectedDriverIds.Any())
            {
                ModelState.AddModelError("Drivers", "At least one driver must be selected.");
            }
            if (ModelState.IsValid)
            {
                tournament.Drivers = _driverService.GetDrivers()
                    .Where(d => selectedDriverIds.Contains(d.DriverId))
                    .Distinct()
                    .ToList();
                _tournamentService.UpdateTournament(tournament);
                return RedirectToAction("Index");
            }
            var drivers = _driverService.GetDrivers();
            ViewBag.Drivers = drivers;
            return View(tournament);
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult Delete(int id)
        {
            _tournamentService.DeleteTournament(id);
            return RedirectToAction("Index");
        }
    }
}
