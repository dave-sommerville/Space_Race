using Space_Race.BLL;
using Space_Race.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

using Microsoft.AspNetCore.Mvc;

namespace Space_Race.Controllers
{
    public class VehicleController : Controller
    {
        private readonly VehicleService _vehicleService;
        private readonly DriverService _driverService;
        public VehicleController(VehicleService vehicleService, DriverService driverService)
        {
            _vehicleService = vehicleService;
            _driverService = driverService;
        }
        [HttpGet]
        public IActionResult Index()
        {
            List<Vehicle> vehicles = _vehicleService.GetVehicles();
            return View(vehicles);
        }
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Drivers = new SelectList(_driverService.GetDrivers(), "DriverId", "Name");
            return View();
        }
        [HttpPost]
        public IActionResult Create(Vehicle vehicle, int selectedDriver)
        {
            if(ModelState.IsValid)
            {
                vehicle.Driver.DriverId = selectedDriver;
                _vehicleService.AddVehicle(vehicle);
                return RedirectToAction("Index");
            }
            ViewBag.Drivers = new SelectList(_driverService.GetDrivers(), "DriverId", "Name");
            return View(vehicle);
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            Vehicle vehicle = _vehicleService.GetVehicleById(id);
            if(vehicle == null)
            {
                return NotFound();
            }
            ViewBag.Drivers = new SelectList(_driverService.GetDrivers(), "DriverId", "Name");
            return View(vehicle);
        }
        [HttpPost]
        public IActionResult Edit(Vehicle vehicle)
        {
            if (ModelState.IsValid)
            {
                _vehicleService.UpdateVehicle(vehicle);
                return RedirectToAction("Index");
            }
            ViewBag.Drivers = new SelectList(_driverService.GetDrivers(), "DriverId", "Name");
            return View(vehicle);
        }
        [HttpPost]
        public IActionResult Delete(int id)
        {
            Vehicle vehicle = _vehicleService.GetVehicleById(id);
            if (vehicle == null)
            {
                return NotFound();
            }
            _vehicleService.RemoveVehicle(vehicle);
            return RedirectToAction("Index");
        }
    }
}
