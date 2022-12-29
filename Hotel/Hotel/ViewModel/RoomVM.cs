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
        public string Name { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public DateTime DateStart { get; set; }
        public DateTime DateEnd { get; set; }
        public ICommand ShowMessage { get; set; }
        public ICommand ChoseRoom { get; set; }
        public RoomVM()
        {
            ShowMessage = new RelayCommand<RoomView>((parameter) => true, (parameter) =>
            {
                MessageBox.Show(this.Name);
            });
            ChoseRoom = new RelayCommand<ReservationBookView>((p) => true, (p) => choseRoom(p));
        }
        private void choseRoom(ReservationBookView p)
        {

        }
        public RoomVM(string name, string description, string status, DateTime dateStart, DateTime dateEnd)
        {
            Name = name;
            Description = description;
            Status = status;
            DateStart = dateStart;
            DateEnd = dateEnd;
        }
    }
}
