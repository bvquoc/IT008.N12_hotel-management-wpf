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
    /// Interaction logic for DialogCustomize.xaml
    /// </summary>
    public partial class DialogCustomize : Window
    {
        public DialogCustomize()
        {
            InitializeComponent();
        }
        public DialogCustomize(string mess) : this()
        {
            try
            {
                txblMess.Text = mess;

            }
            catch (Exception ex)
            {

                Console.WriteLine("Lỗi DialogCustom :" + ex.Message);
            }

        }

        private void btnOK_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void Close(object sender, KeyEventArgs e)
        {
            this.Close();
        }
    }
}
