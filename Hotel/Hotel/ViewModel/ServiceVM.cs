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
    internal class ServiceVM : BaseViewModel
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public ICommand ShowMessage { get; set; }
        public ICommand DeleteService { get; set; }
        public ServiceVM()
        {
            //(p) => deleteService(p)
            DeleteService = new RelayCommand<ServiceManagementView>((p) => true, (p) => deleteService(p));
            ShowMessage = new RelayCommand<RoomView>((parameter) => true, (parameter) =>
            {
                MessageBox.Show(this.ID);
            });
        }
        public ServiceVM(string id, string name, int price)
        {
            Name = name;
            ID = id;
            Price = price;
        }
        public void deleteService(ServiceManagementView p)
        {
            using (var db = new QLYHOTELEntities())
            {
                int id = Int32.Parse(this.ID);
                var delete = (from d in db.DICHVUs where d.MADV == id select d).Single();
                db.DICHVUs.Remove(delete);
                db.SaveChanges();
            }
            //Update data
            ServiceViewModel serviceViewModel = new ServiceViewModel();
            p.DataContext = serviceViewModel;
        }
    }
}
