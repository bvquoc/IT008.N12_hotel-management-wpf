using Hotel.Model;
using Hotel.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
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
            using (var db = new QLYHOTELEntities())
            {
                var select = (from i in db.DATs where i.MADAT == bill.ID select i).Single();
                if (select.TRANGTHAI == "Đã hủy")
                    new DialogCustomize("Đơn đặt phòng đã bị hủy!").ShowDialog();
                else
                {
                    BillDetail detail = new BillDetail();
                    detail.ID.Text = bill.ID.ToString();
                    detail.Uid = "0";
                    detail.Show();
                }
            }
        }
        private bool FilterByName(object emp)
        {
            if (!string.IsNullOrEmpty(TextToFilterBill))
            {
                var empDetail = emp as BillVM;
                string ID = empDetail.ID.ToString();
                return empDetail != null && ID.IndexOf(TextToFilterBill, StringComparison.OrdinalIgnoreCase) >= 0;
            }
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
                    if (p.TRANGTHAI == "Đã thanh toán" || p.TRANGTHAI == "Đã hủy")
                        ListBill.Insert(0, (new BillVM() { ID = p.MADAT, RoomName = p.PHONG.TENPHONG, CustomerName = p.KHACH.TENKH, StaffName = p.NHANVIEN.TENNV, Status = p.TRANGTHAI, Total = (int)p.THANHTIEN, DateEnd = (DateTime)p.NGAYTRA }));
                }
            }
            ServiecCollection = CollectionViewSource.GetDefaultView(ListBill);
        }
    }
}
