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
        public ICommand PhongView { get; set; }
        public ICommand DatPhongView { get; set; }
        public ICommand QuanLyKHView { get; set; }
        public ICommand QuanLyPhongView { get; set; }
        public ICommand HoaDonView { get; set; }
        public ICommand QuanLyDVView { get; set; }
        public ICommand MakeNavigation { get; set; }
        public NavigationViewModel()
        {
            PhongView = new RelayCommand<Frame>((parameter) => true, (parameter) =>
            {
                parameter.Content = new PhongView();
            });
            DatPhongView = new RelayCommand<Frame>((parameter) => true, (parameter) =>
            {
                parameter.Content = new DatPhongView();
            });
            QuanLyKHView = new RelayCommand<Frame>((parameter) => true, (parameter) =>
            {
                parameter.Content = new QuanLyKHView();
            });
            QuanLyPhongView = new RelayCommand<Frame>((parameter) => true, (parameter) =>
            {
                parameter.Content = new QuanLyPhongView();
            });
            HoaDonView = new RelayCommand<Frame>((parameter) => true, (parameter) =>
            {
                parameter.Content = new HoaDonView();
            });
            QuanLyDVView = new RelayCommand<Frame>((parameter) => true, (parameter) =>
            {
                parameter.Content = new QuanLyDVView();
            });
            MakeNavigation = new RelayCommand<Button>((parameter) => true, (parameter) =>
            {
                MessageBox.Show(parameter.Name.ToString());
            });
            CurrentView = new PhongView();
        }
    }
}
