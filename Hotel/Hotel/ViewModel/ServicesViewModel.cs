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
        public ICommand LoadAddService { get; set; }
        public ServiceViewModel()
        {
            LoadAddService = new RelayCommand<object>((p) => true, (p) =>
            {
                AddService addService = new AddService();
                addService.ShowDialog();
                LoadAllSV();
            });
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
            if (ServiceList != null)
                ServiceList.Clear();
            else
                ServiceList = new ObservableCollection<ServiceVM>();
            using (var db = new QLYHOTELEntities())
            {
                var select = from s in db.DICHVUs select s;
                foreach (var service in select)
                {
                    if (service.IsDelete != 1)
                        ServiceList.Add(new ServiceVM() { ID = service.MADV.ToString(), Name = service.TENDV.ToString(), Price = service.DONGIA.Value });
                }
            }
            ServiecCollection = CollectionViewSource.GetDefaultView(ServiceList);
        }
    }
}
