using System.Collections.Generic;
using System.ServiceModel;
using VehicleRental.Contracts.DTOs;

namespace VehicleRental.Contracts.Interfaces
{
    [ServiceContract]
    public interface IVehicleService
    {
        [OperationContract]
        List<VehicleDTO> GetAllVehicles();

        [OperationContract]
        List<VehicleDTO> GetAvailableVehicles();

        [OperationContract]
        VehicleDTO GetVehicleById(int vehicleId);
    }
}