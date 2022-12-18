using Hotel.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Hotel.ViewModel
{
    internal class RoomViewModel : BaseViewModel
    {
        private ObservableCollection<Phong> _roomList;
        public ObservableCollection<Phong> RoomList
        {
            get { return _roomList; }
            set { _roomList = value; OnPropertyChanged(); }
        }

        public ICommand ShowMessage { get; set; }

        public RoomViewModel()
        {
            ShowMessage = new RelayCommand<RoomView>((parameter) => true, (parameter) =>
            {
            });



            RoomList = new ObservableCollection<Phong>();
            LoadDemo();
        }

        public void LoadDemo()
        {
            RoomList.Add(new Phong() { Name = "B101", Description = "Thường", Status = "Trống" });
            RoomList.Add(new Phong() { Name = "B102", Description = "Vip", Status = "Đã đặt" });
            RoomList.Add(new Phong() { Name = "B103", Description = "Thường", Status = "Tu Sua" });
            RoomList.Add(new Phong() { Name = "B104", Description = "Thường", Status = "Trống" });
            RoomList.Add(new Phong() { Name = "B105", Description = "Thường", Status = "Tu Sửa" });
            RoomList.Add(new Phong() { Name = "B106", Description = "Thường", Status = "Đã đặt" });
            RoomList.Add(new Phong() { Name = "B107", Description = "Thường", Status = "Tu Sửa" });
            RoomList.Add(new Phong() { Name = "B108", Description = "Thường", Status = "Tu Sửa" });
            RoomList.Add(new Phong() { Name = "B109", Description = "Thường", Status = "Tu Sửa" });
            RoomList.Add(new Phong() { Name = "B201", Description = "Thường", Status = "Tu Sửa" });
            RoomList.Add(new Phong() { Name = "B202", Description = "Thường", Status = "Tu Sửa" });
            RoomList.Add(new Phong() { Name = "B203", Description = "Thường", Status = "Tu Sửa" });
            RoomList.Add(new Phong() { Name = "B204", Description = "Thường", Status = "Tu Sửa" });
            RoomList.Add(new Phong() { Name = "B205", Description = "Thường", Status = "Tu Sửa" });
            RoomList.Add(new Phong() { Name = "B101", Description = "Thường", Status = "Trống" });
            RoomList.Add(new Phong() { Name = "B102", Description = "Vip", Status = "Đã đặt" });
            RoomList.Add(new Phong() { Name = "B103", Description = "Thường", Status = "Tu Sua" });
            RoomList.Add(new Phong() { Name = "B104", Description = "Thường", Status = "Trống" });
            RoomList.Add(new Phong() { Name = "B105", Description = "Thường", Status = "Tu Sửa" });
            RoomList.Add(new Phong() { Name = "B106", Description = "Thường", Status = "Đã đặt" });
            RoomList.Add(new Phong() { Name = "B107", Description = "Thường", Status = "Tu Sửa" });
            RoomList.Add(new Phong() { Name = "B108", Description = "Thường", Status = "Tu Sửa" });
            RoomList.Add(new Phong() { Name = "B109", Description = "Thường", Status = "Tu Sửa" });
            RoomList.Add(new Phong() { Name = "B201", Description = "Thường", Status = "Tu Sửa" });
            RoomList.Add(new Phong() { Name = "B202", Description = "Thường", Status = "Tu Sửa" });
            RoomList.Add(new Phong() { Name = "B203", Description = "Thường", Status = "Tu Sửa" });
            RoomList.Add(new Phong() { Name = "B204", Description = "Thường", Status = "Tu Sửa" });
            RoomList.Add(new Phong() { Name = "B205", Description = "Thường", Status = "Tu Sửa" });
            RoomList.Add(new Phong() { Name = "B101", Description = "Thường", Status = "Trống" });
            RoomList.Add(new Phong() { Name = "B102", Description = "Vip", Status = "Đã đặt" });
            RoomList.Add(new Phong() { Name = "B103", Description = "Thường", Status = "Tu Sua" });
            RoomList.Add(new Phong() { Name = "B104", Description = "Thường", Status = "Trống" });
            RoomList.Add(new Phong() { Name = "B105", Description = "Thường", Status = "Tu Sửa" });
            RoomList.Add(new Phong() { Name = "B106", Description = "Thường", Status = "Đã đặt" });
            RoomList.Add(new Phong() { Name = "B107", Description = "Thường", Status = "Tu Sửa" });
            RoomList.Add(new Phong() { Name = "B108", Description = "Thường", Status = "Tu Sửa" });
            RoomList.Add(new Phong() { Name = "B109", Description = "Thường", Status = "Tu Sửa" });
            RoomList.Add(new Phong() { Name = "B201", Description = "Thường", Status = "Tu Sửa" });
            RoomList.Add(new Phong() { Name = "B202", Description = "Thường", Status = "Tu Sửa" });
            RoomList.Add(new Phong() { Name = "B203", Description = "Thường", Status = "Tu Sửa" });
            RoomList.Add(new Phong() { Name = "B204", Description = "Thường", Status = "Tu Sửa" });
            RoomList.Add(new Phong() { Name = "B205", Description = "Thường", Status = "Tu Sửa" });
            RoomList.Add(new Phong() { Name = "B101", Description = "Thường", Status = "Trống" });
            RoomList.Add(new Phong() { Name = "B102", Description = "Vip", Status = "Đã đặt" });
            RoomList.Add(new Phong() { Name = "B103", Description = "Thường", Status = "Tu Sua" });
            RoomList.Add(new Phong() { Name = "B104", Description = "Thường", Status = "Trống" });
            RoomList.Add(new Phong() { Name = "B105", Description = "Thường", Status = "Tu Sửa" });
            RoomList.Add(new Phong() { Name = "B106", Description = "Thường", Status = "Đã đặt" });
            RoomList.Add(new Phong() { Name = "B107", Description = "Thường", Status = "Tu Sửa" });
            RoomList.Add(new Phong() { Name = "B108", Description = "Thường", Status = "Tu Sửa" });
            RoomList.Add(new Phong() { Name = "B109", Description = "Thường", Status = "Tu Sửa" });
            RoomList.Add(new Phong() { Name = "B201", Description = "Thường", Status = "Tu Sửa" });
            RoomList.Add(new Phong() { Name = "B202", Description = "Thường", Status = "Tu Sửa" });
            RoomList.Add(new Phong() { Name = "B203", Description = "Thường", Status = "Tu Sửa" });
            RoomList.Add(new Phong() { Name = "B204", Description = "Thường", Status = "Tu Sửa" });
            RoomList.Add(new Phong() { Name = "B205", Description = "Thường", Status = "Tu Sửa" });
        }
    }
    public class Phong
    {
        public Phong(string name, string description, string status)
        {
            Name = name;
            Description = description;
            Status = status;
        }
        public Phong()
        {

        }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
    }
}
