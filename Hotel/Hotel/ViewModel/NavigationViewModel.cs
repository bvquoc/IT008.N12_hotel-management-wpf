using Hotel.View;
using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Threading;

namespace Hotel.ViewModel
{
    internal class NavigationViewModel : BaseViewModel
    {
        private double FontBase = 12;
        private double _isHome;
        private string bell = "/Images/Bell.png";
        private string bellActive = "/Images/Active.png";
        private readonly DispatcherTimer _timer;

        private ObservableCollection<demoNotify> _lvNotify;

        public ObservableCollection<demoNotify> LvNotify
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

        public ICommand LogoutCommand { get; set; }
        public ICommand GetUidCommand { get; set; }
        public ICommand MakeNavigation { get; set; }
        public ICommand GetNotification { get; set; }
        public ICommand ChoseNotify { get; set; }
        private string uid = "0";

        public NavigationViewModel()
        {
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

            CurrentView = new RoomView();

            //testc bell
            Notification = bell;
            VisNotify = "Hidden";

            //timer
            _timer = new DispatcherTimer { Interval = TimeSpan.FromMinutes(5) };
            _timer.Start();
            _timer.Tick += (o, e) => checkNotify();


            //demo líst notify
            LvNotify = new ObservableCollection<demoNotify>();
            LvNotify.Add(new demoNotify() { ID = 12, CustomerName = "Nguyễn Văn A", RoomName = "P102", Status = "Chưa Thanh Toán" });
            LvNotify.Add(new demoNotify() { ID = 12, CustomerName = "Nguyễn Văn A", RoomName = "P102", Status = "Đã Thanh Toán" });
            LvNotify.Add(new demoNotify() { ID = 12, CustomerName = "Nguyễn Văn A", RoomName = "P102", Status = "Chưa Thanh Toán" });
            LvNotify.Add(new demoNotify() { ID = 12, CustomerName = "Nguyễn Văn A", RoomName = "P102", Status = "Đã Thanh Toán" });
            LvNotify.Add(new demoNotify() { ID = 12, CustomerName = "Nguyễn Văn A", RoomName = "P102", Status = "Chưa Thanh Toán" });
            LvNotify.Add(new demoNotify() { ID = 12, CustomerName = "Nguyễn Văn A", RoomName = "P102", Status = "Chưa Thanh Toán" });
            LvNotify.Add(new demoNotify() { ID = 12, CustomerName = "Nguyễn Văn A", RoomName = "P102", Status = "Đã Thanh Toán" });
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
            if (Notification == bell)
                Notification = bellActive;
            else
                Notification = bell;
            if (VisNotify == "Hidden")
                VisNotify = "Visible";
            else
                VisNotify = "Hidden";
        }
        private void checkNotify()
        {
            if (IsHome == FontBase + 1)
            {
                CurrentView = new RoomView();
                //continue
            }
        }
        private void choseNotify(object ob)
        {
            //demo
        }
    }
    public class demoNotify
    {
        public int ID { get; set; }
        public string RoomName { get; set; }
        public string CustomerName { get; set; }
        public string Status { get; set; }
        public demoNotify()
        {

        }
    }
}
