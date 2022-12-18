using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.ViewModel
{
    internal class ReservationBookViewModel : BaseViewModel
    {
        private ObservableCollection<RoomVM> _rooms;
        public ObservableCollection<RoomVM> Rooms
        {
            get { return _rooms; }
            set { _rooms = value; OnPropertyChanged(); }
        }

        public ReservationBookViewModel()
        {
            Rooms = new ObservableCollection<RoomVM>();
            LoadDemo();
        }

        public void LoadDemo()
        {
            Rooms.Add(new RoomVM() { Name = "B101", Description = "Thường", Status = "Trống" });
            Rooms.Add(new RoomVM() { Name = "B102", Description = "Vip", Status = "Đã đặt" });
            Rooms.Add(new RoomVM() { Name = "B103", Description = "Thường", Status = "Tu Sua" });
            Rooms.Add(new RoomVM() { Name = "B104", Description = "Thường", Status = "Trống" });
            Rooms.Add(new RoomVM() { Name = "B105", Description = "Thường", Status = "Tu Sửa" });
            Rooms.Add(new RoomVM() { Name = "B106", Description = "Thường", Status = "Đã đặt" });
            Rooms.Add(new RoomVM() { Name = "B107", Description = "Thường", Status = "Tu Sửa" });
            Rooms.Add(new RoomVM() { Name = "B108", Description = "Thường", Status = "Tu Sửa" });
            Rooms.Add(new RoomVM() { Name = "B109", Description = "Thường", Status = "Tu Sửa" });
            Rooms.Add(new RoomVM() { Name = "B201", Description = "Thường", Status = "Tu Sửa" });
            Rooms.Add(new RoomVM() { Name = "B202", Description = "Thường", Status = "Tu Sửa" });
            Rooms.Add(new RoomVM() { Name = "B203", Description = "Thường", Status = "Tu Sửa" });
            Rooms.Add(new RoomVM() { Name = "B204", Description = "Thường", Status = "Tu Sửa" });
            Rooms.Add(new RoomVM() { Name = "B205", Description = "Thường", Status = "Tu Sửa" });
            Rooms.Add(new RoomVM() { Name = "B101", Description = "Thường", Status = "Trống" });
            Rooms.Add(new RoomVM() { Name = "B102", Description = "Vip", Status = "Đã đặt" });
            Rooms.Add(new RoomVM() { Name = "B103", Description = "Thường", Status = "Tu Sua" });
            Rooms.Add(new RoomVM() { Name = "B104", Description = "Thường", Status = "Trống" });
            Rooms.Add(new RoomVM() { Name = "B105", Description = "Thường", Status = "Tu Sửa" });
            Rooms.Add(new RoomVM() { Name = "B106", Description = "Thường", Status = "Đã đặt" });
            Rooms.Add(new RoomVM() { Name = "B107", Description = "Thường", Status = "Tu Sửa" });
        }
    }
}
