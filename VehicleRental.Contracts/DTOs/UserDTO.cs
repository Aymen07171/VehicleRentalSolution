using System.Runtime.Serialization;


namespace VehicleRental.Contracts.DTOs
{
    [DataContract]
    public class UserDTO
    {
        [DataMember]
        public int UserId { get; set; }
        [DataMember]
        public string FullName { get; set; }
        [DataMember]
        public string Email { get; set; }

        [DataMember]
        public string Phone { get; set; }

    }
}