using Hotel.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Hotel.ViewModel
{
    internal class BillViewModel : BaseViewModel
    {
        private ObservableCollection<BillVM> listBill;

        public ObservableCollection<BillVM> ListBill
        {
            get { return listBill; }
            set { listBill = value; OnPropertyChanged(); }
        }
        private string _textToFilterBill;

        public string TextToFilterBill
        {
            get { return _textToFilterBill; }
            set
            {
                _textToFilterBill = value;
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
        public ICommand choseBill { get; set; }
        public BillViewModel()
        {
            choseBill = new RelayCommand<object>((p) => true, p => ViewDetailBill(p));
            loadDbBill();
        }
        private void ViewDetailBill(object p)
        {
            BillVM bill = (BillVM)p;
        }
        private bool FilterByName(object emp)
        {
            //if (!string.IsNullOrEmpty(TextToFilterBill))
            //{
            //    var empDetail = emp as BillVM;
            //    return empDetail != null && empDetail.ID.IndexOf(TextToFilterBill, StringComparison.OrdinalIgnoreCase) >= 0;
            //}
            return true;
        }
        private void loadDbBill()
        {
            ListBill = new ObservableCollection<BillVM>();
            using (var db = new QLYHOTELEntities())
            {
                var select = from s in db.DATs select s;
                foreach (var p in select)
                {
                    if (p.TRANGTHAI == "Đã thanh toán")
                        ListBill.Add(new BillVM() { ID = p.MADAT, RoomName = p.PHONG.TENPHONG, CustomerName = p.KHACH.TENKH, StaffName = p.NHANVIEN.TENNV, Status = p.TRANGTHAI, Total = (int)p.THANHTIEN, DateEnd = (DateTime)p.NGAYTRA });
                }
            }
        }
    }
}
