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
        public int NumSer { get; set; }
        public int Total { get; set; }
        public ICommand DeleteService { get; set; }
        public ServiceVM()
        {
            DeleteService = new RelayCommand<ServiceManagementView>((p) => true, (p) => deleteService(p));
        }
        public ServiceVM(string id, string name, int price, int numSer, int total)
        {
            Name = name;
            ID = id;
            Price = price;
            NumSer = numSer;
            Total = total;
        }
        public void deleteService(ServiceManagementView p)
        {
            try
            {
                using (var db = new QLYHOTELEntities())
                {
                    int id = Int32.Parse(this.ID);
                    var delete = (from d in db.DICHVUs where d.MADV == id select d).Single();
                    delete.IsDelete = 1;
                    db.SaveChanges();
                }
                //Update data
                ServiceViewModel serviceViewModel = new ServiceViewModel();
                p.DataContext = serviceViewModel;
            }
            catch (Exception ex)
            {
                new DialogCustomize(ex.Message).ShowDialog();
            }
        }
    }
}
