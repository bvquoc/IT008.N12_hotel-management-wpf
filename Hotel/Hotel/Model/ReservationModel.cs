using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Model
{
    public class ReservationModel
    {
        public CustomerModel Customer { get; }
        public RoomModel Room { get;}
        public DateTime StartTime { get; }
        public DateTime EndTime { get; }
        public ReservationModel(CustomerModel customer, RoomModel room, DateTime startTime, DateTime endTime)
        {
            Customer = customer;
            Room = room;
            StartTime = startTime;
            EndTime = endTime;
            
        }
        public bool Conflict(ReservationModel reservation)
        {
            if (!Room.IsTheSameRoomAs(reservation.Room)) return false;
            return reservation.StartTime < EndTime && reservation.EndTime > StartTime;
        }
    }
}
