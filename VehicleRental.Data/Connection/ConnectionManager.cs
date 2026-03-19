using System.Configuration;
using System.Data.SqlClient;

namespace VehicleRental.Data.Connection
{
    public class ConnectionManager
    {
        // Read the connection string from App.config
        private static readonly string _connectionString =
            ConfigurationManager.ConnectionStrings["VehicleRentalDB"]
                                 .ConnectionString;

        // Return a new open connection to the database
        public static SqlConnection GetConnection()
        {
            SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();
            return connection;
        }
    }
}