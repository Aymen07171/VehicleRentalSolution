using System.Collections.Generic;
using System.ServiceModel;
using System.Web.Services.Description;
using VehicleRental.Business.Managers;
using VehicleRental.Contracts.DTOs;
using VehicleRental.Contracts.Interfaces;

namespace VehicleRental.Services
{
    // This class implements the IVehicleService contract
    public class VehicleService : IVehicleService
    {
        // The service delegates all work to the Business Layer
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

        // Implement the DoWork method required by IVehicleService
        public void DoWork()
        {
            // Intentionally left blank - placeholder for service contract
        }
    }
}
