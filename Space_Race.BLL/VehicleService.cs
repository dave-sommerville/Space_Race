using Space_Race.DAL;
using Space_Race.Models;

namespace Space_Race.BLL
{
    public class VehicleService
    {
        private readonly VehicleRepository _vehicleRepository;
        public VehicleService(VehicleRepository vehicleRepository)
        {
            _vehicleRepository = vehicleRepository;
        }
        public List<Vehicle> GetVehicles()
        {
            return _vehicleRepository.GetAllVehicles();
        }
        public Vehicle GetVehicleById(int id)
        {
            return _vehicleRepository.GetVehicleById(id);
        }
        public int GetVehicleCount()
        {
            return _vehicleRepository.GetAllVehicles().Count;
        }

        public void AddVehicle(Vehicle vehicle)
        {
            if(string.IsNullOrWhiteSpace(vehicle.Model))
            {
                throw new ArgumentException("Model is required");
            }
            _vehicleRepository.AddVehicle(vehicle);
        }
        public void UpdateVehicle(Vehicle vehicle)
        {
            if (string.IsNullOrWhiteSpace(vehicle.Model))
            {
                throw new ArgumentException("Model is required");
            }
            _vehicleRepository.UpdateVehicle(vehicle);
        }
        public void RemoveVehicle(Vehicle vehicle)
        {
            _vehicleRepository.RemoveVehicle(vehicle.VehicleId);
        }
    }
}
