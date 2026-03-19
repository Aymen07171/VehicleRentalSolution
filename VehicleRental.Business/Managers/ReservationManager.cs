using System;
using System.Collections.Generic;
using VehicleRental.Contracts.DTOs;
using VehicleRental.Data.Repositories;

namespace VehicleRental.Business.Managers
{
    public class ReservationManager
    {
        private readonly ReservationRepository _reservationRepo;
        private readonly VehicleRepository _vehicleRepo;

        public ReservationManager()
        {
            _reservationRepo = new ReservationRepository();
            _vehicleRepo = new VehicleRepository();
        }

        public bool BookVehicle(int userId, int vehicleId,
                                DateTime startDate, DateTime endDate)
        {
            // Business rule: IDs must be valid
            if (userId <= 0 || vehicleId <= 0)
                return false;

            // Business rule: end date must be after start date
            if (endDate <= startDate)
                return false;

            // Business rule: cannot book a date in the past
            if (startDate < DateTime.Today)
                return false;

            // Business rule: check the vehicle is actually available
            VehicleDTO vehicle = _vehicleRepo.GetVehicleById(vehicleId);

            if (vehicle == null || !vehicle.IsAvailable)
                return false;

            // Calculate total price based on number of days
            int numberOfDays = (endDate - startDate).Days;
            decimal totalPrice = numberOfDays * vehicle.PricePerDay;

            // All rules passed — save to database
            return _reservationRepo.BookVehicle(
                userId, vehicleId, startDate, endDate, totalPrice);
        }

        public bool CancelReservation(int reservationId)
        {
            // Business rule: ID must be valid
            if (reservationId <= 0)
                return false;

            return _reservationRepo.CancelReservation(reservationId);
        }

        public List<ReservationDTO> GetUserReservations(int userId)
        {
            // Business rule: ID must be valid
            if (userId <= 0)
                return new List<ReservationDTO>();

            return _reservationRepo.GetUserReservations(userId);
        }
    }
}