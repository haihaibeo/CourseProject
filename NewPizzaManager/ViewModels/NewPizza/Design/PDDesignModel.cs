using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace NewPizzaManager
{
    public class PDDesignModel : PizzaDetailViewModel_
    {
        public static PDDesignModel Instance => new PDDesignModel();

        public ICommand IndexChanged { get; set; }

        public PDDesignModel()
        {
            SelectedPizzaIndex = 1;
            SelectedQuantIndex = 1;
            SelectedSizeIndex = 1;
            Pizzas = new System.Collections.ObjectModel.ObservableCollection<BLL.PizzaModel>(db.GetAllPizzas());
            Sizes = new System.Collections.ObjectModel.ObservableCollection<BLL.SizeModel>(db.GetAllSize());
            quant = Quantity.quantity;
        }
    }
}
