using System.Collections.Generic;
using VehicleRental.Contracts.DTOs;
using VehicleRental.Data.Repositories;

namespace VehicleRental.Business.Managers
{
    public class VehicleManager
    {
        // The manager uses the repository to get data
        private readonly VehicleRepository _vehicleRepo;

        public VehicleManager()
        {
            _vehicleRepo = new VehicleRepository();
        }

        public List<VehicleDTO> GetAllVehicles()
        {
            // No special rules here — just return all vehicles
            return _vehicleRepo.GetAllVehicles();
        }

        public List<VehicleDTO> GetAvailableVehicles()
        {
            // No special rules here — just return available ones
            return _vehicleRepo.GetAvailableVehicles();
        }

        public VehicleDTO GetVehicleById(int vehicleId)
        {
            // Business rule: vehicleId must be a positive number
            if (vehicleId <= 0)
                return null;

            return _vehicleRepo.GetVehicleById(vehicleId);
        }
    }
}