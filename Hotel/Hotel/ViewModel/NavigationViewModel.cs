using Hotel.Model;
using Hotel.View;
using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Threading;
using System.Linq;

namespace Hotel.ViewModel
{
    internal class NavigationViewModel : BaseViewModel
    {
        private int secondReset = 2;
        private double FontBase = 12;
        private double _isHome;
        private string bell = "/Images/Bell.png";
        private string bellActive = "/Images/Active.png";
        private readonly DispatcherTimer _timer;
        private int idnv = 0;

        private ObservableCollection<BillVM> _lvNotify;

        public ObservableCollection<BillVM> LvNotify
        {
            get { return _lvNotify; }
            set { _lvNotify = value; OnPropertyChanged(); }
        }

        public double IsHome
        {
            get { return _isHome; }
            set { _isHome = value; OnPropertyChanged(); }
        }

        private double _isReservation;

        public double IsReservation
        {
            get { return _isReservation; }
            set { _isReservation = value; OnPropertyChanged(); }
        }
        private double _isCustomer;

        public double IsCustomer
        {
            get { return _isCustomer; }
            set { _isCustomer = value; OnPropertyChanged(); }
        }

        private double _isRoomManagement;

        public double IsRoomManagement
        {
            get { return _isRoomManagement; }
            set { _isRoomManagement = value; OnPropertyChanged(); }
        }

        private double _isBill;

        public double IsBill
        {
            get { return _isBill; }
            set { _isBill = value; OnPropertyChanged(); }
        }

        private double _isServiceManagement;

        public double IsServiceManagement
        {
            get { return _isServiceManagement; }
            set { _isServiceManagement = value; OnPropertyChanged(); }
        }

        private double _isEmployeeManagement;

        public double IsEmployeeManagement
        {
            get { return _isEmployeeManagement; }
            set { _isEmployeeManagement = value; OnPropertyChanged(); }
        }
        private double _isDashBoard;

        public double IsDashBoard
        {
            get { return _isDashBoard; }
            set { _isDashBoard = value; OnPropertyChanged(); }
        }

        private object _currentView;
        public object CurrentView
        {
            get { return _currentView; }
            set { _currentView = value; OnPropertyChanged(); }
        }

        private string _notification;

        public string Notification
        {
            get { return _notification; }
            set { _notification = value; OnPropertyChanged(); }
        }
        private string _visNotify;

        public string VisNotify
        {
            get { return _visNotify; }
            set { _visNotify = value; OnPropertyChanged(); }
        }
        public ICommand LoadIdStaff { get; set; }
        public ICommand LogoutCommand { get; set; }
        public ICommand GetUidCommand { get; set; }
        public ICommand MakeNavigation { get; set; }
        public ICommand GetNotification { get; set; }
        public ICommand ChoseNotify { get; set; }
        private string uid = "0";

