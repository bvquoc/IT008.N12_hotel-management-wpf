using LiveCharts;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Hotel.View
{
    /// <summary>
    /// Interaction logic for DashBoardView.xaml
    /// </summary>
    public partial class DashBoardView : UserControl
    {
        public DashBoardView()
        {
            InitializeComponent();
            Values1 = new ChartValues<double> { 21, 12, 32, 23, 34, 43, 45, 54, 56, 65, 100, 18 };
            Values1.Add(0);
            DataContext = this;
        }
        public ChartValues<double> Values1 { get; set; }

    }
}
