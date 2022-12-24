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
    internal class ServiceViewModel : BaseViewModel
    {
        private ObservableCollection<ServiceVM> _ServiceList;
        public ObservableCollection<ServiceVM> ServiceList
        {
            get { return _ServiceList; }
            set { _ServiceList = value; OnPropertyChanged(); }
        }
        private string _textToFilterSV;

        public string TextToFilterSV
        {
            get { return _textToFilterSV; }
            set
            {
                _textToFilterSV = value;
                OnPropertyChanged();
                ServiecCollection.Filter = FilterByName;
            }
        }
        private ICollectionView _serviecCollection;

        public ICollectionView ServiecCollection
        {
            get { return _serviecCollection; }
            set { _serviecCollection = value; OnPropertyChanged(); }
        }
        public ServiceViewModel()
        {
            LoadAllSV();
        }
        private bool FilterByName(object emp)
        {
            if (!string.IsNullOrEmpty(TextToFilterSV))
            {
                var empDetail = emp as ServiceVM;
                return empDetail != null && empDetail.Name.IndexOf(TextToFilterSV, StringComparison.OrdinalIgnoreCase) >= 0;
            }
            return true;
        }
        public void LoadAllSV()
        {
            ServiceList = new ObservableCollection<ServiceVM>();
            using (var db = new QLYHOTELEntities())
            {
                var select = from s in db.DICHVUs select s;
                foreach (var service in select)
                    ServiceList.Add(new ServiceVM() { ID = service.MADV.ToString(), Name = service.TENDV.ToString(), Price = service.DONGIA.Value });
            }
            ServiecCollection = CollectionViewSource.GetDefaultView(ServiceList);
        }
        public void LoadDemo()
        {
            ServiceList.Add(new ServiceVM() { ID = "B101", Name = "Mì", Price = 1003340 });
            ServiceList.Add(new ServiceVM() { ID = "B102", Name = "Bánh", Price = 10000 });
            ServiceList.Add(new ServiceVM() { ID = "B103", Name = "Buffe", Price = 10000 });
            ServiceList.Add(new ServiceVM() { ID = "B104", Name = "Hồ bơi", Price = 10000 });
            ServiceList.Add(new ServiceVM() { ID = "B105", Name = "Karaoke", Price = 10000 });
            ServiceList.Add(new ServiceVM() { ID = "B106", Name = "Massage", Price = 10000 });
            ServiceList.Add(new ServiceVM() { ID = "B107", Name = "18+", Price = 10000 });
            ServiceList.Add(new ServiceVM() { ID = "B108", Name = "Cinema", Price = 10000 });
            ServiceList.Add(new ServiceVM() { ID = "B109", Name = "Video game", Price = 10000 });

        }
    }

}
