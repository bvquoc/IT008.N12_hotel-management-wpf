using Hotel.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;
using Hotel.Model;

namespace Hotel.ViewModel
{
    internal class RoomVM : BaseViewModel
    {
        public int ID { get; set; }
        public int IDBook { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public int NumPeo { get; set; }
        public int Price { get; set; }
        public DateTime DateStart { get; set; }
        public DateTime DateEnd { get; set; }
        public RoomVM()
        {

        }
    }
}
