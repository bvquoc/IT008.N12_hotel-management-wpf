using Hotel.Model;
using Hotel.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Hotel.ViewModel
{
    internal class AddServiceViewModel : BaseViewModel
    {
        public ICommand CloseCommand { get; set; }
        public ICommand SaveCommand { get; set; }
        public AddServiceViewModel()
        {
            CloseCommand = new RelayCommand<Window>((parameter) => true, (parameter) => parameter.Close());
            SaveCommand = new RelayCommand<AddService>((parameter) => true, (parameter) => addService(parameter));
        }
        private void addService(AddService p)
        {
            try
            {
                if (p._Name.Text == "")
                    throw new Exception("Vui lòng nhập tên dịch vụ!");
                if (p._Price.Text == "")
                    throw new Exception("Vui lòng nhập giá dịch vụ!");
                using (var db = new QLYHOTELEntities())
                {
                    db.DICHVUs.Add(new DICHVU() { TENDV = p._Name.Text, DONGIA = Int32.Parse(p._Price.Text) });
                    db.SaveChanges();
                    MessageBox.Show("Thêm thành công!");
                    p.Close();
                }
            }
            catch (Exception ex)
            {
                new DialogCustomize(ex.Message).ShowDialog();
            }
        }
    }
}
