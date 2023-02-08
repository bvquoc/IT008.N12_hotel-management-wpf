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
        private EmployeeVM _selectItem;
        public EmployeeVM selectItem
        {
            get => _selectItem;
            set { _selectItem = value; OnPropertyChanged(); ViewDetail(); }
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
        public ICommand AddEmployee { get; set; }
        public EmployeeViewModel()
        {
            AddEmployee = new RelayCommand<object>((p) => true, (p) => OpenAddEmployee());
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
        private void OpenAddEmployee()
        {
            new AddEmployee().ShowDialog();
            LoadAllSV();
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
                    EmployeeList.Add(new EmployeeVM(Employee.MANV.ToString(), Employee.TENNV.ToString(), Employee.TAIKHOAN.ToString(), Employee.MATKHAU.ToString(), (int)Employee.LUONG, (int)Employee.LOAINV));
            }
            EmployeeCollection = CollectionViewSource.GetDefaultView(EmployeeList);
        }
        public void ViewDetail()
        {
            if (selectItem == null) return;
            EmployeeDetail detail = new EmployeeDetail();
            int id = Convert.ToInt32(selectItem.ID);
            using (var db = new QLYHOTELEntities())
            {
                var select = (from i in db.NHANVIENs where i.MANV == id select i).Single();
                detail._ID.Text = id.ToString();
                detail._Name.Text = select.TENNV;
                detail._CCCD.Text = select.CCCD;
                detail._BirthDay.SelectedDate = select.NGSINH.Value;
                detail.cbType.SelectedIndex = Convert.ToInt32(select.LOAINV) - 1;
                detail._SDT.Text = select.SDT;
                detail._Salary.Text = select.LUONG.ToString();
                detail._Account.Text = select.TAIKHOAN;
            }
            detail.ShowDialog();
            LoadAllSV();
        }
    }

}
