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
    internal class ServiceVM : BaseViewModel
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public ICommand ShowMessage { get; set; }
        public ServiceVM()
        {
            ShowMessage = new RelayCommand<RoomView>((parameter) => true, (parameter) =>
            {
                MessageBox.Show(this.ID);
            });
        }
        public ServiceVM(string id, string name, int price)
        {
            Name = name;
            ID=id;
            price =price;
        }
    }
}
