﻿using Hotel.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace Hotel.ViewModel
{
    internal class CustomerManagementViewModel : BaseViewModel
    {
        private ObservableCollection<CustomerManagementVM> _customerList;
        public ObservableCollection<CustomerManagementVM> CustomerList
        {
            get { return _customerList; }
            set { _customerList = value; OnPropertyChanged(); }
        }
        private string _textToFilterCu;
        public string TextToFilterCu
        {
            get { return _textToFilterCu; }
            set
            {
                _textToFilterCu = value;
                OnPropertyChanged();
                CustomerCollection.Filter = FilterByName;
            }
        }
        private ICollectionView _customerCollection;
        public ICollectionView CustomerCollection
        {
            get { return _customerCollection; }
            set { _customerCollection = value; OnPropertyChanged(); }
        }
        public CustomerManagementViewModel()
        {

            LoadDb();
        }
        private void LoadDb()
        {
            if (CustomerList != null)
                CustomerList.Clear();
            else
                CustomerList = new ObservableCollection<CustomerManagementVM>();
            using (var db = new QLYHOTELEntities())
            {
                var select = from s in db.KHACHes select s;
                foreach (var item in select)
                    CustomerList.Add(new CustomerManagementVM() { MaKh = item.MAKH, Name = item.TENKH, CCCD = item.CCCD, DiaChi = item.DCHI, SDT = item.SDT, Sex = item.GIOITINH });
            }
            CustomerCollection = CollectionViewSource.GetDefaultView(CustomerList);
        }
        private bool FilterByName(object emp)
        {
            if (!string.IsNullOrEmpty(TextToFilterCu))
            {
                var empDetail = emp as CustomerManagementVM;
                return empDetail != null && empDetail.Name.IndexOf(TextToFilterCu, StringComparison.OrdinalIgnoreCase) >= 0;
            }
            return true;
        }
    }
}
