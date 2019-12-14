using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace NewPizzaManager
{
    /// <summary>
    /// View Model for a custom flat window
    /// </summary>
    public class WindowViewModel : BaseViewModel
    {
        private Window _window;

        public WindowViewModel(Window window)
        {
            _window = window;
        }

        public ApplicationPage CurrentPage { get; set; } = ApplicationPage.Login;
    }
}
