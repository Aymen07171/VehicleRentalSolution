using VehicleRental.Contracts.DTOs;

namespace VehicleRental.WinClient
{
    // A static class means we can access it from anywhere
    // without creating an instance
    public static class Session
    {
        public static UserDTO CurrentUser { get; set; }
    }
}