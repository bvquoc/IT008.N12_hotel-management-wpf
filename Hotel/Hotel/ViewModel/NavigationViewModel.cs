using Hotel.Utilities;
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
    internal class NavigationViewModel : ViewModelBase
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
        public NavigationViewModel()
        {
            RoomView = new RelayCommand<Frame>((parameter) => true, (parameter) =>
            {
                parameter.Content = new RoomView();
            });
            ReservationBookView = new RelayCommand<Frame>((parameter) => true, (parameter) =>
            {
                parameter.Content = new ReservationBookView();
            });
            ManageCustomerView = new RelayCommand<Frame>((parameter) => true, (parameter) =>
            {
                parameter.Content = new ManageCustomerView();
            });
            ManageRoomView = new RelayCommand<Frame>((parameter) => true, (parameter) =>
            {
                parameter.Content = new ManageRoomView();
            });
            BillView = new RelayCommand<Frame>((parameter) => true, (parameter) =>
            {
                parameter.Content = new BillView();
            });
            ManageServiceView = new RelayCommand<Frame>((parameter) => true, (parameter) =>
            {
                parameter.Content = new ManageServiceView();
            });
            MakeNavigation = new RelayCommand<Button>((parameter) => true, (parameter) =>
            {
                MessageBox.Show(parameter.Name.ToString());
            });
            CurrentView = new RoomView();
        }
    }
}
