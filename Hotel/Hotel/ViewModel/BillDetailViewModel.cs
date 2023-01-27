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


            using (var db = new QLYHOTELEntities())
            {
                var select = (from i in db.DATs where i.MADAT == idbook select i).Single();
                if (p.txbNhanvien.Text == "")
                    p.txbNhanvien.Text = select.NHANVIEN.TENNV + " #" + select.MANV.ToString();

                ListSVbook.Add(new ServiceVM() { Name = "Thịt chó", Price = 90000, NumSer = 3, Total = 210000 });
                ListSVbook.Add(new ServiceVM() { Name = "Thịt chó", Price = 90000, NumSer = 3, Total = 210000 });
                ListSVbook.Add(new ServiceVM() { Name = "Thịt chó", Price = 90000, NumSer = 3, Total = 210000 });
                ListSVbook.Add(new ServiceVM() { Name = "Thịt chó", Price = 90000, NumSer = 3, Total = 210000 });
                ListSVbook.Add(new ServiceVM() { Name = "Thịt chó", Price = 90000, NumSer = 3, Total = 210000 });
            }
        }
    }
}
