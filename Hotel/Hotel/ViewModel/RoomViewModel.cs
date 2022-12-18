using Hotel.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Hotel.ViewModel
{
    internal class RoomViewModel : BaseViewModel
    {
        private ObservableCollection<RoomVM> _roomList;
        public ObservableCollection<RoomVM> RoomList
        {
            get { return _roomList; }
            set { _roomList = value; OnPropertyChanged(); }
        }
        public RoomViewModel()
        {
            RoomList = new ObservableCollection<RoomVM>();
            LoadDemo();
        }

        public void LoadDemo()
        {
            RoomList.Add(new RoomVM() { Name = "B101", Description = "Thường", Status = "Trống" });
            RoomList.Add(new RoomVM() { Name = "B102", Description = "Vip", Status = "Đã đặt" });
            RoomList.Add(new RoomVM() { Name = "B103", Description = "Thường", Status = "Tu Sua" });
            RoomList.Add(new RoomVM() { Name = "B104", Description = "Thường", Status = "Trống" });
            RoomList.Add(new RoomVM() { Name = "B105", Description = "Thường", Status = "Tu Sửa" });
            RoomList.Add(new RoomVM() { Name = "B106", Description = "Thường", Status = "Đã đặt" });
            RoomList.Add(new RoomVM() { Name = "B107", Description = "Thường", Status = "Tu Sửa" });
            RoomList.Add(new RoomVM() { Name = "B108", Description = "Thường", Status = "Tu Sửa" });
            RoomList.Add(new RoomVM() { Name = "B109", Description = "Thường", Status = "Tu Sửa" });
            RoomList.Add(new RoomVM() { Name = "B201", Description = "Thường", Status = "Tu Sửa" });
            RoomList.Add(new RoomVM() { Name = "B202", Description = "Thường", Status = "Tu Sửa" });
            RoomList.Add(new RoomVM() { Name = "B203", Description = "Thường", Status = "Tu Sửa" });
            RoomList.Add(new RoomVM() { Name = "B204", Description = "Thường", Status = "Tu Sửa" });
            RoomList.Add(new RoomVM() { Name = "B205", Description = "Thường", Status = "Tu Sửa" });
            RoomList.Add(new RoomVM() { Name = "B101", Description = "Thường", Status = "Trống" });
            RoomList.Add(new RoomVM() { Name = "B102", Description = "Vip", Status = "Đã đặt" });
            RoomList.Add(new RoomVM() { Name = "B103", Description = "Thường", Status = "Tu Sua" });
            RoomList.Add(new RoomVM() { Name = "B104", Description = "Thường", Status = "Trống" });
            RoomList.Add(new RoomVM() { Name = "B105", Description = "Thường", Status = "Tu Sửa" });
            RoomList.Add(new RoomVM() { Name = "B106", Description = "Thường", Status = "Đã đặt" });
            RoomList.Add(new RoomVM() { Name = "B107", Description = "Thường", Status = "Tu Sửa" });
            RoomList.Add(new RoomVM() { Name = "B108", Description = "Thường", Status = "Tu Sửa" });
            RoomList.Add(new RoomVM() { Name = "B109", Description = "Thường", Status = "Tu Sửa" });
            RoomList.Add(new RoomVM() { Name = "B201", Description = "Thường", Status = "Tu Sửa" });
            RoomList.Add(new RoomVM() { Name = "B202", Description = "Thường", Status = "Tu Sửa" });
            RoomList.Add(new RoomVM() { Name = "B203", Description = "Thường", Status = "Tu Sửa" });
            RoomList.Add(new RoomVM() { Name = "B204", Description = "Thường", Status = "Tu Sửa" });
            RoomList.Add(new RoomVM() { Name = "B205", Description = "Thường", Status = "Tu Sửa" });
            RoomList.Add(new RoomVM() { Name = "B101", Description = "Thường", Status = "Trống" });
            RoomList.Add(new RoomVM() { Name = "B102", Description = "Vip", Status = "Đã đặt" });
            RoomList.Add(new RoomVM() { Name = "B103", Description = "Thường", Status = "Tu Sua" });
            RoomList.Add(new RoomVM() { Name = "B104", Description = "Thường", Status = "Trống" });
            RoomList.Add(new RoomVM() { Name = "B105", Description = "Thường", Status = "Tu Sửa" });
            RoomList.Add(new RoomVM() { Name = "B106", Description = "Thường", Status = "Đã đặt" });
            RoomList.Add(new RoomVM() { Name = "B107", Description = "Thường", Status = "Tu Sửa" });
            RoomList.Add(new RoomVM() { Name = "B108", Description = "Thường", Status = "Tu Sửa" });
            RoomList.Add(new RoomVM() { Name = "B109", Description = "Thường", Status = "Tu Sửa" });
            RoomList.Add(new RoomVM() { Name = "B201", Description = "Thường", Status = "Tu Sửa" });
            RoomList.Add(new RoomVM() { Name = "B202", Description = "Thường", Status = "Tu Sửa" });
            RoomList.Add(new RoomVM() { Name = "B203", Description = "Thường", Status = "Tu Sửa" });
            RoomList.Add(new RoomVM() { Name = "B204", Description = "Thường", Status = "Tu Sửa" });
            RoomList.Add(new RoomVM() { Name = "B205", Description = "Thường", Status = "Tu Sửa" });
            RoomList.Add(new RoomVM() { Name = "B101", Description = "Thường", Status = "Trống" });
            RoomList.Add(new RoomVM() { Name = "B102", Description = "Vip", Status = "Đã đặt" });
            RoomList.Add(new RoomVM() { Name = "B103", Description = "Thường", Status = "Tu Sua" });
            RoomList.Add(new RoomVM() { Name = "B104", Description = "Thường", Status = "Trống" });
            RoomList.Add(new RoomVM() { Name = "B105", Description = "Thường", Status = "Tu Sửa" });
            RoomList.Add(new RoomVM() { Name = "B106", Description = "Thường", Status = "Đã đặt" });
            RoomList.Add(new RoomVM() { Name = "B107", Description = "Thường", Status = "Tu Sửa" });
            RoomList.Add(new RoomVM() { Name = "B108", Description = "Thường", Status = "Tu Sửa" });
            RoomList.Add(new RoomVM() { Name = "B109", Description = "Thường", Status = "Tu Sửa" });
            RoomList.Add(new RoomVM() { Name = "B201", Description = "Thường", Status = "Tu Sửa" });
            RoomList.Add(new RoomVM() { Name = "B202", Description = "Thường", Status = "Tu Sửa" });
            RoomList.Add(new RoomVM() { Name = "B203", Description = "Thường", Status = "Tu Sửa" });
            RoomList.Add(new RoomVM() { Name = "B204", Description = "Thường", Status = "Tu Sửa" });
            RoomList.Add(new RoomVM() { Name = "B205", Description = "Thường", Status = "Tu Sửa" });
        }
    }

}
