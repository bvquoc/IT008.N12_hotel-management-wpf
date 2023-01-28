using Hotel.Model;
using Hotel.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Hotel.ViewModel
{
    internal class BillDetailViewModel : BaseViewModel
    {
        private int idnv;
        private int idbook;
        private ObservableCollection<ServiceVM> listSVbook;

        private int totalMoney;
        public int TotalMoney
        {
            get { return totalMoney; }
            set { totalMoney = value; OnPropertyChanged(); }
        }
        private int deposits;
        public int Deposits
        {
            get { return deposits; }
            set { deposits = value; OnPropertyChanged(); }
        }
        private int moneyPaid;
        public int MoneyPaid
        {
            get { return moneyPaid; }
            set { moneyPaid = value; OnPropertyChanged(); }
        }
        public ObservableCollection<ServiceVM> ListSVbook
        {
            get { return listSVbook; }
            set { listSVbook = value; OnPropertyChanged(); }
        }

        public ICommand LoadIdStaff { get; set; }
        public BillDetailViewModel()
        {
            LoadIdStaff = new RelayCommand<BillDetail>((p) => true, (p) => loadedID(p));
        }
        private void loadedID(BillDetail p)
        {
            ListSVbook = new ObservableCollection<ServiceVM>();
            if (p.Uid != "0")
                idnv = Convert.ToInt32(p.Uid);

            idbook = Convert.ToInt32(p.ID.Text);

            int Tongtien = 0;
            int RoomMoney = 0;
            using (var db = new QLYHOTELEntities())
            {
                var select = (from i in db.DATs where i.MADAT == idbook select i).Single();
                if (p.txbNhanvien.Text == "")
                    p.txbNhanvien.Text = select.NHANVIEN.TENNV + " #" + select.MANV.ToString();
                foreach (var item in select.CUNGCAPs)
                {
                    ListSVbook.Add(new ServiceVM() { Name = item.DICHVU.TENDV, Price = (int)item.DICHVU.DONGIA, NumSer = (int)item.SOLUONG, Total = (int)item.TONGTIEN });
                    Tongtien += (int)item.TONGTIEN;
                }
                int NumTime = Convert.ToInt32((select.NGAYTRA.Value - select.NGAYDAT.Value).TotalHours);
                RoomMoney = NumTime * select.PHONG.DONGIA.Value;
                Tongtien += RoomMoney;
                ListSVbook.Add(new ServiceVM() { Name = "Tiền phòng", Price = (int)select.PHONG.DONGIA, NumSer = 1, Total = RoomMoney });
                select.THANHTIEN = Tongtien;
                db.SaveChanges();
                p._date.Text = select.NGAYTRA.Value.ToShortDateString();
            }
            TotalMoney = Tongtien;
            Deposits = -RoomMoney / 2;
            MoneyPaid = Tongtien - (RoomMoney / 2);
        }
    }
}
