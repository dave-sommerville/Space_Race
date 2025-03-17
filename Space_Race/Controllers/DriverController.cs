using Microsoft.AspNetCore.Mvc;
using Space_Race.BLL;
using Space_Race.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace Space_Race.Controllers
{@*
    private readonly BandService _bandService;

    //this constructor is for before roles **********************
    //public BandController(BandService bandService) {
    //    _bandService = bandService;
    //}
    [Authorize]
    public IActionResult Index()
    {
        var bands = _bandService.GetBands();
        return View(bands);
    }


    // roles only *****************
    private readonly UserManager<IdentityUser> _userManager;
    public BandController(BandService bandService, UserManager<IdentityUser> userManager)
    {
        _bandService = bandService;
        _userManager = userManager;
    }

    [Authorize(Roles = "Admin")] // Admin-only acces@
    public async Task<IActionResult> ViewAllUsers()
    {
        var users = await _userManager.Users.ToListAsync();
        var userWithRoles = new List<UserWithRolesViewModel>();

        foreach (var user in users)
        {
            var roles = await _userManager.GetRolesAsync(user);
            userWithRoles.Add(new UserWithRolesViewModel
            {
                UserName = user.UserName,
                Email = user.Email,
                Roles = roles
            });
        }

        return View(userWithRoles);
    }
}*@
public class DriverController : Controller
    {
        private readonly DriverService _driverService;
        private readonly VehicleService _vehicleService;
        public DriverController(DriverService driverService, VehicleService vehicleService)
        {
            _driverService = driverService;
            _vehicleService = vehicleService;
        }
        [HttpGet]
        public IActionResult Index()
        {
            List<Driver> drivers = _driverService.GetDrivers();
            return View(drivers);
        }
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Vehicles = new SelectList(_vehicleService.GetVehicles(), "VehicleId", "Model");
            return View();
        }
        [HttpPost]
        public IActionResult Create(Driver driver)
        {
            if(ModelState.IsValid)
            {
                _driverService.AddDriver(driver);
                return RedirectToAction("Index");
            }
            ViewBag.Vehicles = new SelectList(_vehicleService.GetVehicles(), "VehicleId", "Model");
            return View(driver);
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            Driver driver = _driverService.GetDriverById(id);
            if(driver == null)
            {
                return NotFound();
            }
            ViewBag.Vehicles = new SelectList(_vehicleService.GetVehicles(), "VehicleId", "Model");
            return View(driver);
        }
        [HttpPost]
        public IActionResult Edit(Driver driver)
        {
            if (ModelState.IsValid)
            {
                _driverService.UpdateDriver(driver);
                return RedirectToAction("Index");
            }
            ViewBag.Vehicles = new SelectList(_vehicleService.GetVehicles(), "VehicleId", "Name");
            return View(driver);
        }
        [HttpPost]
        public IActionResult Delete(int id)
        {
            _driverService.DeleteDriver(id);
            return RedirectToAction("Index");
        }
    }
}
