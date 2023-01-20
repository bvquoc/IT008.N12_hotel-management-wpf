﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.ViewModel
{
    internal class LoginVM
    {
        public int MaNV { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public LoginVM() { }    
        public LoginVM(string _username, string _password, int _MaNV) {
            this.username = _username;
            this.password = _password;
            this.MaNV = _MaNV;
        }
    }
}
