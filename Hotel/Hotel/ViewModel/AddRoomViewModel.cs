using Hotel.Model;
using Hotel.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace Hotel.ViewModel
{
    internal class AddRoomViewModel
    {
        public ICommand Save { get; set; }
        public ICommand Close { get; set; }
        public AddRoomViewModel()
        {
            Save = new RelayCommand<AddRoom>((p) => true, (p) => save(p));
            Close = new RelayCommand<AddRoom>((p) => true, (p) => close(p));
        }
        private void save(AddRoom p)
        {
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
                    var select = from s in db.PHONGs select s;
                    foreach (var r in select)
                    {
                        if (r.TENPHONG == p._Name.Text)
                            throw new Exception("Tên phòng đã có sẵn!");
                    }
                    PHONG room = new PHONG();
                    room.LOAIPHONG = p._Type.SelectionBoxItem.ToString();
                    room.TENPHONG = p._Name.Text;
                    room.DONGIA = Convert.ToInt32(p._Price.Text);
                    room.TRANGTHAI = "Trống";
                    db.PHONGs.Add(room);
                    db.SaveChanges();
                    new DialogCustomize("Thêm phòng thành công!").ShowDialog();
                    p.Close();
                    new AddRoom().ShowDialog();
                }
            }
            catch (Exception ex)
            {
                new DialogCustomize(ex.Message).ShowDialog();
            }
        }
        private void close(AddRoom p)
        {
            p.Close();
        }
    }
}
