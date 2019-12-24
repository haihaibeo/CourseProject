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
        public ObservableCollection<CustomerViewModel> Customers { get; set; }
        public PizzaDetailViewModel_ NewPizzaUserCreated { get; set; }

        public BLL.CustomerModel Customer { get; set; }

        public string Name { get; set; }
        public string Street { get; set; }
        public string Apartment { get; set; }
        public string Block { get; set; }
        public string Phone { get; set; }
        public string FindName { get; set; }

        public string Address { get; set; }

        public decimal TotalPrice { get; set; }

        public ICommand Order { get; set; }
        public static ICommand AddNewCart { get; set; }
        public static ICommand DeleteFromCart { get; set; }
        public static ICommand AddIngredientToPizza { get; set; }
        public static ICommand DeleteIngredientFromPizza { get; set; }
        public static ICommand CreateNewPizzaAndAddToCart { get; set; }
        public static ICommand GetCustomers { get; set; }

        public static OrderViewModel CartInstance => new OrderViewModel();

        public OrderViewModel()
        {
            SelectSection = new RelayParameterizedCommand(Uid => _selectSection(Uid));
            AddNewCart = new RelayParameterizedCommand(pizza_id => _addNewCart(pizza_id));
            DeleteFromCart = new RelayParameterizedCommand(parameter => _deleteFromCart(parameter));
            AddIngredientToPizza = new RelayParameterizedCommand(ingre_id => _addIngre(ingre_id));
            DeleteIngredientFromPizza = new RelayParameterizedCommand(ingre_id => _deleteIngre(ingre_id));
            CreateNewPizzaAndAddToCart = new RelayCommand(_createNewPizza);
            GetCustomers = new RelayCommand(_findCustomers);
            

            Order = new RelayCommand(_order);

            Carts = new ObservableCollection<PizzaDetailViewModel_>();
            AvailablePizzas = new ObservableCollection<PizzaDetailViewModel_>();
            IngreTypes = new ObservableCollection<IngredientTypeViewModel>();

            CreateShellPizzas();
            FillIngredientType();
            InstantiateNewPizzaUserCreated();
            this.Carts.CollectionChanged += Carts_CollectionChanged;
            
        }

        private void _findCustomers()
        {
            Customers = new ObservableCollection<CustomerViewModel>();
            if (String.IsNullOrWhiteSpace(FindName))
                return;
            foreach(var item in db.GetAllCustomers())
            {
                if(item.Name.Contains(FindName))
                {
                    Customers.Add(new CustomerViewModel(item.ID));
                }
            }
        }

        private void _createNewPizza()
        {
            if (string.IsNullOrWhiteSpace(NewPizzaUserCreated.UserCreatedPizzaName))
            {
                MessageBox.Show("Please fill the pizza name field");
                return;
            }
            if(NewPizzaUserCreated.Ingres.Count == 0)
            {
                MessageBox.Show("Please add some ingredients");
                return;
            }
            NewPizzaUserCreated.Pizza.Name = NewPizzaUserCreated.UserCreatedPizzaName;
            NewPizzaUserCreated.Pizza.Price = NewPizzaUserCreated.TotalPricePizza;

            var buff_pizza = NewPizzaUserCreated.Pizza;
            db.MakeNewPizza(ref buff_pizza, new List<BLL.IngredientModel>(NewPizzaUserCreated.Ingres));
            NewPizzaUserCreated.Pizza = buff_pizza;

            var newPizza = new PizzaDetailViewModel_(NewPizzaUserCreated.Pizza.ID, NewPizzaUserCreated.SelectedSizeID, Quantity.Один);
            newPizza.PizzaImage = "/Images/Pizza/UserCreatedPizza.png";
            Carts.Add(newPizza);
            MessageBox.Show("Successful!");
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
            NewPizzaUserCreated.Pizza = new BLL.PizzaModel();
            NewPizzaUserCreated.PizzaImage = "/Images/Pizza/UserCreatedPizza.png";
            NewPizzaUserCreated.Ingres = new ObservableCollection<BLL.IngredientModel>();
            NewPizzaUserCreated.Ingres.CollectionChanged += Ingres_CollectionChanged;
        }

        private void Ingres_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            RecalculateNewPizzaUserCreated();
        }

        private void RecalculateNewPizzaUserCreated()
        {
            NewPizzaUserCreated.TotalPricePizza = 0;
            foreach (var item in NewPizzaUserCreated.Ingres)
            {
                NewPizzaUserCreated.TotalPricePizza += item.Cost;
            }
            NewPizzaUserCreated.TotalPricePizza += 50;
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

            //delete pizza from user only
            //db.DeletePizzaUserCreated((int)parameter);
        }

        private void CreateShellPizzas()
        {
            foreach (var item in db.GetAllPizzas())
            {
                if (item.PizzaType_ID == 1)
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
                        item.PizzaImage = "/Images/Pizza/UserCreatedPizza.png";
                        break;
                }
            }
        }

        private void _order()
        {
            if(String.IsNullOrWhiteSpace(Name) 
                || String.IsNullOrWhiteSpace(Phone) 
                || String.IsNullOrWhiteSpace(Street)
                || String.IsNullOrWhiteSpace(Block)
                || String.IsNullOrWhiteSpace(Apartment))
            {
                MessageBox.Show("Please fill all needed fields");
                return;
            }

            BLL.CustomerModel customer = new BLL.CustomerModel()
            {
                Name = this.Name,
                Phone = this.Phone,
                Address = String.Join(" ", this.Street, this.Block, this.Apartment)
            };

            List<BLL.PizzaDetailModel> carts = new List<BLL.PizzaDetailModel>();
            foreach (var item in Carts)
            {
                BLL.DetailModel detail = new BLL.DetailModel()
                {
                    Quantity = (int)item.SelectedQuant,
                    Size_ID = item.SelectedSizeID
                };
                db.AddNewDetail(ref detail);
                carts.Add(new BLL.PizzaDetailModel()
                {
                    Pizza_ID = item.SelectedPizzaID,
                    TotalPrice = item.TotalPricePizza,
                    Detail_ID = detail.ID
                });
            }

            if (db.AddNewOrder(ref customer, ref carts))
            {
                MessageBox.Show("Successful!");
            }
            else MessageBox.Show("Cannot add new order !");
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
                    newPizza.PizzaImage = "/Images/Pizza/UserCreatedPizza.png";
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