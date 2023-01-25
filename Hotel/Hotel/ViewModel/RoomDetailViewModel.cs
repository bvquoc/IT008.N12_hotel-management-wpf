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
        private ObservableCollection<dv> _listdv;
        public int id;
        public ObservableCollection<dv> ListDV
        {
            get { return _listdv; }
            set { _listdv = value; OnPropertyChanged(); }
        }
        public ICommand DoSomeThing { get; set; }
        public RoomDetailViewModel()
        {
            DoSomeThing = new RelayCommand<RoomDetail>((p) => true, (p) => MakeSome(p));

            ListDV = new ObservableCollection<dv>();
            ListDV.Add(new dv() { Name = ".....", SoLuong = 2, ThanhTien = 1000000 });
            ListDV.Add(new dv() { Name = ".....", SoLuong = 2, ThanhTien = 1000000 });
            ListDV.Add(new dv() { Name = ".....", SoLuong = 2, ThanhTien = 1000000 });
            ListDV.Add(new dv() { Name = ".....", SoLuong = 2, ThanhTien = 1000000 });
            ListDV.Add(new dv() { Name = ".....", SoLuong = 2, ThanhTien = 1000000 });
            ListDV.Add(new dv() { Name = ".....", SoLuong = 2, ThanhTien = 1000000 });
            ListDV.Add(new dv() { Name = ".....", SoLuong = 2, ThanhTien = 1000000 });
            ListDV.Add(new dv() { Name = ".....", SoLuong = 2, ThanhTien = 1000000 });
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
                    select.THANHTIEN = select.PHONG.DONGIA + ListDV.Sum(i => i.ThanhTien);
                }
                db.SaveChanges();
            }

            p.btnAccept.Content = p.btnAccept.Content == "Thanh toán" ? "Nhận phòng" : "Thanh toán";
            if (p.btnAccept.Content == "Nhận phòng")
                p.Close();
        }
    }
    public class dv
    {
        public string Name { get; set; }
        public int SoLuong { get; set; }
        public int ThanhTien { get; set; }
        public dv()
        {

        }
    }
}
