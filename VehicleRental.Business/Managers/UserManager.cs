using VehicleRental.Contracts.DTOs;
using VehicleRental.Data.Repositories;

namespace VehicleRental.Business.Managers
{
    public class UserManager
    {
        private readonly UserRepository _userRepo;

        public UserManager()
        {
            _userRepo = new UserRepository();
        }

        public UserDTO Login(string email, string password)
        {
            // Business rule: email and password must not be empty
            if (string.IsNullOrWhiteSpace(email) ||
                string.IsNullOrWhiteSpace(password))
                return null;

            return _userRepo.Login(email, password);
        }

        public bool Register(string fullName, string email,
                             string password, string phone)
        {
            // Business rule: all core fields must be filled
            if (string.IsNullOrWhiteSpace(fullName) ||
                string.IsNullOrWhiteSpace(email) ||
                string.IsNullOrWhiteSpace(password))
                return false;

            // Business rule: password must be at least 6 characters
            if (password.Length < 6)
                return false;

            // Business rule: email must contain an @ symbol
            if (!email.Contains("@"))
                return false;

            return _userRepo.Register(fullName, email, password, phone);
        }
    }
}