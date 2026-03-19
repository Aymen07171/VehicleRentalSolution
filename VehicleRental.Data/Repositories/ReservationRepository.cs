using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using VehicleRental.Contracts.DTOs;
using VehicleRental.Data.Connection;

namespace VehicleRental.Data.Repositories
{
    public class ReservationRepository
    {
        public bool BookVehicle(int userId, int vehicleId,
                                DateTime startDate, DateTime endDate,
                                decimal totalPrice)
        {
            using (SqlConnection conn = ConnectionManager.GetConnection())
            {
                // Insert the reservation
                string insertSql = @"INSERT INTO Reservations 
                                    (UserId, VehicleId, StartDate, EndDate, TotalPrice)
                                    VALUES 
                                    (@UserId, @VehicleId, @StartDate, @EndDate, @TotalPrice)";

                SqlCommand insertCmd = new SqlCommand(insertSql, conn);
                insertCmd.Parameters.AddWithValue("@UserId", userId);
                insertCmd.Parameters.AddWithValue("@VehicleId", vehicleId);
                insertCmd.Parameters.AddWithValue("@StartDate", startDate);
                insertCmd.Parameters.AddWithValue("@EndDate", endDate);
                insertCmd.Parameters.AddWithValue("@TotalPrice", totalPrice);
                insertCmd.ExecuteNonQuery();

                // Mark the vehicle as no longer available
                string updateSql = @"UPDATE Vehicles 
                                     SET IsAvailable = 0 
                                     WHERE VehicleId = @VehicleId";

                SqlCommand updateCmd = new SqlCommand(updateSql, conn);
                updateCmd.Parameters.AddWithValue("@VehicleId", vehicleId);
                int rows = updateCmd.ExecuteNonQuery();

                return rows > 0;
            }
        }

        public bool CancelReservation(int reservationId)
        {
            using (SqlConnection conn = ConnectionManager.GetConnection())
            {
                // First, get the VehicleId from this reservation
                string selectSql = @"SELECT VehicleId FROM Reservations 
                                     WHERE ReservationId = @ReservationId";

                SqlCommand selectCmd = new SqlCommand(selectSql, conn);
                selectCmd.Parameters.AddWithValue("@ReservationId", reservationId);
                object result = selectCmd.ExecuteScalar();

                if (result == null) return false;

                int vehicleId = (int)result;

                // Update reservation status to Cancelled
                string cancelSql = @"UPDATE Reservations 
                                     SET Status = 'Cancelled' 
                                     WHERE ReservationId = @ReservationId";

                SqlCommand cancelCmd = new SqlCommand(cancelSql, conn);
                cancelCmd.Parameters.AddWithValue("@ReservationId", reservationId);
                cancelCmd.ExecuteNonQuery();

                // Make the vehicle available again
                string freeSql = @"UPDATE Vehicles 
                                   SET IsAvailable = 1 
                                   WHERE VehicleId = @VehicleId";

                SqlCommand freeCmd = new SqlCommand(freeSql, conn);
                freeCmd.Parameters.AddWithValue("@VehicleId", vehicleId);
                freeCmd.ExecuteNonQuery();

                return true;
            }
        }

        public List<ReservationDTO> GetUserReservations(int userId)
        {
            List<ReservationDTO> list = new List<ReservationDTO>();

            using (SqlConnection conn = ConnectionManager.GetConnection())
            {
                string sql = @"SELECT * FROM Reservations 
                               WHERE UserId = @UserId";

                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@UserId", userId);

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    list.Add(new ReservationDTO
                    {
                        ReservationId = (int)reader["ReservationId"],
                        UserId = (int)reader["UserId"],
                        VehicleId = (int)reader["VehicleId"],
                        StartDate = (DateTime)reader["StartDate"],
                        EndDate = (DateTime)reader["EndDate"],
                        TotalPrice = (decimal)reader["TotalPrice"],
                        Status = reader["Status"].ToString()
                    });
                }
            }

            return list;
        }
    }
}
