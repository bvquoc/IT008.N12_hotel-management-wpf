using Hotel.Model;
using Hotel.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Hotel.ViewModel
{
    internal class ChangeInfoRoomViewModel : BaseViewModel
    {
        public ICommand Cancel { get; set; }
        public ICommand Save { get; set; }
        public ChangeInfoRoomViewModel()
        {
            Cancel = new RelayCommand<ChangeInfoRoom>((p) => true, (p) => cancel(p));
            Save = new RelayCommand<ChangeInfoRoom>((p) => true, (p) => save(p));
        }
        private void cancel(ChangeInfoRoom p)
        {
            p.Close();
        }
        private void save(ChangeInfoRoom p)
        {
            int id = Int32.Parse(p.ID.Text);
            try
            {
                if (p._Type.SelectedIndex == -1)
                    throw new Exception("Chưa chọn loại phòng!");
                if (p._Name.Text == "")
                    throw new Exception("Chưa nhập tên phòng!");
                if (p._Price.Text == "")
                    throw new Exception("Chưa nhập đơn giá!");
                using (var db = new QLYHOTELEntities())
                {
                    var room = (from i in db.PHONGs where i.MAPHONG == id select i).Single();
                    room.LOAIPHONG = p._Type.SelectionBoxItem.ToString();
                    room.TENPHONG = p._Name.Text;
                    room.DONGIA = Convert.ToInt32(p._Price.Text);
                    room.TRANGTHAI = "Trống";
                    db.SaveChanges();
                    new DialogCustomize("Lưu phòng thành công!").ShowDialog();
                    p.Close();
                }
            }
            catch (Exception ex)
            {
                new DialogCustomize(ex.Message).ShowDialog();
            }
        }
    }
}
