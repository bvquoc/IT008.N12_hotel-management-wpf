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
    internal class ReservationBookViewModel : BaseViewModel
    {
        private ObservableCollection<RoomVM> _rooms;
        public ObservableCollection<RoomVM> Rooms
        {
            get { return _rooms; }
            set { _rooms = value; OnPropertyChanged(); }
        }
        private ObservableCollection<RoomViewModel> _selectedRooms;
        public ObservableCollection<RoomViewModel> SelectedRooms
        {
            get { return _selectedRooms; }
            set { _selectedRooms = value; OnPropertyChanged(); }
        }
        private DateTime _dateStart;
        public DateTime DateStart
        {
            get { return _dateStart; }
            set { _dateStart = value; OnPropertyChanged(); LoadRoom(); }
        }
        private DateTime _dateEnd;
        public DateTime DateEnd
        {
            get { return _dateEnd; }
            set { _dateEnd = value; OnPropertyChanged(); LoadRoom(); }
        }
        private DateTime _timeStart;

        public DateTime TimeStart
        {
            get { return _timeStart; }
            set { _timeStart = value; OnPropertyChanged(); LoadRoom(); }
        }
        private DateTime _timeEnd;

        public DateTime TimeEnd
        {
            get { return _timeEnd; }
            set { _timeEnd = value; OnPropertyChanged(); LoadRoom(); }
        }


        public ICommand EditCustomerCommand { get; set; }

        public ReservationBookViewModel()
        {
            EditCustomerCommand = new RelayCommand<ReservationBookView>((p) => true, (p) => saveReservate(p));

            Rooms = new ObservableCollection<RoomVM>();

            DateStart = DateTime.Now;
            DateEnd = DateTime.Now;
            TimeStart = DateTime.Now;
            TimeEnd = DateTime.Now;
            LoadRoom();
        }
        private void LoadRoom()
        {
            DateTime start = new DateTime(DateStart.Year, DateStart.Month, DateStart.Day, TimeStart.Hour, TimeStart.Minute, TimeStart.Second);
            DateTime end = new DateTime(DateEnd.Year, DateEnd.Month, DateEnd.Day, TimeEnd.Hour, TimeEnd.Minute, TimeEnd.Second);

            Rooms.Clear();
            using (var db = new QLYHOTELEntities())
            {
                var select = from s in db.PHONGs select s;
                foreach (var room in select)
                {
                    if (room.DATs.Count == 0)
                        Rooms.Add(new RoomVM() { Name = room.TENPHONG.ToString(), Description = room.LOAIPHONG.ToString(), Status = room.TRANGTHAI.ToString() });
                    else
                        foreach (var dat in room.DATs)
                        {
                            if (DateTime.Compare(dat.NGAYTRA.Value, start) >= 0 &&
                                DateTime.Compare(dat.NGAYDAT.Value, end) <= 0)
                                break;
                            Rooms.Add(new RoomVM() { Name = room.TENPHONG.ToString(), Description = room.LOAIPHONG.ToString(), Status = room.TRANGTHAI.ToString() });
                        }

                }
            }
        }
        private void saveReservate(ReservationBookView p)
        {
            MessageBox.Show((DateStart.Date).ToString());
            return;
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
    }
}
