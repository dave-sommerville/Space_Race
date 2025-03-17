using Space_Race.Models;
using Space_Race.DAL;

namespace Space_Race.BLL
{
    public class DriverService
    {
        private readonly DriverRepository _driverRepository;
        public DriverService(DriverRepository driverRepository)
        {
            _driverRepository = driverRepository;
        }
        public List<Driver> GetDrivers()
        {
            return _driverRepository.GetAllDrivers();
        }
        public Driver GetDriverById(int id)
        {
            return _driverRepository.GetDriverById(id);
        }
        public int GetDriverCount()
        {
            return _driverRepository.GetAllDrivers().Count;
        }

        public void AddDriver(Driver driver)
        {
            if(string.IsNullOrWhiteSpace(driver.Name))
            {
                throw new ArgumentException("Driver name cannot be empty or null");
            }
            _driverRepository.AddDriver(driver);
        }
        public void UpdateDriver(Driver driver)
        {
            if (string.IsNullOrWhiteSpace(driver.Name))
            {
                throw new ArgumentException("Driver name cannot be empty or null");
            }
            _driverRepository.UpdateDriver(driver);
        }
        public void DeleteDriver(int id)
        {
            _driverRepository.DeleteDriver(id);
        }
    }
}
