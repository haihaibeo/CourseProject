using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace NewPizzaManager
{
    public class OrderViewModel : PizzaDetailViewModel_
    {
        public ObservableCollection<PizzaDetailViewModel_> Carts { get; set; }
        public BLL.CustomerModel Customer { get; set; }
        public string Name { get; set; }
        public string Street { get; set; }
        public string Apartment { get; set; }
        public string Block { get; set; }
        public string Phone { get; set; }

        public string Address { get; set; }

        public decimal TotalPrice { get; set; }

        public ICommand AddNewCart { get; set; }
        public ICommand Order { get; set; }

        public static OrderViewModel CartInstance => new OrderViewModel();

        public OrderViewModel()
        {
            AddNewCart = new RelayCommand(_addNewCart);
            Order = new RelayCommand(_order);
            Carts = new ObservableCollection<PizzaDetailViewModel_>();
            this.Carts.CollectionChanged += Carts_CollectionChanged;
        }

        private void _order()
        {
            BLL.CustomerModel cust = new BLL.CustomerModel()
            {
                Name = this.Name,
                Address = Street + Block + Apartment,
                Phone = Phone
            };
            if(Carts.Count>0 && cust.Address != null)
            {
                try
                {
                    int cust_id = db.AddNewCustomer(cust);
                    List<int> cart_id = new List<int>();
                    foreach (var item in Carts)
                    {
                        BLL.DetailModel dt = new BLL.DetailModel()
                        {
                            Quantity = Quantity.quantity[item.SelectedQuantIndex],
                            Size_ID = item.SelectedQuantIndex
                        };
                        int id = db.AddNewCart(dt, item.SelectedPizzaIndex);
                        cart_id.Add(id);
                        db.AddNewOrder(id, cust_id, db.GetCart(id).TotalPrice);
                    }
                    db.Save();
                }
                catch { }
                
            }
            
        }

        private void Carts_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            TotalPrice = 0;
            if (Carts.Count > 0)
                foreach (var item in Carts)
                {
                    TotalPrice += db.GetPizza(item.SelectedPizzaIndex).Price * Convert.ToDecimal(db.GetRatio(item.SelectedSizeIndex)) * item.SelectedQuantIndex;
                }
            OnPropertyChanged(nameof(TotalPrice));
        }

        private void _addNewCart()
        {
            Carts.Add(new PizzaDetailViewModel_(1,1,1));
        }
    }
}
