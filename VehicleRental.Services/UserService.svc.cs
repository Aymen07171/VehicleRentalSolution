using VehicleRental.Business.Managers;
using VehicleRental.Contracts.DTOs;
using VehicleRental.Contracts.Interfaces;

namespace VehicleRental.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager _userManager;

        public UserService()
        {
            _userManager = new UserManager();
        }

        public UserDTO Login(string email, string password)
        {
            return _userManager.Login(email, password);
        }

        public bool Register(string fullName, string email,
                             string password, string phone)
        {
            return _userManager.Register(fullName, email, password, phone);
        }
    }
}