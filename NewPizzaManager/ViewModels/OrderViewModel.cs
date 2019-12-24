using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Input;

namespace NewPizzaManager
{
    public class OrderViewModel : PizzaDetailViewModel_
    {
        public ObservableCollection<PizzaDetailViewModel_> Carts { get; set; }
        public ObservableCollection<PizzaDetailViewModel_> AvailablePizzas { get; set; }
        public ObservableCollection<IngredientTypeViewModel> IngreTypes { get; set; }
        public PizzaDetailViewModel_ NewPizzaUserCreated { get; set; }

        public BLL.CustomerModel Customer { get; set; }
        public string Name { get; set; }
        public string Street { get; set; }
        public string Apartment { get; set; }
        public string Block { get; set; }
        public string Phone { get; set; }

        public string Address { get; set; }

        public decimal TotalPrice { get; set; }

        public ICommand Order { get; set; }
        public static ICommand AddNewCart { get; set; }
        public static ICommand DeleteFromCart { get; set; }
        public static ICommand AddIngredientToPizza { get; set; }
        public static ICommand DeleteIngredientFromPizza { get; set; }

        public static OrderViewModel CartInstance => new OrderViewModel();

        public OrderViewModel()
        {
            SelectSection = new RelayParameterizedCommand(Uid => _selectSection(Uid));
            AddNewCart = new RelayParameterizedCommand(pizza_id => _addNewCart(pizza_id));
            DeleteFromCart = new RelayParameterizedCommand(parameter => _deleteFromCart(parameter));
            AddIngredientToPizza = new RelayParameterizedCommand(ingre_id => _addIngre(ingre_id));
            DeleteIngredientFromPizza = new RelayParameterizedCommand(ingre_id => _deleteIngre(ingre_id));

            Order = new RelayCommand(_order);

            Carts = new ObservableCollection<PizzaDetailViewModel_>();
            AvailablePizzas = new ObservableCollection<PizzaDetailViewModel_>();
            IngreTypes = new ObservableCollection<IngredientTypeViewModel>();

            CreateShellPizzas();
            FillIngredientType();
            InstantiateNewPizzaUserCreated();
            this.Carts.CollectionChanged += Carts_CollectionChanged;
            
        }

        private void _addIngre(object ingre_id)
        {
            foreach (var item in NewPizzaUserCreated.Ingres)
            {
                if (item.ID == (int)ingre_id)
                    return;
            }
            var ingre = db.GetIngredient((int)ingre_id);
            NewPizzaUserCreated.Ingres.Add(ingre);
            NewPizzaUserCreated.TotalPricePizza += ingre.Cost;
        }

        private void _deleteIngre(object ingre_id)
        {
            foreach (var item in NewPizzaUserCreated.Ingres)
            {
                if (item.ID == (int)ingre_id)
                {
                    NewPizzaUserCreated.Ingres.Remove(item);
                    NewPizzaUserCreated.TotalPricePizza -= item.Cost;
                    return;
                }
            }
        }

        private void InstantiateNewPizzaUserCreated()
        {
            this.NewPizzaUserCreated = new PizzaDetailViewModel_();
            NewPizzaUserCreated.SelectedSizeID = 2;
            NewPizzaUserCreated.TotalPricePizza = 0;
            NewPizzaUserCreated.PizzaImage = "/Images/Pizza/UserCreatedPizza.png";
            NewPizzaUserCreated.Ingres = new ObservableCollection<BLL.IngredientModel>();
        }

        private void FillIngredientType()
        {
            var AllType = db.GetAllCategories();
            foreach (var type in AllType)
            {
                IngreTypes.Add(new IngredientTypeViewModel(type));
            }
        }

        private void _deleteFromCart(object parameter)
        {
            foreach(var item in Carts)
            {
                if (item.SelectedPizzaID == (int)parameter)
                {
                    Carts.Remove(item);
                    return;
                }
            }
        }

        private void CreateShellPizzas()
        {
            foreach (var item in db.GetAllPizzas())
            {
                AvailablePizzas.Add(new PizzaDetailViewModel_(item.ID, 1, Quantity.Один));
            }
            foreach (var item in AvailablePizzas)
            {
                switch (item.SelectedPizzaID)
                {
                    case 1:
                        item.PizzaImage = "/Images/Pizza/Pizza_1.png";
                        break;
                    case 2:
                        item.PizzaImage = "/Images/Pizza/Pizza_2.png";
                        break;
                    case 3:
                        item.PizzaImage = "/Images/Pizza/Pizza_3.png";
                        break;
                    case 4:
                        item.PizzaImage = "/Images/Pizza/Pizza_4.png";
                        break;
                    default:
                        item.PizzaImage = "";
                        break;
                }
            }
        }

