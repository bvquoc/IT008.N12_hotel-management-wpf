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
        public string ID { get; set; }
        public string Status { get; set; }
        public int Price { get; set; }
        public string Type { get; set; }
        public ICommand ShowMessage { get; set; }
        public RoomManagementVM()
        {
            ShowMessage = new RelayCommand<RoomView>((parameter) => true, (parameter) =>
            {
                MessageBox.Show(this.ID);
            });
        }
        public RoomManagementVM(string id, string status, int price, string type)
        {
            ID = id;
            Type = type;
            Status = status;
            Price = price;
        }
    }
}
