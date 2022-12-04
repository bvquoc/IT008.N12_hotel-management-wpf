using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

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
            _Password.Password=passtxt.Text;
            passtxt.Visibility=Visibility.Collapsed;
            _Password.Visibility=Visibility.Visible;
        }
    }
}
