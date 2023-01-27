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
        public ICommand LoadIdRe { get; set; }
        public ICommand SaveStatus { get; set; }
        public RoomDetailViewModel()
        {
            DoSomeThing = new RelayCommand<RoomDetail>((p) => true, (p) => MakeSome(p));
            BookService = new RelayCommand<RoomDetail>((p) => true, (p) => MakeService(p));
            LoadIdRe = new RelayCommand<RoomDetail>((p) => true, (p) => Loaded(p));
            SaveStatus = new RelayCommand<RoomDetail>((p) => true, (p) => savedb(p));
        }
        private void Loaded(RoomDetail p)
        {
            id = Convert.ToInt32(p.idbook.Text);
            if (p.btnAccept.Content == "Nhận phòng")
                p.btnBookServiece.Visibility = Visibility.Collapsed;
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
                    if (p.MADAT == id)
                        ListDV.Add(new ServiceVM() { ID = p.MADV.ToString(), Name = p.DICHVU.TENDV, NumSer = Convert.ToInt32(p.SOLUONG), Price = Convert.ToInt32(p.TONGTIEN), Total = Convert.ToInt32(p.TONGTIEN) });
                }
            }
        }
        private void MakeService(RoomDetail p)
        {
            BookService book = new BookService();
            book.idbook.Text = p.idbook.Text;
            book.Uid = p.Uid;
            //p.Hide();
            book.ShowDialog();
            //p.ShowDialog();
            loadDb();
        }
        public void MakeSome(RoomDetail p)
        {
            string NameStaff;
            int idStaff = Convert.ToInt32(p.Uid);
            using (var db = new QLYHOTELEntities())
            {
                var select = (from i in db.DATs where i.MADAT == id select i).Single();
                if (p.btnAccept.Content == "Nhận phòng")
                {
                    select.TRANGTHAI = "Đang sử dụng";
                    p.btnBookServiece.Visibility = Visibility.Visible;
                }
                else
                {
                    select.TRANGTHAI = "Đã thanh toán";
                }
                db.SaveChanges();

                //get name staff
                var staff = (from i in db.NHANVIENs where i.MANV == idStaff select i).Single();
                NameStaff = staff.TENNV;
            }
            p.btnAccept.Content = p.btnAccept.Content == "Thanh toán" ? "Nhận phòng" : "Thanh toán";
            if (p.btnAccept.Content == "Nhận phòng")
            {
                p.Hide();
                BillDetail billDetail = new BillDetail();
                billDetail.Uid = p.Uid; //id staff
                billDetail.txbNhanvien.Text = NameStaff + " #" + p.Uid;
                billDetail.ID.Text = id.ToString(); // id book
                billDetail.Show();
                p.Close();
            }
        }
        private void savedb(RoomDetail p)
        {
            int idRoom = Convert.ToInt32(p.Uid);
            using (var db = new QLYHOTELEntities())
            {
                var select = (from i in db.PHONGs where i.MAPHONG == idRoom select i).Single();
                select.TRANGTHAI = p.cbTrangthai.SelectionBoxItem.ToString();
                db.SaveChanges();
            }
            p.Close();
        }
    }
}
