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

        AddServiceViewModel()
        {
            CloseCommand = new RelayCommand<Window>((parameter) => true, (parameter) => parameter.Close());
        }
    }
}