        private void _order()
        {
            BLL.CustomerModel cust = new BLL.CustomerModel()
            {
                Name = this.Name,
                Address = Street + Block + Apartment,
                Phone = Phone
            };
            if (Carts.Count > 0 && cust.Address != null)
            {
                try
                {
                    int cust_id = db.AddNewCustomer(cust);
                    List<int> cart_id = new List<int>();
                    foreach (var item in Carts)
                    {
                        BLL.DetailModel dt = new BLL.DetailModel()
                        {
                            Quantity = (int)SelectedQuant,
                            Size_ID = item.SelectedSizeID
                        };
                        int id = db.AddNewCart(dt, item.SelectedPizzaID);
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
            RecalculateTotalPrice();
        }

        private void RecalculateTotalPrice()
        {
            TotalPrice = 0;
            foreach (var item in Carts)
            {
                TotalPrice += item.TotalPricePizza;
            }
        }

        private void Item_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(TotalPricePizza))
            {
                RecalculateTotalPrice();
            }
        }

        private void _addNewCart(object pizza_id)
        {
            foreach(var item in Carts)
            {
                if(item.Pizza.ID == (int)pizza_id)
                {
                    switch (item.SelectedQuant)
                    {
                        case Quantity.Один:
                            item.SelectedQuant = Quantity.Два;
                            OnPropertyChanged(nameof(Carts));
                            return;
                        case Quantity.Два:
                            item.SelectedQuant = Quantity.Три;
                            return;
                        case Quantity.Три:
                            item.SelectedQuant = Quantity.Четыре;
                            return;
                        case Quantity.Четыре:
                            item.SelectedQuant = Quantity.Пять;
                            return;
                        case Quantity.Пять:
                            item.SelectedQuant = Quantity.Пять;
                            return;
                        default:
                            item.SelectedQuant = Quantity.Пять;
                            return;
                    }
                }
            }
            var newPizza = new PizzaDetailViewModel_((int)pizza_id, 2, Quantity.Один);
            switch (pizza_id)
            {
                case 1:
                    newPizza.PizzaImage = "/Images/Pizza/Pizza_1.png";
                    break;
                case 2:
                    newPizza.PizzaImage = "/Images/Pizza/Pizza_2.png";
                    break;
                case 3:
                    newPizza.PizzaImage = "/Images/Pizza/Pizza_3.png";
                    break;
                case 4:
                    newPizza.PizzaImage = "/Images/Pizza/Pizza_4.png";
                    break;
                default:
                    newPizza.PizzaImage = "";
                    break;
            }
            newPizza.PropertyChanged += Item_PropertyChanged;
            Carts.Add(newPizza);
        }

        #region Main Buttons views
        public ICommand SelectSection { get; set; }

        public Section CurrentSection { get; set; } = Section.Home;

        public Visibility IsOverViewVisible { get; set; } = Visibility.Visible;
        public Visibility IsOrderVisible { get; set; } = Visibility.Collapsed;
        public Visibility IsCreatePizzaViewVisible { get; set; } = Visibility.Collapsed;
        public Visibility IsInfoViewVisible { get; set; } = Visibility.Collapsed;

        private void _selectSection(object Uid)
        {
            int uid = Convert.ToInt32(Uid);
            CurrentSection = (Section)uid;

            switch (CurrentSection)
            {
                case Section.Home:
                    IsOrderVisible = Visibility.Collapsed;
                    IsOverViewVisible = Visibility.Visible;
                    IsCreatePizzaViewVisible = Visibility.Collapsed;
                    IsInfoViewVisible = Visibility.Collapsed;
                    break;

                case Section.QuickOrder:
                    IsOrderVisible = Visibility.Visible;
                    IsOverViewVisible = Visibility.Collapsed;
                    IsCreatePizzaViewVisible = Visibility.Collapsed;
                    IsInfoViewVisible = Visibility.Collapsed;
                    break;

                case Section.CreatePizza:
                    IsOrderVisible = Visibility.Collapsed;
                    IsOverViewVisible = Visibility.Collapsed;
                    IsCreatePizzaViewVisible = Visibility.Visible;
                    IsInfoViewVisible = Visibility.Collapsed;
                    break;

                case Section.Discount:
                    IsOrderVisible = Visibility.Collapsed;
                    IsOverViewVisible = Visibility.Collapsed;
                    IsCreatePizzaViewVisible = Visibility.Collapsed;
                    IsInfoViewVisible = Visibility.Visible;
                    break;

                default:
                    Debugger.Break();
                    break;
            }
        }
        #endregion
    }
}