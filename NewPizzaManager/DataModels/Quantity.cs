using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewPizzaManager
{
    public static class Quantity
    {
        public static ObservableCollection<int> quantity = new ObservableCollection<int>() { 1, 2, 3, 4, 5 };
    }
}
