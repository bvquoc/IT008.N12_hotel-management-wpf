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
        private ChartValues<double> charttol;
        private ChartValues<double> chartser;
        public ChartValues<double> ChartTol
        {
            get { return charttol; }
            set { charttol = value; OnPropertyChanged(); }
        }

        public ChartValues<double> ChartSer
        {
            get { return chartser; }
            set { chartser = value; OnPropertyChanged(); }
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
            ChartTol = new ChartValues<double>();
            ChartSer = new ChartValues<double>();
            LoadDB(DateTime.Now.Month);
            LoadChart();
        }
        private void LoadChart()
        {
            for (int i = 1; i <= 12; i++)
            {
                int TotalMoney = 0;
                int TotalService = 0;
                using (var db = new QLYHOTELEntities())
                {
                    var bills = from u in db.DATs select u;
                    foreach (var u in bills)
                    {
                        if (u.NGAYTRA.Value.Month == i && u.TRANGTHAI != "Đã đặt" && u.TRANGTHAI != "Đang sử dụng")
                        {
                            TotalMoney += (int)u.THANHTIEN;
                            if (u.TRANGTHAI != "Đã hủy")
                                TotalService += ((int)u.THANHTIEN - (Convert.ToInt32((u.NGAYTRA.Value - u.NGAYDAT.Value).TotalHours) * (int)u.PHONG.DONGIA));
                        }
                    }


                    TotalMoney /= 1000000;
                    TotalService /= 1000000;
                }
                ChartTol.Add(TotalMoney);
                //if (i == 1)
                //    ChartSer.Add(TotalService + 33);
                //else
                ChartSer.Add(TotalService);
            }
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
        }
    }
}
