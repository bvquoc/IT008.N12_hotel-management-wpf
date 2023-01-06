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
    internal class EmployeeViewModel : BaseViewModel
    {
        private ObservableCollection<EmployeeVM> _EmployeeList;
        public ObservableCollection<EmployeeVM> EmployeeList
        {
            get { return _EmployeeList; }
            set { _EmployeeList = value; OnPropertyChanged(); }
        }
        private string _textToFilterE;

        public string TextToFilterE
        {
            get { return _textToFilterE; }
            set
            {
                _textToFilterE = value;
                OnPropertyChanged();
                EmployeeCollection.Filter = FilterByName;
            }
        }
        private ICollectionView _employeeCollection;

        public ICollectionView EmployeeCollection
        {
            get { return _employeeCollection; }
            set { _employeeCollection = value; OnPropertyChanged(); }
        }
        public EmployeeViewModel()
        {
            LoadAllSV();
        }
        private bool FilterByName(object emp)
        {
            if (!string.IsNullOrEmpty(TextToFilterE))
            {
                var empDetail = emp as EmployeeVM;
                return empDetail != null && empDetail.Name.IndexOf(TextToFilterE, StringComparison.OrdinalIgnoreCase) >= 0;
            }
            return true;
        }
        public void LoadAllSV()
        {
            if (EmployeeList != null)
                EmployeeList.Clear();
            else
                EmployeeList = new ObservableCollection<EmployeeVM>();
            using (var db = new QLYHOTELEntities())
            {
                var select = from s in db.NHANVIENs select s;
                foreach (var Employee in select)
                    EmployeeList.Add(new EmployeeVM() { ID = Employee.MANV.ToString(), Name = Employee.TENNV.ToString(), Salary = Employee.LUONG.Value, User = Employee.TAIKHOAN.ToString(), Pass = Employee.MATKHAU.ToString(), Type = Employee.LOAINV.ToString() });
            }
            EmployeeCollection = CollectionViewSource.GetDefaultView(EmployeeList);
        }

    }

}
