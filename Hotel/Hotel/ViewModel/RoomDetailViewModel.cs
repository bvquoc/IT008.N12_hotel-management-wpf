using Hotel.Model;
using Hotel.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity.Core.Metadata.Edm;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows;
using System.Windows.Input;

namespace Hotel.ViewModel
{
    internal class RoomDetailViewModel : BaseViewModel
    {
        private ObservableCollection<ServiceVM> _listdv;
        public int id;
        public ObservableCollection<ServiceVM> ListDV
        {
            get { return _listdv; }
            set { _listdv = value; OnPropertyChanged(); }
        }
        public ICommand DoSomeThing { get; set; }
        public ICommand BookService { get; set; }
        public RoomDetailViewModel()
        {
            DoSomeThing = new RelayCommand<RoomDetail>((p) => true, (p) => MakeSome(p));
            BookService = new RelayCommand<RoomDetail>((p) => true, (p) => MakeService(p));
            loadDb();
        }
        private void loadDb()
        {
            ListDV = new ObservableCollection<ServiceVM>();
            using (var db = new QLYHOTELEntities())
            {
                var select = from s in db.CUNGCAPs select s;
                foreach (var p in select)
                {
                    ListDV.Add(new ServiceVM() { ID = p.MADV.ToString(), Name = p.DICHVU.TENDV, NumSer = Convert.ToInt32(p.SOLUONG), Price = Convert.ToInt32(p.TONGTIEN), Total = Convert.ToInt32(p.TONGTIEN) });
                }
            }
        }
        private void MakeService(RoomDetail p)
        {
            BookService book = new BookService();
            book.idbook.Text = p.idbook.Text;
            //p.Hide();
            book.ShowDialog();
            //p.ShowDialog();
            loadDb();
        }
        public void MakeSome(RoomDetail p)
        {

            id = Int32.Parse(p.idbook.Text);
            using (var db = new QLYHOTELEntities())
            {
                var select = (from i in db.DATs where i.MADAT == id select i).Single();
                if (p.btnAccept.Content == "Nhận phòng")
                {
                    select.TRANGTHAI = "Đang sử dụng";
                }
                else
                {
                    select.TRANGTHAI = "Đã thanh toán";
                    select.THANHTIEN = select.PHONG.DONGIA + ListDV.Sum(i => i.Total);
                }
                db.SaveChanges();
            }

            p.btnAccept.Content = p.btnAccept.Content == "Thanh toán" ? "Nhận phòng" : "Thanh toán";
            if (p.btnAccept.Content == "Nhận phòng")
                p.Close();
        }
    }
}
