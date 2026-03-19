using System.Runtime.Serialization;
using System;

namespace VehicleRental.Contracts.DTOs
{
    [DataContract]
    public class ReservationDTO
    {
        [DataMember]
        public int ReservationId { get; set; }
        [DataMember]
        public int UserId { get; set; }
        [DataMember]
        public int VehicleId { get; set; }
        [DataMember]
        public DateTime StartDate { get; set; }
        [DataMember]
        public DateTime EndDate { get; set; }

        [DataMember]
        public decimal TotalPrice { get; set; }

        [DataMember]
        public string Status { get; set; }
    }

}