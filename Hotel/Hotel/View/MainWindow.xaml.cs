using System.Windows;
using System.Windows.Input;

namespace Hotel.View
{
    /// <summary>
    /// Interaction logic for Menu.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public int MaNV { get; set; }
        public string TenNV { get; set; }
        public int LoaiNV { get; set; }
        public MainWindow()
        {
            InitializeComponent();
        }
        public MainWindow(int MaNV, string TenNV, int LoaiNV)
        {
            InitializeComponent();
            this.MaNV = MaNV;
            this.LoaiNV = LoaiNV;
            if (LoaiNV > 1)
            {
                this.menuEmployee.Visibility = Visibility.Collapsed;
                this.menuDashBoard.Visibility = Visibility.Collapsed;
                //...
            }
            _EID.Text = MaNV.ToString();
            _EName.Text = TenNV.ToString();
            LogoStaff.Uid = LoaiNV.ToString();
        }

        bool isMaximize = false;
        private void Border_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (e.ClickCount == 2)
            {
                if (isMaximize)
                {
                    this.WindowState = WindowState.Normal;
                    this.Width = 1200;
                    this.Height = 750;

                    isMaximize = false;
                }
                else
                {
                    this.WindowState = WindowState.Maximized;
                    isMaximize = true;
                }
            }
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }
        }

        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }
        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void btnMaximize_Click(object sender, RoutedEventArgs e)
        {
            if (isMaximize)
            {
                this.WindowState = WindowState.Normal;
                this.Width = 1200;
                this.Height = 750;

                isMaximize = false;
            }
            else
            {
                this.WindowState = WindowState.Maximized;
                isMaximize = true;
            }
        }
    }
}
