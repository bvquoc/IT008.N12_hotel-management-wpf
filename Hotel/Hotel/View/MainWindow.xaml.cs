using System.Windows;
using System.Windows.Input;

namespace Hotel.View
{
    /// <summary>
    /// Interaction logic for Menu.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        bool isMaximize = false;
        bool isClick = false;
        private void Border_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (e.ClickCount == 2)
            {
                if (isMaximize)
                {
                    this.WindowState = WindowState.Normal;
                    this.Width = 1100;
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
                this.Width = 1100;
                this.Height = 750;

                isMaximize = false;
            }
            else
            {
                this.WindowState = WindowState.Maximized;
                isMaximize = true;
            }
        }


        private void Phong_Click(object sender, MouseButtonEventArgs e)
        {
            if (!isClick)
            {
                Phong.IsActive = true;
                isClick = true;
            }
            else
            {
                Phong.IsActive = true;
                DatPhong.IsActive = false;
                QLyDV.IsActive = false;
                QlyKH.IsActive = false;
                QlyP.IsActive = false;
                HoaDon.IsActive = false;
            }
        }

        private void DatPhong_Click(object sender, MouseButtonEventArgs e)
        {
            if (!isClick)
            {
                DatPhong.IsActive = true;
                isClick = true;
            }
            else
            {
                DatPhong.IsActive = true;
                Phong.IsActive = false;
                QLyDV.IsActive = false;
                QlyKH.IsActive = false;
                QlyP.IsActive = false;
                HoaDon.IsActive = false;
            }
        }

        private void QlyKH_Click(object sender, MouseButtonEventArgs e)
        {
            if (!isClick)
            {
                QlyKH.IsActive = true;
                isClick = true;
            }
            else
            {
                QlyKH.IsActive = true;
                DatPhong.IsActive = false;
                QLyDV.IsActive = false;
                Phong.IsActive = false;
                QlyP.IsActive = false;
                HoaDon.IsActive = false;
            }
        }

        private void QlyP_Click(object sender, MouseButtonEventArgs e)
        {
            if (!isClick)
            {
                QlyP.IsActive = true;
                isClick = true;
            }
            else
            {
                QlyP.IsActive = true;
                DatPhong.IsActive = false;
                QLyDV.IsActive = false;
                QlyKH.IsActive = false;
                Phong.IsActive = false;
                HoaDon.IsActive = false;
            }
        }

        private void HoaDon_Click(object sender, MouseButtonEventArgs e)
        {
            if (!isClick)
            {
                HoaDon.IsActive = true;
                isClick = true;
            }
            else
            {
                HoaDon.IsActive = true;
                DatPhong.IsActive = false;
                QLyDV.IsActive = false;
                QlyKH.IsActive = false;
                QlyP.IsActive = false;
                Phong.IsActive = false;
            }
        }

        private void QlyDV_Click(object sender, MouseButtonEventArgs e)
        {
            if (!isClick)
            {
                QLyDV.IsActive = true;
                isClick = true;
            }
            else
            {
                QLyDV.IsActive = true;
                DatPhong.IsActive = false;
                Phong.IsActive = false;
                QlyKH.IsActive = false;
                QlyP.IsActive = false;
                HoaDon.IsActive = false;
            }
        }
        private void Phong_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                MessageBox.Show("Clicked!");
            }
        }
    }
}
