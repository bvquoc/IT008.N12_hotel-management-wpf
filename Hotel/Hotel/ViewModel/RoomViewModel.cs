using Hotel.Model;
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
            LoadAllRoom();
        }

        public void LoadAllRoom()
        {
            using (var db = new QLYHOTELEntities())
            {
                var select = from s in db.PHONGs select s;
                foreach (var room in select)
                    RoomList.Add(new RoomVM() { Name = room.TENPHONG.ToString(), Description = room.LOAIPHONG.ToString(), Status = room.TRANGTHAI.ToString() });
            }


            //RoomList.Add(new RoomVM() { Name = "B101", Description = "Thường", Status = "Trống" });
            //RoomList.Add(new RoomVM() { Name = "B102", Description = "Vip", Status = "Đã đặt" });
            //RoomList.Add(new RoomVM() { Name = "B103", Description = "Thường", Status = "Tu Sua" });
            //RoomList.Add(new RoomVM() { Name = "B104", Description = "Thường", Status = "Trống" });
            //RoomList.Add(new RoomVM() { Name = "B105", Description = "Thường", Status = "Tu Sửa" });
            //RoomList.Add(new RoomVM() { Name = "B106", Description = "Thường", Status = "Đã đặt" });
            //RoomList.Add(new RoomVM() { Name = "B107", Description = "Thường", Status = "Tu Sửa" });
            //RoomList.Add(new RoomVM() { Name = "B108", Description = "Thường", Status = "Tu Sửa" });
            //RoomList.Add(new RoomVM() { Name = "B109", Description = "Thường", Status = "Tu Sửa" });
            //RoomList.Add(new RoomVM() { Name = "B201", Description = "Thường", Status = "Tu Sửa" });
            //RoomList.Add(new RoomVM() { Name = "B202", Description = "Thường", Status = "Tu Sửa" });
            //RoomList.Add(new RoomVM() { Name = "B203", Description = "Thường", Status = "Tu Sửa" });
            //RoomList.Add(new RoomVM() { Name = "B204", Description = "Thường", Status = "Tu Sửa" });
            //RoomList.Add(new RoomVM() { Name = "B205", Description = "Thường", Status = "Tu Sửa" });
            //RoomList.Add(new RoomVM() { Name = "B101", Description = "Thường", Status = "Trống" });
            //RoomList.Add(new RoomVM() { Name = "B102", Description = "Vip", Status = "Đã đặt" });
            //RoomList.Add(new RoomVM() { Name = "B103", Description = "Thường", Status = "Tu Sua" });
            //RoomList.Add(new RoomVM() { Name = "B104", Description = "Thường", Status = "Trống" });
            //RoomList.Add(new RoomVM() { Name = "B105", Description = "Thường", Status = "Tu Sửa" });
            //RoomList.Add(new RoomVM() { Name = "B106", Description = "Thường", Status = "Đã đặt" });
            //RoomList.Add(new RoomVM() { Name = "B107", Description = "Thường", Status = "Tu Sửa" });
            //RoomList.Add(new RoomVM() { Name = "B108", Description = "Thường", Status = "Tu Sửa" });
            //RoomList.Add(new RoomVM() { Name = "B109", Description = "Thường", Status = "Tu Sửa" });
            //RoomList.Add(new RoomVM() { Name = "B201", Description = "Thường", Status = "Tu Sửa" });
            //RoomList.Add(new RoomVM() { Name = "B202", Description = "Thường", Status = "Tu Sửa" });
            //RoomList.Add(new RoomVM() { Name = "B203", Description = "Thường", Status = "Tu Sửa" });
            //RoomList.Add(new RoomVM() { Name = "B204", Description = "Thường", Status = "Tu Sửa" });
            //RoomList.Add(new RoomVM() { Name = "B205", Description = "Thường", Status = "Tu Sửa" });
            //RoomList.Add(new RoomVM() { Name = "B101", Description = "Thường", Status = "Trống" });
            //RoomList.Add(new RoomVM() { Name = "B102", Description = "Vip", Status = "Đã đặt" });
            //RoomList.Add(new RoomVM() { Name = "B103", Description = "Thường", Status = "Tu Sua" });
            //RoomList.Add(new RoomVM() { Name = "B104", Description = "Thường", Status = "Trống" });
            //RoomList.Add(new RoomVM() { Name = "B105", Description = "Thường", Status = "Tu Sửa" });
            //RoomList.Add(new RoomVM() { Name = "B106", Description = "Thường", Status = "Đã đặt" });
            //RoomList.Add(new RoomVM() { Name = "B107", Description = "Thường", Status = "Tu Sửa" });
            //RoomList.Add(new RoomVM() { Name = "B108", Description = "Thường", Status = "Tu Sửa" });
            //RoomList.Add(new RoomVM() { Name = "B109", Description = "Thường", Status = "Tu Sửa" });
            //RoomList.Add(new RoomVM() { Name = "B201", Description = "Thường", Status = "Tu Sửa" });
            //RoomList.Add(new RoomVM() { Name = "B202", Description = "Thường", Status = "Tu Sửa" });
            //RoomList.Add(new RoomVM() { Name = "B203", Description = "Thường", Status = "Tu Sửa" });
            //RoomList.Add(new RoomVM() { Name = "B204", Description = "Thường", Status = "Tu Sửa" });
            //RoomList.Add(new RoomVM() { Name = "B205", Description = "Thường", Status = "Tu Sửa" });
            //RoomList.Add(new RoomVM() { Name = "B101", Description = "Thường", Status = "Trống" });
            //RoomList.Add(new RoomVM() { Name = "B102", Description = "Vip", Status = "Đã đặt" });
            //RoomList.Add(new RoomVM() { Name = "B103", Description = "Thường", Status = "Tu Sua" });
            //RoomList.Add(new RoomVM() { Name = "B104", Description = "Thường", Status = "Trống" });
            //RoomList.Add(new RoomVM() { Name = "B105", Description = "Thường", Status = "Tu Sửa" });
            //RoomList.Add(new RoomVM() { Name = "B106", Description = "Thường", Status = "Đã đặt" });
            //RoomList.Add(new RoomVM() { Name = "B107", Description = "Thường", Status = "Tu Sửa" });
            //RoomList.Add(new RoomVM() { Name = "B108", Description = "Thường", Status = "Tu Sửa" });
            //RoomList.Add(new RoomVM() { Name = "B109", Description = "Thường", Status = "Tu Sửa" });
            //RoomList.Add(new RoomVM() { Name = "B201", Description = "Thường", Status = "Tu Sửa" });
            //RoomList.Add(new RoomVM() { Name = "B202", Description = "Thường", Status = "Tu Sửa" });
            //RoomList.Add(new RoomVM() { Name = "B203", Description = "Thường", Status = "Tu Sửa" });
            //RoomList.Add(new RoomVM() { Name = "B204", Description = "Thường", Status = "Tu Sửa" });
            //RoomList.Add(new RoomVM() { Name = "B205", Description = "Thường", Status = "Tu Sửa" });
        }
    }

}
