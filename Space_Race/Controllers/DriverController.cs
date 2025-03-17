using Microsoft.AspNetCore.Mvc;
using Space_Race.BLL;
using Space_Race.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace Space_Race.Controllers
{
public class DriverController : Controller
    {
        private readonly DriverService _driverService;
        private readonly VehicleService _vehicleService;
        public DriverController(DriverService driverService, VehicleService vehicleService)
        {
            _driverService = driverService;
            _vehicleService = vehicleService;
        }
        [Authorize]
        [HttpGet]
        public IActionResult Index()
        {
            List<Driver> drivers = _driverService.GetDrivers();
            return View(drivers);
        }
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Vehicles = new SelectList(_vehicleService.GetVehicles(), "VehicleId", "Model");
            return View();
        }
        [Authorize(Roles = "Admin")]
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
        [Authorize(Roles = "Admin")]
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
        [Authorize(Roles = "Admin")]
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
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult Delete(int id)
        {
            _driverService.DeleteDriver(id);
            return RedirectToAction("Index");
        }
    }
}
