using Space_Race.Models;
using Microsoft.EntityFrameworkCore;

namespace Space_Race.DAL
{
    public class DriverRepository
    {
        private readonly SpRaceDbContext _context;
        public DriverRepository(SpRaceDbContext context)
        {
            _context = context;
        }
        public List<Driver> GetAllDrivers()
        {
            return _context.Drivers
                .Include(d => d.Vehicle)
                .ToList();
        }
        public Driver GetDriverById(int id)
        {
            return _context.Drivers.FirstOrDefault(d => d.DriverId == id);
        }
        public void AddDriver(Driver driver)
        {
            _context.Drivers.Add(driver);
            _context.SaveChanges();
        }
        public void UpdateDriver(Driver driver)
        {
            _context.Drivers.Update(driver);
            _context.SaveChanges();
        }
        public void DeleteDriver(int driverId)
        {
            var driver = _context.Drivers.Find(driverId);
            if (driver != null)
            {
                _context.Drivers.Remove(driver);
                _context.SaveChanges();
            }
        }
    }
}
