using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Hotel.ViewModel
{
    internal class AddEmployeeViewModel : BaseViewModel
    {
        public ICommand CloseCommand { get; set; }

        public AddEmployeeViewModel()
        {
            CloseCommand = new RelayCommand<Window>((parameter) => true, (parameter) => parameter.Close());
        }
    }
}
