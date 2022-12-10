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
