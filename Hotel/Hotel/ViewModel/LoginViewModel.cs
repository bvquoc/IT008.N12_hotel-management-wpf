
using Hotel.View;
using System.Windows.Input;

namespace Hotel.ViewModel
{
    internal class LoginViewModel : BaseViewModel
    {
        public ICommand Login { get; set; }


        public LoginViewModel()
        {
            Login = new RelayCommand<LoginView>((parameter) => true, (parameter) => EnterLogin(parameter));
        }
        private void EnterLogin(LoginView parameter)
        {
            parameter.Hide();
            MainWindow mainWindow = new MainWindow();
            mainWindow.ShowDialog();
            parameter.Close();
            /// alo lao
        }
    }
}
