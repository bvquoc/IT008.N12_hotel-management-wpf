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
    internal class EmployeeDetailViewModel : BaseViewModel
    {
        private int totalSalary;

        public int TotalSalary
        {
            get { return totalSalary; }
            set { totalSalary = value; OnPropertyChanged(); }
        }
        public ICommand LoadedSalary { get; set; }
        public ICommand Pay { get; set; }
        public ICommand Cancel { get; set; }
        public ICommand Save { get; set; }
        public ICommand Delete { get; set; }

        public EmployeeDetailViewModel()
        {
            LoadedSalary = new RelayCommand<EmployeeDetail>((p) => true, (p) => loadedSalary(p));
            Pay = new RelayCommand<EmployeeDetail>((p) => true, (p) => pay(p));
            Cancel = new RelayCommand<EmployeeDetail>((p) => true, (p) => cancel(p));
            Save = new RelayCommand<EmployeeDetail>((p) => true, (p) => save(p));
            Delete = new RelayCommand<EmployeeDetail>((p) => true, (p) => delete(p));
        }
        public void loadedSalary(EmployeeDetail p)
        {
            int id = Convert.ToInt32(p._ID.Text);
            using (var db = new QLYHOTELEntities())
            {
                var select = (from i in db.NHANVIENs where i.MANV == id select i).Single();
                TotalSalary = Convert.ToInt32(select.SONGAYLV) * Convert.ToInt32(select.LUONG);
            }
        }
        public void pay(EmployeeDetail p)
        {
            new DialogCustomize("Đã thanh toán lương").ShowDialog();
            int id = Convert.ToInt32(p._ID.Text);
            using (var db = new QLYHOTELEntities())
            {
                var select = (from i in db.NHANVIENs where i.MANV == id select i).Single();
                TotalSalary = 0;
                select.SONGAYLV = 0;
                db.SaveChanges();
            }
        }
        public void cancel(EmployeeDetail p)
        {
            p.Close();
        }
        public void save(EmployeeDetail p)
        {
            int id = Convert.ToInt32(p._ID.Text);
            try
            {
                if (p._Name.Text == "")
                    throw new Exception("Chưa nhập tên!");
                if (p._CCCD.Text == "")
                    throw new Exception("Chưa nhập CMND/CCCD!");
                if (checkCMND(p._CCCD.Text))
                    throw new Exception("CMND/CCCD không hợp lệ!");
                if (p._BirthDay.SelectedDate == null || DateTime.Compare(p._BirthDay.SelectedDate.Value, DateTime.Now) > 0)
                    throw new Exception("Ngày sinh không hợp lệ!");
                if (p._SDT.Text == "")
                    throw new Exception("Chưa nhập số điện thoại!");
                if (checkSDT(p._SDT.Text))
                    throw new Exception("Số điện thoại không hợp lệ!");
                if (p._Account.Text == "")
                    throw new Exception("Chưa nhập tài khoản!");
                if (checkAccount(id, p._Account.Text))
                    throw new Exception("Tài khoản đã tồn tại!");
                if (p.passtxt.Text == "")
                    throw new Exception("Chưa nhập mật khẩu!");
                using (var db = new QLYHOTELEntities())
                {
                    var select = (from i in db.NHANVIENs where i.MANV == id select i).Single();
                    select.TENNV = p._Name.Text;
                    select.CCCD = p._CCCD.Text;
                    select.NGSINH = p._BirthDay.SelectedDate.Value;
                    select.SDT = p._SDT.Text;
                    select.LUONG = Convert.ToInt32(p._Salary.Text);
                    select.TAIKHOAN = p._Account.Text;
                    if (p.passtxt.Text != "")
                        select.MATKHAU = Encryption.Encrypt(p.passtxt.Text);
                    string LoaiNv = p.cbType.SelectionBoxItem.ToString();
                    switch (LoaiNv)
                    {
                        case "Quản lý":
                            select.LOAINV = 1;
                            break;
                        case "Nhân viên":
                            select.LOAINV = 2;
                            break;
                        default:
                            break;
                    }
                    db.SaveChanges();
                }
                new DialogCustomize("Lưu thành công!").ShowDialog();
                cancel(p);
            }
            catch (Exception ex)
            {
                new DialogCustomize(ex.Message).ShowDialog();
            }
        }
        private bool checkAccount(int id, string account)
        {
            using (var db = new QLYHOTELEntities())
            {
                var check = from n in db.NHANVIENs select n;
                foreach (var p in check)
                    if (p.TAIKHOAN == account && p.MANV != id)
                        return true;
            }
            return false;
        }
        private bool checkCMND(string cmnd)
        {
            if (cmnd.Length == 9 || cmnd.Length == 12)
                return false;
            return true;
        }
        private bool checkSDT(string number)
        {
            return !(number.Length >= 9 && number.Length <= 12);
        }
        public void delete(EmployeeDetail p)
        {
            int id = Convert.ToInt32(p._ID.Text);
            using (var db = new QLYHOTELEntities())
            {
                var delete = (from d in db.NHANVIENs where d.MANV == id select d).Single();
                db.NHANVIENs.Remove(delete);
                db.SaveChanges();
            }
            new DialogCustomize("Xóa thành công!").ShowDialog();
            cancel(p);
        }
    }
}
