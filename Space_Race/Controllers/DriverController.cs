using Microsoft.AspNetCore.Mvc;
using Space_Race.BLL;
using Space_Race.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics.Contracts;

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
