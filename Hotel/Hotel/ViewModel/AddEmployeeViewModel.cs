using Hotel.Model;
using Hotel.View;
using System.Windows;
using System.Windows.Input;

namespace Hotel.ViewModel
{
    internal class AddEmployeeViewModel : BaseViewModel
    {
        public ICommand CloseCommand { get; set; }
        public ICommand SaveCustomerCommand { get; set; }
        public AddEmployeeViewModel()
        {
            CloseCommand = new RelayCommand<Window>((parameter) => true, (parameter) => parameter.Close());
            SaveCustomerCommand = new RelayCommand<AddEmployee>((parameter) => true, (parameter) => saveCustomer(parameter));
        }
        private void saveCustomer(AddEmployee p)
        {
            var employee = new NHANVIEN();
            employee.TENNV = p._CCCD.Text;
            employee.CCCD = p._CCCD.Text;
            employee.NGSINH = p._BirthDay.SelectedDate.Value;
            employee.SDT = p._SDT.Text;
            employee.TAIKHOAN = p._Account.Text;
            employee.MATKHAU = p._Password.Password.ToString();
            string LoaiNv = p.cbType.SelectionBoxItem.ToString();
            switch (LoaiNv)
            {
                case "Quản lý":
                    employee.LOAINV = 1;
                    break;
                case "Nhân viên":
                    employee.LOAINV = 2;
                    break;
                default:
                    break;
            }
            employee.SONGAYLV = 0;
            employee.LUONG = 1;
            using (var db = new QLYHOTELEntities())
            {
                db.NHANVIENs.Add(employee);
                db.SaveChanges();
            }
        }

    }
}
