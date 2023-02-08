using System.Text.RegularExpressions;
using System.Windows.Controls;
using System.Windows.Input;

namespace Hotel.View
{
    /// <summary>
    /// Interaction logic for ReservationBookView.xaml
    /// </summary>
    public partial class ReservationBookView : UserControl
    {
        public ReservationBookView()
        {
            InitializeComponent();
        }

        private void PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-8]+");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}
