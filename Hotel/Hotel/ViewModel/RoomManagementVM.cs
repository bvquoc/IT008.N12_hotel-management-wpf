using Hotel.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;

namespace Hotel.ViewModel
{
    internal class RoomManagementVM : BaseViewModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Status { get; set; }
        public int Price { get; set; }
        public string Type { get; set; }
        public RoomManagementVM()
        {
        }
    }
}
