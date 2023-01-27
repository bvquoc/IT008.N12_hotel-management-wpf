using Hotel.Model;
using Hotel.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Hotel.ViewModel
{
    internal class CustomerDetailViewModel : BaseViewModel
    {
        private ObservableCollection<ReserveVM> listRese;

        public ObservableCollection<ReserveVM> ListRese
        {
            get { return listRese; }
            set { listRese = value; OnPropertyChanged(); }
        }
        public ICommand Loaddb { get; set; }
        public CustomerDetailViewModel()
        {
            Loaddb = new RelayCommand<CustomerDetail>((p) => true, (p) => LoadList(p));
        }
        private void LoadList(CustomerDetail p)
        {
            ListRese = new ObservableCollection<ReserveVM>();
            int id = Convert.ToInt32(p._IDCus.Text);
            using (var db = new QLYHOTELEntities())
            {
                var select = (from i in db.KHACHes where i.MAKH == id select i).Single();
                foreach (var room in select.DATs)
                    ListRese.Insert(0, new ReserveVM() { ID = room.MADAT, RoomName = room.PHONG.TENPHONG, StartDate = room.NGAYDAT.Value, EndDate = room.NGAYTRA.Value, Status = room.TRANGTHAI });
            }
        }
    }
}
