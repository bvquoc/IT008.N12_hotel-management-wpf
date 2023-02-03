using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.ViewModel
{
    internal class BillVM
    {
        public int ID { get; set; }
        public string RoomName { get; set; }
        public string CustomerName { get; set; }
        public string StaffName { get; set; }
        public DateTime DateEnd { get; set; }
        public int Total { get; set; }
        public string Status { get; set; }
        public BillVM()
        {

        }
    }
}
