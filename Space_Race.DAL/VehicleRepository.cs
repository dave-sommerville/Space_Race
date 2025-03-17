using Space_Race.Models;
using Microsoft.EntityFrameworkCore;

namespace Space_Race.DAL
{
    public class VehicleRepository
    {
        private readonly SpRaceDbContext _context;
        public VehicleRepository(SpRaceDbContext context)
        {
            _context = context;
        }
        public List<Vehicle> GetAllVehicles()
        {
            return _context.Vehicles
                .Include(v => v.Driver)
                .ToList();
        }
        public Vehicle GetVehicleById(int id)
        {
            return _context.Vehicles.FirstOrDefault(v => v.VehicleId == id);
        }
        public void AddVehicle(Vehicle vehicle)
        {
            _context.Vehicles.Add(vehicle);
            _context.SaveChanges();
        }
        public void UpdateVehicle(Vehicle vehicle)
        {
            _context.Vehicles.Update(vehicle);
            _context.SaveChanges();
        }
        public void RemoveVehicle(int id)
        {
            var vehicle = _context.Vehicles.FirstOrDefault(v => v.VehicleId == id);
            if (vehicle != null)
            {
                _context.Vehicles.Remove(vehicle);
                _context.SaveChanges();
            }
        }
    }
}
