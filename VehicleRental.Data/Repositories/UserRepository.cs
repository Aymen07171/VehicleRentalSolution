using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;
using VehicleRental.Contracts.DTOs;
using VehicleRental.Data.Connection;

namespace VehicleRental.Data.Repositories
{
    public class UserRepository
    {
        // Helper: convert a plain password into a SHA256 hash
        private string HashPassword(string password)
        {
            using (SHA256 sha = SHA256.Create())
            {
                byte[] bytes = sha.ComputeHash(
                    Encoding.UTF8.GetBytes(password));

                StringBuilder sb = new StringBuilder();
                foreach (byte b in bytes)
                    sb.Append(b.ToString("x2"));

                return sb.ToString();
            }
        }

        public bool Register(string fullName, string email,
                             string password, string phone)
        {
            using (SqlConnection conn = ConnectionManager.GetConnection())
            {
                string hashedPassword = HashPassword(password);

                string sql = @"INSERT INTO Users 
                               (FullName, Email, PasswordHash, Phone)
                               VALUES 
                               (@FullName, @Email, @PasswordHash, @Phone)";

                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@FullName", fullName);
                cmd.Parameters.AddWithValue("@Email", email);
                cmd.Parameters.AddWithValue("@PasswordHash", hashedPassword);
                cmd.Parameters.AddWithValue("@Phone", phone);

                // ExecuteNonQuery returns how many rows were affected
                int rowsAffected = cmd.ExecuteNonQuery();
                return rowsAffected > 0;
            }
        }

        public UserDTO Login(string email, string password)
        {
            using (SqlConnection conn = ConnectionManager.GetConnection())
            {
                string hashedPassword = HashPassword(password);

                string sql = @"SELECT * FROM Users 
                               WHERE Email = @Email 
                               AND PasswordHash = @PasswordHash";

                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@Email", email);
                cmd.Parameters.AddWithValue("@PasswordHash", hashedPassword);

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    return new UserDTO
                    {
                        UserId = (int)reader["UserId"],
                        FullName = reader["FullName"].ToString(),
                        Email = reader["Email"].ToString(),
                        Phone = reader["Phone"].ToString()
                    };
                }

                return null;
            }
        }
    }
}