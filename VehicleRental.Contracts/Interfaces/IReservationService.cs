using System.Collections.Generic;
using System.ServiceModel;
using System;
using VehicleRental.Contracts.DTOs;

namespace VehicleRental.Contracts.Interfaces
{
    [ServiceContract]
    public interface IReservationService
    {
        [OperationContract]
        bool BookVehicle(int userId, int vehicleId,
                         DateTime startDate, DateTime endDate);

        [OperationContract]
        bool CancelReservation(int reservationId);

        [OperationContract]
        List<ReservationDTO> GetUserReservations(int userId);
    }
}

