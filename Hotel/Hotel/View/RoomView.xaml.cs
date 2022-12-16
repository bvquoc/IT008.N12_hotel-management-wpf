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
            // trong xaml phần hiện thông tin phòng
            // để ItemsSource là Rooms
            // các binding là Name, Description, Status
        }     
    }
}
