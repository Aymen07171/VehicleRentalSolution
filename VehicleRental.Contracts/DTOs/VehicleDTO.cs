using System.Runtime.Serialization;

namespace VehicleRental.Contracts.DTOs
{
    [DataContract]
    public class VehicleDTO
    {
        [DataMember]
        public int VehicleId { get; set; }
        [DataMember]
        public string Brand { get; set; }
        [DataMember]
        public string Model { get; set; }
        [DataMember]
        public int Year { get; set; }
        [DataMember]
        public string LicensePlate { get; set; }

        [DataMember]
        public string PricePerDay { get; set; }

        [DataMember]
        public string isAvailable { get; set; }
    }
}