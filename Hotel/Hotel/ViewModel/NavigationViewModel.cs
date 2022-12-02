using Hotel.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Hotel.ViewModel
{
    internal class NavigationViewModel : BaseViewModel
    {
        private object _currentView;
        public object CurrentView
        {
            get { return _currentView; }
            set { _currentView = value; OnPropertyChanged(); }
        }
        public ICommand RoomView { get; set; }
        public ICommand ReservationBookView { get; set; }
        public ICommand ManageCustomerView { get; set; }
        public ICommand ManageRoomView { get; set; }
        public ICommand BillView { get; set; }
        public ICommand ManageServiceView { get; set; }
        public ICommand MakeNavigation { get; set; }
        private string uid;
        public NavigationViewModel()
        {

            GetFrame = new RelayCommand<Frame>((parameter) => true, (parameter) => CurrentView = parameter);

            GetUidCommand = new RelayCommand<Button>((parameter) => true, (parameter) => uid = parameter.Uid);

            MakeNavigation = new RelayCommand<Button>((parameter) => true, (parameter) =>
            {
                switch (uid)
                {
                    case "0":
                        CurrentView.Content = new PhongView();
                        break;
                    case "1":
                        CurrentView.Content = new DatPhongView();
                        break;
                    case "2":
                        CurrentView.Content = new QuanLyDVView();
                        break;
                    case "3":
                        CurrentView.Content = new QuanLyPhongView();
                        break;
                    case "4":
                        CurrentView.Content = new HoaDonView();
                        break;
                    case "5":
                        CurrentView.Content = new QuanLyDVView();
                        break;
                    default: throw new ArgumentOutOfRangeException(nameof(uid));
                }
            });
            CurrentView.Content = new PhongView();
        }
    }
}
