using Hotel.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Hotel.ViewModel
{
    internal class NavigationViewModel : BaseViewModel
    {
        private double FontBase = 12;
        private double _isHome;

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

        public ICommand LogoutCommand { get; set; }
        public ICommand GetUidCommand { get; set; }
        public ICommand MakeNavigation { get; set; }
        private string uid = "0";

        public NavigationViewModel()
        {
            LogoutCommand = new RelayCommand<Button>((parameter) => true, (parameter) =>
            {
                //Logout
            });

            GetUidCommand = new RelayCommand<Button>((parameter) => true, (parameter) => uid = parameter.Uid);

            MakeNavigation = new RelayCommand<Button>((parameter) => true, (parameter) =>
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
            });
            IsHome = FontBase + 1;
            IsReservation = FontBase;
            IsCustomer = FontBase;
            IsRoomManagement = FontBase;
            IsBill = FontBase;
            IsServiceManagement = FontBase;
            IsEmployeeManagement = FontBase;

            CurrentView = new RoomView();
        }
    }
}
