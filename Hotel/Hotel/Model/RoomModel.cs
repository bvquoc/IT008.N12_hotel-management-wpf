using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Model
{
    public class RoomModel
    {
        public int FloorNumber { get; }
        public int RoomNumber { get; }
        public bool IsTheSameRoomAs(RoomModel room) { return room.FloorNumber == FloorNumber && room.RoomNumber == RoomNumber; }
        public override string ToString()
        {
            return $"{FloorNumber}{RoomNumber}";
        }
    }

    
}
