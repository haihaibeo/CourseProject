using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace NewPizzaManager
{
    /// <summary>
    /// Easier way to bind to a viewmodel from a page
    /// </summary>
    /// <typeparam name="VM"></typeparam>
    public class BasePage<VM> : Page where VM : BaseViewModel, new()
    {
        private VM _viewModel;

        public VM ViewModel
        {
            get { return _viewModel; }
            set
            {
                if (_viewModel == value)
                    return;
                _viewModel = value;
                this.DataContext = _viewModel;
            }
        }

        public BasePage()
        {
            //Create a new default View Model
            this.ViewModel = new VM();
        }
    }
}
