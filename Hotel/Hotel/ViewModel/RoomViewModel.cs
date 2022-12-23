using Hotel.Model;
using Hotel.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Hotel.ViewModel
{
    internal class RoomViewModel : BaseViewModel
    {
        private ObservableCollection<RoomVM> _roomListdb;
        private ObservableCollection<RoomVM> _roomList;
        public ObservableCollection<RoomVM> RoomList
        {
            get { return _roomList; }
            set { _roomList = value; OnPropertyChanged(); }
        }
        private ComboBoxItem _sortRoom;
        public ComboBoxItem SortRoom
        {
            get { return _sortRoom; }
            set { _sortRoom = value; OnPropertyChanged(); }
        }
        public ICommand btnAll { get; set; }
        public ICommand btnAvailabel { get; set; }
        public ICommand btnOrdered { get; set; }
        public ICommand btnRepair { get; set; }
        public ICommand sortRoom { get; set; }
        public RoomViewModel()
        {
            RoomList = new ObservableCollection<RoomVM>();

            btnAll = new RelayCommand<object>((p) => true, (p) =>
            {
                LoadAllRoom();
            });
            btnAvailabel = new RelayCommand<object>((p) => true, (p) =>
            {
                LoadAvailabel();
            });
            btnOrdered = new RelayCommand<object>((p) => true, (p) =>
            {
                LoadOrdered();
            });
            btnRepair = new RelayCommand<object>((p) => true, (p) =>
            {
                LoadRepair();
            });
            sortRoom = new RelayCommand<object>((p) => true, (p) =>
            {
                if ((string)SortRoom.Content == "Tầng")
                {
                    var list = new List<RoomVM>(_roomList);
                    _roomList.Clear();
                    list.Sort((x, y) => compareFloor(x, y));
                    _roomList = new ObservableCollection<RoomVM>(list);
                    list.Clear();

                    list = new List<RoomVM>(RoomList);
                    RoomList.Clear();
                    list.Sort((x, y) => compareFloor(x, y));
                    RoomList = new ObservableCollection<RoomVM>(list);
                    list.Clear();
                }
                if ((string)SortRoom.Content == "Loại phòng")
                {
                    _roomListdb = new ObservableCollection<RoomVM>(_roomListdb.OrderBy(i => i.Description));
                    RoomList = new ObservableCollection<RoomVM>(RoomList.OrderBy(i => i.Description));
                }
            });
            LoadDbRoom();
        }
        public int compareFloor(RoomVM x, RoomVM y)
        {
            if (x.Name.Substring(1, 1) == y.Name.Substring(1, 1))
            {
                if (x.Name.Substring(0, 1) == y.Name.Substring(0, 1))
                    return x.Name.CompareTo(y.Name);
                return x.Name.Substring(0, 1).CompareTo(y.Name.Substring(0, 1));
            }
            return x.Name.Substring(1, 1).CompareTo(y.Name.Substring(1, 1));
        }
        public void LoadDbRoom()
        {
            _roomListdb = new ObservableCollection<RoomVM>();
            using (var db = new QLYHOTELEntities())
            {
                var select = from s in db.PHONGs select s;
                foreach (var room in select)
                {
                    _roomListdb.Add(new RoomVM() { Name = room.TENPHONG.ToString(), Description = room.LOAIPHONG.ToString(), Status = room.TRANGTHAI.ToString() });
                    RoomList.Add(new RoomVM() { Name = room.TENPHONG.ToString(), Description = room.LOAIPHONG.ToString(), Status = room.TRANGTHAI.ToString() });
                }
            }
        }
        public void LoadAllRoom()
        {
            RoomList.Clear();
            foreach (var room in _roomListdb)
                RoomList.Add(room);
        }
        public void LoadAvailabel()
        {
            RoomList.Clear();
            foreach (var room in _roomListdb)
                if (room.Status == "Trống")
                    RoomList.Add(room);
        }
        public void LoadOrdered()
        {
            RoomList.Clear();
            foreach (var room in _roomListdb)
                if (room.Status == "Đã đặt")
                    RoomList.Add(room);
        }
        public void LoadRepair()
        {
            RoomList.Clear();
            foreach (var room in _roomListdb)
                if (room.Status == "Tu sửa")
                    RoomList.Add(room);
        }
    }

}
