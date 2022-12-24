﻿using Hotel.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;

namespace Hotel.ViewModel
{
    internal class EmployeeVM : BaseViewModel
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public int Salary { get; set; }
        public string User { get; set; }
        public string Pass { get; set; }
        public string Type { get; set; }
        public ICommand ShowMessage { get; set; }
        public EmployeeVM()
        {
            ShowMessage = new RelayCommand<RoomView>((parameter) => true, (parameter) =>
            {
                MessageBox.Show(this.ID);
            });
        }
        public EmployeeVM(string id, string name,string user, string pass, int salary, string type)
        {
            Name = name;
            ID = id;
            Salary = salary;
            User = user;
            Pass = pass;
            Type = type;
        }
    }
}
