using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LoginControl.Models;
using System.Windows;
using System.Windows.Controls;

namespace LoginControl.ViewModels
{
    public class ShellViewModel : Screen
    {
        private string _login;

        public string Login
        {
            get { return _login; }
            set 
            { 
                _login = value;
                NotifyOfPropertyChange(() => Login);
            }
        }

        private string _password;

        public string Password
        {
            get { return _password; }
            set
            { 
                _password = value;
                NotifyOfPropertyChange(() => Password);
            }
        }



        LoginModel manager = new LoginModel("admin", "admin");

        public void Button_login()
        {
            if (_login == manager.Login && _password == manager.Password)
                MessageBox.Show("Correct");
            else MessageBox.Show("Incorrect");
        }

    }
}
