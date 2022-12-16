using System.Windows;
using System.Windows.Input;

namespace Hotel.View
{
    /// <summary>
    /// Interaction logic for AddEmployee.xaml
    /// </summary>
    public partial class AddEmployee : Window
    {
        public AddEmployee()
        {
            InitializeComponent();
        }

        private void ShowPass(object sender, MouseButtonEventArgs e)
        {
            passtxt.Text = _Password.Password;
            _Password.Visibility = Visibility.Collapsed;
            passtxt.Visibility = Visibility.Visible;
        }

        private void HidePass(object sender, MouseButtonEventArgs e)
        {
            _Password.Password = passtxt.Text;
            passtxt.Visibility = Visibility.Collapsed;
            _Password.Visibility = Visibility.Visible;
        }
    }
}
