using System;
using System.Collections.Generic;
using VehicleRental.Business.Managers;
using VehicleRental.Contracts.DTOs;
using VehicleRental.Contracts.Interfaces;

namespace VehicleRental.Services
{
    public class ReservationService : IReservationService
    {
        private readonly ReservationManager _reservationManager;

        public ReservationService()
        {
            _reservationManager = new ReservationManager();
        }

        public bool BookVehicle(int userId, int vehicleId,
                                DateTime startDate, DateTime endDate)
        {
            return _reservationManager.BookVehicle(
                userId, vehicleId, startDate, endDate);
        }

        public bool CancelReservation(int reservationId)
        {
            return _reservationManager.CancelReservation(reservationId);
        }

        public List<ReservationDTO> GetUserReservations(int userId)
        {
            return _reservationManager.GetUserReservations(userId);
        }
    }
}