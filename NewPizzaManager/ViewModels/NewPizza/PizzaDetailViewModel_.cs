using System;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace NewPizzaManager
{
    /// <summary>
    /// View Model Control of each individual Pizza
    /// </summary>
    public class PizzaDetailViewModel_ : BaseViewModel
    {
        public ObservableCollection<BLL.IngredientModel> Ingres { get; set; }
        public ObservableCollection<BLL.SizeModel> Sizes { get; set; } = new ObservableCollection<BLL.SizeModel>(db.GetAllSize());
        public Quantity SelectedQuant { get; set; } = Quantity.Один;
        public BLL.PizzaModel Pizza { get; set; }

        public ObservableCollection<Quantity> Quants { get; set; } = new ObservableCollection<Quantity>()
        {
            Quantity.Один, Quantity.Два, Quantity.Три, Quantity.Четыре, Quantity.Пять
        };

        public int SelectedPizzaID { get; set; } = 1;
        public int SelectedSizeID { get; set; } = 1;
        public string PizzaImage { get; set; }
        public string UserCreatedPizzaName { get; set; }
        public decimal TotalPricePizza { get; set; }

        public PizzaDetailViewModel_()
        {
        }

        public PizzaDetailViewModel_(int pizza_id, int size_id, Quantity quant)
        {
            this.Pizza = db.GetPizza(pizza_id);
            this.SelectedPizzaID = pizza_id;
            SelectedQuant = quant;
            this.SelectedSizeID = size_id;
            this.Ingres = new ObservableCollection<BLL.IngredientModel>(db.GetIngreFromPizza(pizza_id));
            RecalculatePrice();
            PropertyChanged += PizzaDetailViewModel__PropertyChanged;
        }

        private void RecalculatePrice()
        {
            TotalPricePizza = db.GetPizza(SelectedPizzaID).Price * (int)SelectedQuant * Convert.ToDecimal(db.GetRatio(SelectedSizeID));
        }

        private void PizzaDetailViewModel__PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            RecalculatePrice();
        }
    }
}