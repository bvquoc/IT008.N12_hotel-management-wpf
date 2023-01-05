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
        public string Name { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public int NumPeo { get; set; }
        public DateTime DateStart { get; set; }
        public DateTime DateEnd { get; set; }
        public RoomVM()
        {

        }
        private void choseRoom(ReservationBookView p)
        {
            p.tpGioBD.Text = "asdj";
        }
        public RoomVM(string name, string description, string status, DateTime dateStart, DateTime dateEnd, int numPeo, int iD)
        {
            Name = name;
            Description = description;
            Status = status;
            DateStart = dateStart;
            DateEnd = dateEnd;
            NumPeo = numPeo;
            ID = iD;
        }
    }
}
