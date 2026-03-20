using System.Collections.Generic;
using VehicleRental.Business.Managers;
using VehicleRental.Contracts.DTOs;
using VehicleRental.Contracts.Interfaces;

namespace VehicleRental.Services
{
    public class VehicleService : IVehicleService
    {
        private readonly VehicleManager _vehicleManager;

        public VehicleService()
        {
            _vehicleManager = new VehicleManager();
        }

        public List<VehicleDTO> GetAllVehicles()
        {
            return _vehicleManager.GetAllVehicles();
        }

        public List<VehicleDTO> GetAvailableVehicles()
        {
            return _vehicleManager.GetAvailableVehicles();
        }

        public VehicleDTO GetVehicleById(int vehicleId)
        {
            return _vehicleManager.GetVehicleById(vehicleId);
        }
    }
}