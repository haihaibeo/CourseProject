using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewPizzaManager
{
    public class PDListDesignModel : PizzaDetailListViewModel__
    {
        public static PDListDesignModel Instance = new PDListDesignModel();

        public PDListDesignModel()
        {
            Items = new ObservableCollection<PizzaDetailViewModel_>();
        }
    }
}
