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
        public ObservableCollection<Quantity> Quants { get; set; } = new ObservableCollection<Quantity>() 
        {
            Quantity.Один, Quantity.Два, Quantity.Три, Quantity.Четыре, Quantity.Пять 
        };

        public string PizzaImage { get; set; }

        private void RecalculatePrice()
        {
            TotalPricePizza = db.GetPizza(SelectedPizzaID).Price * (int)SelectedQuant * Convert.ToDecimal(db.GetRatio(SelectedSizeID));
        }

        private void PizzaDetailViewModel__PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            RecalculatePrice();
        }

        public Quantity SelectedQuant { get; set; } = Quantity.Один;
        public int SelectedPizzaID { get; set; } = 1;
        public int SelectedSizeID { get; set; } = 1;

        public decimal TotalPricePizza { get; set; }

        public PizzaDetailViewModel_()
        {

        }
        public PizzaDetailViewModel_(int pizza_id, int size_id, Quantity quant)
        {
            this.SelectedPizzaID = pizza_id;
            SelectedQuant = quant;
            this.SelectedSizeID = size_id;
            RecalculatePrice();
            PropertyChanged += PizzaDetailViewModel__PropertyChanged;
        }
    }
}
