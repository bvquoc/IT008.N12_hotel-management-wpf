using Hotel.Model;
using Hotel.View;
using System;
using System.Windows;
using System.Windows.Input;
using System.Linq;
using System.Text.RegularExpressions;

namespace Hotel.ViewModel
{
    internal class AddEmployeeViewModel : BaseViewModel
    {
        public ICommand CloseCommand { get; set; }
        public ICommand SaveCustomerCommand { get; set; }
        public AddEmployeeViewModel()
        {
            CloseCommand = new RelayCommand<Window>((parameter) => true, (parameter) => parameter.Close());
            SaveCustomerCommand = new RelayCommand<AddEmployee>((parameter) => true, (parameter) => saveCustomer(parameter));
        }
        private void saveCustomer(AddEmployee p)
        {
            try
            {
                var employee = new NHANVIEN();
                if (p._Name.Text == "")
                    throw new Exception("Chưa nhập tên!");
                employee.TENNV = p._Name.Text;

                if (p._CCCD.Text == "")
                    throw new Exception("Chưa nhập CMND/CCCD!");
                if (checkCMND(p._CCCD.Text))
                    throw new Exception("CMND/CCCD không hợp lệ!");
                employee.CCCD = p._CCCD.Text;

                if (p._BirthDay.SelectedDate == null || DateTime.Compare(p._BirthDay.SelectedDate.Value, DateTime.Now) > 0)
                    throw new Exception("Ngày sinh không hợp lệ!");
                employee.NGSINH = p._BirthDay.SelectedDate.Value;

                if (p._SDT.Text == "")
                    throw new Exception("Chưa nhập số điện thoại!");
                if (checkSDT(p._SDT.Text))
                    throw new Exception("Số điện thoại không hợp lệ!");
                employee.SDT = p._SDT.Text;

                if (p._Account.Text == "")
                    throw new Exception("Chưa nhập tài khoản!");
                if (checkAccount(p._Account.Text))
                    throw new Exception("Tài khoản đã tồn tại!");
                employee.TAIKHOAN = p._Account.Text;

                if (p._Password.Password == "")
                    throw new Exception("Chưa nhập mật khẩu!");
                if (p._Salary.Text == "")
                    throw new Exception("Chưa nhập lương!");
                employee.MATKHAU = Encryption.Encrypt(p._Password.Password);

                string LoaiNv = p.cbType.SelectionBoxItem.ToString();
                switch (LoaiNv)
                {
                    case "Quản lý":
                        employee.LOAINV = 1;
                        break;
                    case "Nhân viên":
                        employee.LOAINV = 2;
                        break;
                    default:
                        throw new Exception("Chức vụ không hợp lê!");
                        break;
                }
                employee.SONGAYLV = 0;
                employee.LUONG = Convert.ToInt32(p._Salary.Text);
                using (var db = new QLYHOTELEntities())
                {
                    db.NHANVIENs.Add(employee);
                    db.SaveChanges();
                }
                //System.Threading.Thread.Sleep(2000);
                new DialogCustomize("Thêm thành công!").ShowDialog();
                //Refresh
                Refresh(p);
            }
            catch (Exception ex)
            {
                new DialogCustomize(ex.Message).ShowDialog();
            }
        }
        private bool checkAccount(string account)
        {
            using (var db = new QLYHOTELEntities())
            {
                var check = from n in db.NHANVIENs select n;
                foreach (var p in check)
                    if (p.TAIKHOAN == account)
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
        private void Refresh(AddEmployee p)
        {
            p._Name.Text = "";
            p._CCCD.Text = "";
            p._BirthDay.Text = "";
            p.cbType.SelectedIndex = -1;
            p._SDT.Text = "";
            p._Account.Text = "";
            p._Password.Password = "";
            p._Salary.Text = "";
        }
    }
}
