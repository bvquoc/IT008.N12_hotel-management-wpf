
using Hotel.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Hotel.ViewModel
{
    internal class LoginViewModel : BaseViewModel
    {
        public ICommand Login { get; set; }


        public LoginViewModel()
        {
            Login = new RelayCommand<Login>((parameter) => true, (parameter) => EnterLogin(parameter));
        }
        private void EnterLogin(Login parameter)
        {
            parameter.Hide();
            MainWindow mainWindow = new MainWindow();
            mainWindow.ShowDialog();
            parameter.Close();
            /// alo lao
        }
    }
}