        public NavigationViewModel()
        {
            LoadIdStaff = new RelayCommand<MainWindow>((parameter) => true, (parameter) => { idnv = Convert.ToInt32(parameter._EID.Text); });
            LogoutCommand = new RelayCommand<Window>((parameter) => true, (parameter) => logout(parameter));
            GetUidCommand = new RelayCommand<Button>((parameter) => true, (parameter) => uid = parameter.Uid);
            MakeNavigation = new RelayCommand<Button>((parameter) => true, (parameter) => makeNavigation(parameter));
            GetNotification = new RelayCommand<object>((parameter) => true, (parameter) => readNotification());
            ChoseNotify = new RelayCommand<object>((parameter) => true, (parameter) => choseNotify(parameter));

            IsHome = FontBase + 1;
            IsReservation = FontBase;
            IsCustomer = FontBase;
            IsRoomManagement = FontBase;
            IsBill = FontBase;
            IsServiceManagement = FontBase;
            IsEmployeeManagement = FontBase;
            IsDashBoard = FontBase;

            CurrentView = new RoomView();

            //testc bell
            Notification = bell;
            VisNotify = "Hidden";

            //timer
            _timer = new DispatcherTimer { Interval = TimeSpan.FromSeconds(secondReset) };
            _timer.Start();
            _timer.Tick += (o, e) => checkNotify();


            //demo líst notify
            //loadDbNotify();
        }
        private void makeNavigation(Button parameter)
        {
            IsHome = FontBase;
            IsReservation = FontBase;
            IsCustomer = FontBase;
            IsRoomManagement = FontBase;
            IsBill = FontBase;
            IsServiceManagement = FontBase;
            IsEmployeeManagement = FontBase;
            IsDashBoard = FontBase;

            switch (uid)
            {
                case "0":
                    IsHome = FontBase + 1;
                    CurrentView = new RoomView();
                    break;
                case "1":
                    IsReservation = FontBase + 1;
                    CurrentView = new ReservationBookView();
                    break;
                case "2":
                    IsCustomer = FontBase + 1;
                    CurrentView = new CustomerManagementView();
                    break;
                case "3":
                    IsRoomManagement = FontBase + 1;
                    CurrentView = new RoomManagementView();
                    break;
                case "4":
                    IsBill = FontBase + 1;
                    CurrentView = new BillView();
                    break;
                case "5":
                    IsServiceManagement = FontBase + 1;
                    CurrentView = new ServiceManagementView();
                    break;
                case "6":
                    IsEmployeeManagement = FontBase + 1;
                    CurrentView = new EmployeeManagementView();
                    break;
                case "7":
                    IsDashBoard = FontBase + 1;
                    CurrentView = new DashBoardView();
                    break;
                default:
                    break;
            }
        }
        private void logout(Window parameter)
        {
            parameter.Hide();
            LoginView login = new LoginView();
            login.ShowDialog();
            parameter.Close();
        }
        private void readNotification()
        {
            if (VisNotify == "Hidden")
                VisNotify = "Visible";
            else
                VisNotify = "Hidden";
        }
        private void checkNotify()
        {
            loadDbNotify();
        }
        private void choseNotify(object ob)
        {
            BillVM bill = (BillVM)ob;
            if (bill.Status == "Đang sử dụng")
            {
                RoomDetail r = new RoomDetail();
                using (var db = new QLYHOTELEntities())
                {
                    var select = (from i in db.DATs where i.MADAT == bill.ID select i).Single();
                    r.idbook.Text = bill.ID.ToString();
                    r.txblTenKH.Text = select.KHACH.TENKH;
                    r.txblCCCD.Text = select.KHACH.CCCD;
                    r.txblNgayDen.Text = select.NGAYDAT.Value.ToString();
                    r.txbNgayTra.Text = select.NGAYTRA.Value.ToString();
                    r.txblSoNguoi.Text = select.SONG.ToString();
                    r.Uid = idnv.ToString();
                    if (select.TRANGTHAI == "Đã đặt")
                        r.btnAccept.Content = "Nhận phòng";
                    else
                        r.btnAccept.Content = "Thanh toán";
                    r.btnSave.Visibility = Visibility.Collapsed;
                }
                r.ShowDialog();
                loadDbNotify();
            }
        }
        private void loadDbNotify()
        {
            Notification = bell;
            var TimeNow = DateTime.Now;
            LvNotify = new ObservableCollection<BillVM>();
            using (var db = new QLYHOTELEntities())
            {
                var select = from s in db.PHONGs select s;
                foreach (var room in select)
                {
                    foreach (var info in room.DATs)
                    {
                        if (info.TRANGTHAI == "Đã thanh toán")
                            LvNotify.Add(new BillVM() { ID = info.MADAT, RoomName = info.PHONG.TENPHONG, CustomerName = info.KHACH.TENKH, StaffName = info.NHANVIEN.TENNV, Status = info.TRANGTHAI, Total = (int)info.THANHTIEN, DateEnd = (DateTime)info.NGAYTRA });
                    }
                }
                LvNotify = new ObservableCollection<BillVM>(LvNotify.OrderByDescending(i => i.DateEnd));
                foreach (var room in select)
                {
                    foreach (var info in room.DATs)
                    {
                        if (info.TRANGTHAI == "Đang sử dụng" && (info.NGAYTRA.Value - TimeNow).TotalMinutes <= 30)
                        {
                            LvNotify.Insert(0, new BillVM() { ID = info.MADAT, RoomName = info.PHONG.TENPHONG, CustomerName = info.KHACH.TENKH, StaffName = info.NHANVIEN.TENNV, Status = info.TRANGTHAI, DateEnd = (DateTime)info.NGAYTRA });
                            Notification = bellActive;
                        }
                    }
                }
            }
        }
    }
}
