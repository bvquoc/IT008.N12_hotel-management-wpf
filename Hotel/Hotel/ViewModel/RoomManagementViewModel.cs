using Hotel.Model;
using Hotel.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;

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
        private string _textToFilterSV;

        public string TextToFilterSV
        {
            get { return _textToFilterSV; }
            set
            {
                _textToFilterSV = value;
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
        public RoomManagementViewModel()
        {
            RoomManagementList = new ObservableCollection<RoomManagementVM>();
            //LoadDemo();
            LoadAllSV();
            RoomManagementCollection = CollectionViewSource.GetDefaultView(RoomManagementList);
        }
        private bool FilterByName(object emp)
        {
            if (!string.IsNullOrEmpty(TextToFilterSV))
            {
                var empDetail = emp as RoomManagementVM;
                return empDetail != null && empDetail.ID.IndexOf(TextToFilterSV, StringComparison.OrdinalIgnoreCase) >= 0;
            }
            return true;
        }
        public void LoadAllSV()
        {
            using (var db = new QLYHOTELEntities())
            {
                var select = from s in db.PHONGs select s;
                foreach (var RoomManagement in select)
                    RoomManagementList.Add(new RoomManagementVM() { ID = RoomManagement.TENPHONG.ToString(), Status = RoomManagement.TRANGTHAI.ToString(), Type = RoomManagement.LOAIPHONG.ToString(),Price=RoomManagement.DONGIA.Value });
            }
        }
      
    }

}
