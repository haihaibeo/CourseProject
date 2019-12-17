using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewPizzaManager
{
    public class PizzaDetailListViewModel__ : BaseViewModel
    {
        public ObservableCollection<PizzaDetailViewModel_> Items { get; set; }
    }
}
