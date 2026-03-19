using System.ServiceModel;
using VehicleRental.Contracts.DTOs;

namespace VehicleRental.Contracts.Interfaces
{
    [ServiceContract]
    public interface IUserService
    {
        [OperationContract]
        UserDTO Login(string email, string password);

        [OperationContract]
        bool Register(string fullName, string email,
                      string password, string phone);
    }
}