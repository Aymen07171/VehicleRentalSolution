using System.Collections.Generic;
using System.Data.SqlClient;
using VehicleRental.Contracts.DTOs;
using VehicleRental.Data.Connection;

namespace VehicleRental.Data.Repositories
{
    public class VehicleRepository
    {
        public List<VehicleDTO> GetAllVehicles()
        {
            // This list will hold all vehicles we read from the DB
            List<VehicleDTO> vehicles = new List<VehicleDTO>();

            // 'using' automatically closes the connection when done
            using (SqlConnection conn = ConnectionManager.GetConnection())
            {
                string sql = "SELECT * FROM Vehicles";

                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataReader reader = cmd.ExecuteReader();

                // Loop through each row returned
                while (reader.Read())
                {
                    VehicleDTO vehicle = new VehicleDTO
                    {
                        VehicleId = (int)reader["VehicleId"],
                        Brand = reader["Brand"].ToString(),
                        Model = reader["Model"].ToString(),
                        Year = (int)reader["Year"],
                        LicensePlate = reader["LicensePlate"].ToString(),
                        PricePerDay = (decimal)reader["PricePerDay"],
                        IsAvailable = (bool)reader["IsAvailable"]
                    };

                    vehicles.Add(vehicle);
                }
            }

            return vehicles;
        }

        public List<VehicleDTO> GetAvailableVehicles()
        {
            List<VehicleDTO> vehicles = new List<VehicleDTO>();

            using (SqlConnection conn = ConnectionManager.GetConnection())
            {
                // Only fetch vehicles where IsAvailable = 1
                string sql = "SELECT * FROM Vehicles WHERE IsAvailable = 1";

                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    VehicleDTO vehicle = new VehicleDTO
                    {
                        VehicleId = (int)reader["VehicleId"],
                        Brand = reader["Brand"].ToString(),
                        Model = reader["Model"].ToString(),
                        Year = (int)reader["Year"],
                        LicensePlate = reader["LicensePlate"].ToString(),
                        PricePerDay = (decimal)reader["PricePerDay"],
                        IsAvailable = (bool)reader["IsAvailable"]
                    };

                    vehicles.Add(vehicle);
                }
            }

            return vehicles;
        }

        public VehicleDTO GetVehicleById(int vehicleId)
        {
            using (SqlConnection conn = ConnectionManager.GetConnection())
            {
                // @VehicleId is a parameter — safer than string concatenation
                string sql = "SELECT * FROM Vehicles WHERE VehicleId = @VehicleId";

                SqlCommand cmd = new SqlCommand(sql, conn);

                // This is how you pass parameters safely in ADO.NET
                cmd.Parameters.AddWithValue("@VehicleId", vehicleId);

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    return new VehicleDTO
                    {
                        VehicleId = (int)reader["VehicleId"],
                        Brand = reader["Brand"].ToString(),
                        Model = reader["Model"].ToString(),
                        Year = (int)reader["Year"],
                        LicensePlate = reader["LicensePlate"].ToString(),
                        PricePerDay = (decimal)reader["PricePerDay"],
                        IsAvailable = (bool)reader["IsAvailable"]
                    };
                }

                // Return null if no vehicle was found
                return null;
            }
        }
    }
}