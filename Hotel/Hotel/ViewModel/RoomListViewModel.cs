using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.ViewModel
{
    public class RoomListViewModel: BaseViewModel
    {
        private readonly ObservableCollection<RoomViewModel> _rooms;
        public IEnumerable<RoomViewModel> Rooms => _rooms;
        public RoomListViewModel()
        {
            _rooms = new ObservableCollection<RoomViewModel>();

            _rooms.Add(new RoomViewModel(new Model.RoomModel(1, 1, "Thường", "Tu sửa")));
            _rooms.Add(new RoomViewModel(new Model.RoomModel(1, 2, "Thường", "Tu sửa")));
            _rooms.Add(new RoomViewModel(new Model.RoomModel(1, 3, "Lớn", "Tu sửa")));
            _rooms.Add(new RoomViewModel(new Model.RoomModel(2, 1, "Thường", "Tu sửa")));
            _rooms.Add(new RoomViewModel(new Model.RoomModel(3, 1, "Thường", "Tu sửa")));
            _rooms.Add(new RoomViewModel(new Model.RoomModel(4, 1, "Thường", "Tu sửa")));
            _rooms.Add(new RoomViewModel(new Model.RoomModel(5, 1, "Thường", "Tu sửa")));
            _rooms.Add(new RoomViewModel(new Model.RoomModel(1, 6, "Thường", "Tu sửa")));
            _rooms.Add(new RoomViewModel(new Model.RoomModel(33, 5, "Thường", "Tu sửa")));
        }

    }
}
