using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace NewPizzaManager
{
    public class LoginViewModel : BaseViewModel
    {
        public string Email { get; set; }

        // A flag showing that logging command is running
        public bool LoginIsRunning { get; set; }

        // You cant really bind into a SecureString, so i just commented it out 
        //public SecureString Password { get; set; }
        public ICommand LoginCommand { get; set; }



        public LoginViewModel()
        {
            // A command really should not pass in any parameters, but in this special case with login authorization, we created a new 
            // work-around to get to that point with RalayParameterizedCommand
            LoginCommand = new RelayParameterizedCommand(async (parameter) => await Login(parameter));
        }

        // this is an async task because when you hit login, you need to wait for the server to confirm the identity, only then will proceed next step
        public async Task Login(object parameter)
        {
            if (LoginIsRunning == true)
                return;

            try
            {
                LoginIsRunning = true;

                await Task.Delay(1000);

                var Email = this.Email;

                // never store a password in a variable, just pass in a function then send to a server
                var pass = (parameter as IPassword).SecurePassword.Unsecure();

                ((WindowViewModel)(Application.Current.MainWindow as MainWindow).DataContext).CurrentPage = ApplicationPage.MainPage;
            }
            catch { }
            finally
            {
                LoginIsRunning = false;
            }

        }
    }
}
