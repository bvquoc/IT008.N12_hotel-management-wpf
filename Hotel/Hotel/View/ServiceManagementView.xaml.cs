using System.Windows.Controls;

namespace Hotel.View
{
    /// <summary>
    /// Interaction logic for ServiceManagementView.xaml
    /// </summary>
    public partial class ServiceManagementView : UserControl
    {
        public ServiceManagementView()
        {
            InitializeComponent();
        }

        private void btnAddServiceClick(object sender, System.Windows.RoutedEventArgs e)
        {
            AddService adds=new AddService();
            adds.ShowDialog();
        }
    }
}
