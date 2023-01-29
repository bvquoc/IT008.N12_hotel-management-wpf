using Hotel.Model;
using LiveCharts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.ViewModel
{
    internal class DashBoardViewModel : BaseViewModel
    {
        private ChartValues<double> chart;
        private ChartValues<double> chart2;
        public ChartValues<double> Charts
        {
            get { return chart; }
            set { chart = value; OnPropertyChanged(); }
        }

        public ChartValues<double> Chart2
        {
            get { return chart2; }
            set { chart2 = value; OnPropertyChanged(); }
        }
        private int revenue;
        public int Revenue
        {
            get { return revenue; }
            set { revenue = value; OnPropertyChanged(); }
        }
        private int numPeo;
        public int NumPeo
        {
            get { return numPeo; }
            set { numPeo = value; OnPropertyChanged(); }
        }
        private int numBill;
        public int NumBill
        {
            get { return numBill; }
            set { numBill = value; OnPropertyChanged(); }
        }
        private int salary;
        public int Salary
        {
            get { return salary; }
            set { salary = value; OnPropertyChanged(); }
        }
        public DashBoardViewModel()
        {
            Charts = new ChartValues<double> { 21, 12, 32, 23, 34, 43, 45, 54, 56, 65, 100, 18 };
            Chart2 = new ChartValues<double> { 12, 2, 53, 34, 56, 76, 78, 98, 90, 100, 2, 34 };
            LoadDB(DateTime.Now.Month);
        }
        private void LoadDB(int Month)
        {
            Revenue = 0;
            NumPeo = 0;
            NumBill = 0;
            Salary = 0;
            using (var db = new QLYHOTELEntities())
            {
                var bills = from i in db.DATs select i;
                foreach (var i in bills)
                {
                    if (i.NGAYTRA.Value.Month == Month && i.TRANGTHAI != "Đã đặt" && i.TRANGTHAI != "Đang sử dụng")
                    {
                        NumPeo += (int)i.SONG;
                        NumBill++;
                        Revenue += (int)i.THANHTIEN;
                    }
                }
                var staffs = from i in db.NHANVIENs select i;
                foreach (var i in staffs)
                    Salary += (int)i.LUONG * 30;
            }
            Revenue /= 1000000;
            Salary /= 1000000;
            Revenue -= Salary;
        }
    }
}
