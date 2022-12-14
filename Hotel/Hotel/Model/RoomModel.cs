using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Model
{
    public class RoomModel
    {
        public RoomModel(int floorNumber, int roomNumber, string description, string status)
        {
            FloorNumber = floorNumber;
            RoomNumber = roomNumber;
            Description = description;
            Status = status;
        }

        public int FloorNumber { get; }
        public int RoomNumber { get; }
        public string Description { get; }
        public string Status { get; }

        public bool IsTheSameRoomAs(RoomModel room) { return room.FloorNumber == FloorNumber && room.RoomNumber == RoomNumber; }
        public override string ToString()
        {
            return $"{FloorNumber}.{RoomNumber}";
        }
    }

    
}
