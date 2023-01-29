using Hotel.Model;
using Hotel.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;
using System.Xml.Linq;

namespace Hotel.ViewModel
{
    internal class RoomManagementViewModel : BaseViewModel
    {
        private ObservableCollection<RoomManagementVM> _RoomManagementList;
        public ObservableCollection<RoomManagementVM> RoomManagementList
        {
            get { return _RoomManagementList; }
            set { _RoomManagementList = value; OnPropertyChanged(); }
        }
        private string _textToFilterR;

        public string TextToFilterR
        {
            get { return _textToFilterR; }
            set
            {
                _textToFilterR = value;
                OnPropertyChanged();
                RoomManagementCollection.Filter = FilterByName;
            }
        }
        private ICollectionView _RoomManagementCollection;

        public ICollectionView RoomManagementCollection
        {
            get { return _RoomManagementCollection; }
            set { _RoomManagementCollection = value; OnPropertyChanged(); }
        }
        public ICommand AddRoom { get; set; }
        public ICommand Edit { get; set; }
        public RoomManagementViewModel()
        {
            AddRoom = new RelayCommand<RoomManagementView>((p) => true, (p) => addRoom(p));
            Edit = new RelayCommand<object>((p) => true, (p) => editroom(p));
            LoadAllSV();
        }
        private bool FilterByName(object emp)
        {
            if (!string.IsNullOrEmpty(TextToFilterR))
            {
                var empDetail = emp as RoomManagementVM;
                return empDetail != null && empDetail.Name.IndexOf(TextToFilterR, StringComparison.OrdinalIgnoreCase) >= 0;
            }
            return true;
        }
        public void LoadAllSV()
        {
            if (RoomManagementList != null)
                RoomManagementList.Clear();
            else
                RoomManagementList = new ObservableCollection<RoomManagementVM>();
            using (var db = new QLYHOTELEntities())
            {
                var select = from s in db.PHONGs select s;
                foreach (var RoomManagement in select)
                {
                    string trangthai = RoomManagement.TRANGTHAI.ToString();
                    if (trangthai == "Trống")
                        trangthai = "Bình thường";
                    RoomManagementList.Add(new RoomManagementVM() { ID = RoomManagement.MAPHONG, Name = RoomManagement.TENPHONG.ToString(), Status = trangthai, Type = RoomManagement.LOAIPHONG.ToString(), Price = RoomManagement.DONGIA.Value });
                }
            }
            RoomManagementCollection = CollectionViewSource.GetDefaultView(RoomManagementList);
        }
        private void addRoom(RoomManagementView p)
        {
            new AddRoom().ShowDialog();
            LoadAllSV();
        }
        private void editroom(object p)
        {
            RoomManagementVM r = (RoomManagementVM)p;
            ChangeInfoRoom infoRoom = new ChangeInfoRoom();
            infoRoom.ID.Text = r.ID.ToString();
            infoRoom._Name.Text = r.Name;
            infoRoom._Price.Text = r.Price.ToString();
            infoRoom._Type.SelectedIndex = (r.Type == "Thường" ? 1 : 0);
            infoRoom.ShowDialog();
            LoadAllSV();
        }
    }

}
