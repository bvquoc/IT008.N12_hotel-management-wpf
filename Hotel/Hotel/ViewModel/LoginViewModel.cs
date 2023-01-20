
using Hotel.Model;
using Hotel.View;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Windows;
using System.Linq;
using System.Windows.Data;
using System.Windows.Input;

namespace Hotel.ViewModel
{
    internal class LoginViewModel : BaseViewModel
    {
        public int MaNV { get; set; }
        public ICommand Login { get; set; }

        private bool handleLogin(string username, string password)
        {
            //MessageBox.Show(username + "\n" + password);

            ObservableCollection<LoginVM> staffAcountList = new ObservableCollection<LoginVM>();
            using (var db = new QLYHOTELEntities())
            {
                var select = from s in db.NHANVIENs select s;
                foreach (var item in select)
                    staffAcountList.Add(new LoginVM(item.TAIKHOAN, item.MATKHAU, item.MANV));
            }

            foreach (var item in staffAcountList)
            {
                if (item.username == username && item.password == password)
                {
                    MaNV = item.MaNV;
                    //MessageBox.Show(MaNV.ToString());
                    return true;
                }
            }

            return false;
        }


        public LoginViewModel()
        {
            MaNV = -1;
            Login = new RelayCommand<LoginView>((parameter) => true, (parameter) => EnterLogin(parameter));
        }
        private void EnterLogin(LoginView cur)
        {
            string username = cur.txtUser.Text;
            string password = cur.txtPass.Password.ToString();


            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password)) {
                (new DialogCustomize("Vui lòng điền tên đăng nhập & mật khẩu!")).ShowDialog();
                return;
            }


            if (!handleLogin(username, password))
            {
                DialogCustomize tmp = new DialogCustomize("Sai thông tin đăng nhập!");
                tmp.ShowDialog();
                return;
            }

            MainWindow mainWindow = new MainWindow(MaNV);
            cur.Hide();
            mainWindow.Show();
            cur.Close();
        }

    }
}
