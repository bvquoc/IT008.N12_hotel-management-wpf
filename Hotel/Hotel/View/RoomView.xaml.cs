using Hotel.ViewModel;
using System.Collections.Generic;
using System.Windows.Controls;

namespace Hotel.View
{
    /// <summary>
    /// Interaction logic for RoomView.xaml
    /// </summary>
    public partial class RoomView : UserControl
    {
        public RoomView()
        {
            InitializeComponent();

            DataContext = new RoomListViewModel();


            /*List<Phong> phongList = new List<Phong>();
            phongList.Add(new Phong() { Name = "B101", Description = "Thường", Status = "Trống" });
            phongList.Add(new Phong() { Name = "B102", Description = "Vip", Status = "Đã đặt" });
            phongList.Add(new Phong() { Name = "B103", Description = "Thường", Status = "Tu Sua" });
            phongList.Add(new Phong() { Name = "B104", Description = "Thường", Status = "Trống" });
            phongList.Add(new Phong() { Name = "B105", Description = "Thường", Status = "Tu Sửa" });
            phongList.Add(new Phong() { Name = "B106", Description = "Thường", Status = "Đã đặt" });
            phongList.Add(new Phong() { Name = "B107", Description = "Thường", Status = "Tu Sửa" });
            phongList.Add(new Phong() { Name = "B108", Description = "Thường", Status = "Tu Sửa" });
            phongList.Add(new Phong() { Name = "B109", Description = "Thường", Status = "Tu Sửa" });
            phongList.Add(new Phong() { Name = "B201", Description = "Thường", Status = "Tu Sửa" });
            phongList.Add(new Phong() { Name = "B202", Description = "Thường", Status = "Tu Sửa" });
            phongList.Add(new Phong() { Name = "B203", Description = "Thường", Status = "Tu Sửa" });
            phongList.Add(new Phong() { Name = "B204", Description = "Thường", Status = "Tu Sửa" });
            phongList.Add(new Phong() { Name = "B205", Description = "Thường", Status = "Tu Sửa" });
            phongList.Add(new Phong() { Name = "B101", Description = "Thường", Status = "Trống" });
            phongList.Add(new Phong() { Name = "B102", Description = "Vip", Status = "Đã đặt" });
            phongList.Add(new Phong() { Name = "B103", Description = "Thường", Status = "Tu Sua" });
            phongList.Add(new Phong() { Name = "B104", Description = "Thường", Status = "Trống" });
            phongList.Add(new Phong() { Name = "B105", Description = "Thường", Status = "Tu Sửa" });
            phongList.Add(new Phong() { Name = "B106", Description = "Thường", Status = "Đã đặt" });
            phongList.Add(new Phong() { Name = "B107", Description = "Thường", Status = "Tu Sửa" });
            phongList.Add(new Phong() { Name = "B108", Description = "Thường", Status = "Tu Sửa" });
            phongList.Add(new Phong() { Name = "B109", Description = "Thường", Status = "Tu Sửa" });
            phongList.Add(new Phong() { Name = "B201", Description = "Thường", Status = "Tu Sửa" });
            phongList.Add(new Phong() { Name = "B202", Description = "Thường", Status = "Tu Sửa" });
            phongList.Add(new Phong() { Name = "B203", Description = "Thường", Status = "Tu Sửa" });
            phongList.Add(new Phong() { Name = "B204", Description = "Thường", Status = "Tu Sửa" });
            phongList.Add(new Phong() { Name = "B205", Description = "Thường", Status = "Tu Sửa" });
            phongList.Add(new Phong() { Name = "B101", Description = "Thường", Status = "Trống" });
            phongList.Add(new Phong() { Name = "B102", Description = "Vip", Status = "Đã đặt" });
            phongList.Add(new Phong() { Name = "B103", Description = "Thường", Status = "Tu Sua" });
            phongList.Add(new Phong() { Name = "B104", Description = "Thường", Status = "Trống" });
            phongList.Add(new Phong() { Name = "B105", Description = "Thường", Status = "Tu Sửa" });
            phongList.Add(new Phong() { Name = "B106", Description = "Thường", Status = "Đã đặt" });
            phongList.Add(new Phong() { Name = "B107", Description = "Thường", Status = "Tu Sửa" });
            phongList.Add(new Phong() { Name = "B108", Description = "Thường", Status = "Tu Sửa" });
            phongList.Add(new Phong() { Name = "B109", Description = "Thường", Status = "Tu Sửa" });
            phongList.Add(new Phong() { Name = "B201", Description = "Thường", Status = "Tu Sửa" });
            phongList.Add(new Phong() { Name = "B202", Description = "Thường", Status = "Tu Sửa" });
            phongList.Add(new Phong() { Name = "B203", Description = "Thường", Status = "Tu Sửa" });
            phongList.Add(new Phong() { Name = "B204", Description = "Thường", Status = "Tu Sửa" });
            phongList.Add(new Phong() { Name = "B205", Description = "Thường", Status = "Tu Sửa" });
            phongList.Add(new Phong() { Name = "B101", Description = "Thường", Status = "Trống" });
            phongList.Add(new Phong() { Name = "B102", Description = "Vip", Status = "Đã đặt" });
            phongList.Add(new Phong() { Name = "B103", Description = "Thường", Status = "Tu Sua" });
            phongList.Add(new Phong() { Name = "B104", Description = "Thường", Status = "Trống" });
            phongList.Add(new Phong() { Name = "B105", Description = "Thường", Status = "Tu Sửa" });
            phongList.Add(new Phong() { Name = "B106", Description = "Thường", Status = "Đã đặt" });
            phongList.Add(new Phong() { Name = "B107", Description = "Thường", Status = "Tu Sửa" });
            phongList.Add(new Phong() { Name = "B108", Description = "Thường", Status = "Tu Sửa" });
            phongList.Add(new Phong() { Name = "B109", Description = "Thường", Status = "Tu Sửa" });
            phongList.Add(new Phong() { Name = "B201", Description = "Thường", Status = "Tu Sửa" });
            phongList.Add(new Phong() { Name = "B202", Description = "Thường", Status = "Tu Sửa" });
            phongList.Add(new Phong() { Name = "B203", Description = "Thường", Status = "Tu Sửa" });
            phongList.Add(new Phong() { Name = "B204", Description = "Thường", Status = "Tu Sửa" });
            phongList.Add(new Phong() { Name = "B205", Description = "Thường", Status = "Tu Sửa" });
            lvRoom.ItemsSource = phongList;
            */
        }
        /*
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
        */
    }
}
