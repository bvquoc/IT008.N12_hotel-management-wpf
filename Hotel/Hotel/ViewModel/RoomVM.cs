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
    internal class RoomVM : BaseViewModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public ICommand ShowMessage { get; set; }
        public RoomVM()
        {
            ShowMessage = new RelayCommand<RoomView>((parameter) => true, (parameter) =>
            {
                MessageBox.Show(this.Name);
            });
        }
        public RoomVM(string name, string description, string status)
        {
            Name = name;
            Description = description;
            Status = status;
        }
    }
}
