using Hotel.ViewModel;
using System.Collections.Generic;
using System.Windows.Controls;

namespace Hotel.View
{
    /// <summary>
    /// Interaction logic for RoomView.xaml
    /// </summary>
    public partial class RoomView : UserControl
    {
        public RoomView()
        {
            InitializeComponent();

            DataContext = new RoomListViewModel();
        }     
    }
}
