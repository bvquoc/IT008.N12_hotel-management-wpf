using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hotel.Model;

namespace Hotel.ViewModel
{
    public class RoomViewModel : BaseViewModel
    {
        private readonly RoomModel _room;
        public string Name => _room.ToString();
        public string Description => _room.Description;
        public string Status => _room.Status;
        
        public RoomViewModel(RoomModel room)
        {
            _room = room;
        }
    }
}
