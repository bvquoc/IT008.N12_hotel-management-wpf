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
        public ICommand DeleteService { get; set; }
        public string ID { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public ICommand ShowMessage { get; set; }
        public ServiceVM()
        {
            DeleteService = new RelayCommand<ServiceViewModel>((p) => true, (p) => deleteService());
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
        public void deleteService(ServiceViewModel p)
        {
            using (var db = new QLYHOTELEntities())
            {
                var delete = (from d in db.DICHVUs where d.MADV == Int32.Parse(this.ID) select d).Single();
                db.DICHVUs.Remove(delete);
                db.SaveChanges();
                p.LoadAllSV();
            }
        }
    }
}
