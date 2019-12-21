using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewPizzaManager
{
    public class PizzaDetailViewModel : BaseViewModel
    {
        public ObservableCollection<BLL.PizzaModel> Pizzas { get; set; }
        public ObservableCollection<BLL.SizeModel> Sizes { get; set; }
       // public ObservableCollection<Quantity> quant { get; set; } = Quantity.One;

        public int SelectedPizzaIndex { get; set; } = 1;
        public int SelectedSizeIndex { get; set; } = 1;
        public int SelectedQuantIndex { get; set; } = 1;


        public static PizzaDetailViewModel Instance
        {
            get
            {
                return new PizzaDetailViewModel();
            }
        }

        public PizzaDetailViewModel()
        {
            Pizzas = new ObservableCollection<BLL.PizzaModel>();
            Sizes = new ObservableCollection<BLL.SizeModel>();

            foreach (var item in db.GetAllPizzas())
            {
                Pizzas.Add(item);
            }

            foreach (var item in db.GetAllSize())
            {
                Sizes.Add(item);
            }
        }

        public PizzaDetailViewModel(int pizza, int size, int quant)
        {
            this.SelectedPizzaIndex = pizza;
            this.SelectedSizeIndex = size;
            this.SelectedQuantIndex = quant;

            Pizzas = new ObservableCollection<BLL.PizzaModel>();
            Sizes = new ObservableCollection<BLL.SizeModel>();

           // this.quant = Quantity.quantity;

            foreach (var item in db.GetAllPizzas())
            {
                Pizzas.Add(item);
            }

            foreach (var item in db.GetAllSize())
            {
                Sizes.Add(item);
            }
        }
    }
}
