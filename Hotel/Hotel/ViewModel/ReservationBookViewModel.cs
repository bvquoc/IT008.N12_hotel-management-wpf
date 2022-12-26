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
    internal class ReservationBookViewModel : BaseViewModel
    {
        private ObservableCollection<RoomVM> _rooms;
        public ObservableCollection<RoomVM> Rooms
        {
            get { return _rooms; }
            set { _rooms = value; OnPropertyChanged(); }
        }
        public ICommand EditCustomerCommand { get; set; }

        public ReservationBookViewModel()
        {
            EditCustomerCommand = new RelayCommand<ReservationBookView>((p) => true, (p) => saveReservate(p));

            Rooms = new ObservableCollection<RoomVM>();
            LoadDemo();
        }
        private void saveReservate(ReservationBookView p)
        {
            try
            {
                int dayStart = p.dtpNgayBD.SelectedDate.Value.Day;
                int monthStart = p.dtpNgayBD.SelectedDate.Value.Month;
                int yearStart = p.dtpNgayBD.SelectedDate.Value.Year;
                int hourStart = p.tpGioBD.SelectedTime.Value.Hour;
                int minuteStart = p.tpGioBD.SelectedTime.Value.Minute;

                int dayEnd = p.dtpNgayKT.SelectedDate.Value.Day;
                int monthEnd = p.dtpNgayKT.SelectedDate.Value.Month;
                int yearEnd = p.dtpNgayKT.SelectedDate.Value.Year;
                int hourEnd = p.tpGioKT.SelectedTime.Value.Hour;
                int minuteEnd = p.tpGioKT.SelectedTime.Value.Minute;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
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
