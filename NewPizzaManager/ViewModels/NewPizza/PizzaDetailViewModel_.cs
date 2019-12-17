using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewPizzaManager
{
    public class PizzaDetailViewModel_ : BaseViewModel
    {
        public ObservableCollection<BLL.PizzaModel> Pizzas { get; set; } = new ObservableCollection<BLL.PizzaModel>(db.GetAllPizzas());
        public ObservableCollection<BLL.SizeModel> Sizes { get; set; } = new ObservableCollection<BLL.SizeModel>(db.GetAllSize());
        public ObservableCollection<int> quant { get; set; } = Quantity.quantity;

        public int SelectedPizzaIndex { get; set; } = 1;
        public int SelectedSizeIndex { get; set; } = 1;
        public int SelectedQuantIndex { get; set; } = 1;

        public PizzaDetailViewModel_()
        {

        }
        public PizzaDetailViewModel_(int pizza, int size, int quant)
        {
            this.SelectedPizzaIndex = pizza;
            this.SelectedQuantIndex = quant;
            this.SelectedSizeIndex = size;
        }
    }
}
