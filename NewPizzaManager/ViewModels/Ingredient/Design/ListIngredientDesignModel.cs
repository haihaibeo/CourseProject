using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewPizzaManager
{
    public class ListIngredientDesignModel : ListIngredientViewModel
    {
        public static ListIngredientDesignModel Instance = new ListIngredientDesignModel();
        public ListIngredientDesignModel()
        {
            Items = new System.Collections.ObjectModel.ObservableCollection<IngreTypeViewModel>();
        }
    }
}
