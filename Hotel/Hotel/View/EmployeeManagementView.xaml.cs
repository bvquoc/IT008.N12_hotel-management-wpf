using System.Windows;
using System.Windows.Controls;

namespace Hotel.View
{
    /// <summary>
    /// Interaction logic for EmployeeManagementView.xaml
    /// </summary>
    public partial class EmployeeManagementView : UserControl
    {
        public EmployeeManagementView()
        {
            InitializeComponent();
        }
        private void btnAddClick(object sender, RoutedEventArgs e)
        {
            AddEmployee add = new AddEmployee();
            add.ShowDialog();
        }
    }
}
