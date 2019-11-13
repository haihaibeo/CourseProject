using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginControl.Models
{
    public class LoginModel
    {
        private string _login;

        public string Login
        {
            get { return _login; }
            set { _login = value; }
        }

        private string _password;

        public string Password
        {
            get { return _password; }
            set { _password = value; }
        }

        public LoginModel (string Login, string Password)
        {
            this.Login = Login;
            this.Password = Password;
        }
    }
}
