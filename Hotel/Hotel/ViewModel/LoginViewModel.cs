
using Hotel.Model;
using Hotel.View;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Windows;
using System.Linq;
using System.Windows.Data;
using System.Windows.Input;
using System;

namespace Hotel.ViewModel
{
    internal class LoginViewModel : BaseViewModel
    {
        private ObservableCollection<LoginVM> staffAcountList = new ObservableCollection<LoginVM>();
        public int MaNV { get; set; }
        public int LoaiNV { get; set; }
        public string TenNV { get; set; }
        public ICommand Login { get; set; }

        private bool handleLogin(string username, string password)
        {
            //MessageBox.Show(username + "\n" + password);
            foreach (var item in staffAcountList)
            {
                if (item.username == username && item.password == password)
                {
                    MaNV = item.MaNV;
                    LoaiNV = item.LoaiNV;
                    TenNV = item.TenNV;
                    //MessageBox.Show(LoaiNV.ToString());
                    return true;
                }
            }

            return false;
        }

        private void LoadDB()
        {
            try
            {
                using (var db = new QLYHOTELEntities())
                {
                    var select = from s in db.NHANVIENs select s;
                    foreach (var item in select)
                        staffAcountList.Add(new LoginVM(item.TAIKHOAN, item.MATKHAU, item.MANV, (int)item.LOAINV, item.TENNV));
                }
            }
            catch (Exception err)
            {
                new DialogCustomize("Mất kết nối cơ sở dữ liệu!\nError message: " + err.Message).ShowDialog();
            }
        }
        public LoginViewModel()
        {
            LoadDB();
            MaNV = -1;
            LoaiNV = -1;
            TenNV = "";
            Login = new RelayCommand<LoginView>((parameter) => true, (parameter) => EnterLogin(parameter));
        }
        private void EnterLogin(LoginView cur)
        {
            string username = cur.txtUser.Text;
            string password = cur.txtPass.Password.ToString();


            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                (new DialogCustomize("Vui lòng điền tên đăng nhập & mật khẩu!")).ShowDialog();
                return;
            }

            string EncryptPass = Encryption.Encrypt(password);
            if (!handleLogin(username, EncryptPass))
            {
                (new DialogCustomize("Sai thông tin đăng nhập!")).ShowDialog();
                return;
            }
            CheckIn(MaNV);
            MainWindow mainWindow = new MainWindow(MaNV, TenNV, LoaiNV);
            cur.Hide();
            mainWindow.Show();
            cur.Close();
        }
        private void CheckIn(int manv)
        {
            using (var db = new QLYHOTELEntities())
            {
                var nv = (from i in db.NHANVIENs where i.MANV == manv select i).Single();
                if (nv.CHECKIN == null || nv.CHECKIN.Value.Date != DateTime.Now.Date)
                {
                    nv.CHECKIN = DateTime.Now;
                    nv.SONGAYLV++;
                    db.SaveChanges();
                }
            }
        }
    }
}
