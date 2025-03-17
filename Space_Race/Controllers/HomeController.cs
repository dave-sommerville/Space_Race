using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Space_Race.BLL;
using Space_Race.Models;

namespace Space_Race.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly TournamentService _tournamentService;
        private readonly DriverService _driverService;
        private readonly VehicleService _vehicleService;

        public HomeController(ILogger<HomeController> logger, TournamentService tournamentService, DriverService driverService, VehicleService vehicleService)
        {
            _logger = logger;
            _tournamentService = tournamentService;
            _driverService = driverService;
            _vehicleService = vehicleService;
        }

        public IActionResult Index()
        {
            var model = new HomeIndexViewModel
            {
                TournamentCount = _tournamentService.GetTournamentCount(),
                DriverCount = _driverService.GetDriverCount(),
                VehicleCount = _vehicleService.GetVehicleCount(),
                NumberOneDrivers = _tournamentService.GetNumberOneDrivers()
            };
            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
