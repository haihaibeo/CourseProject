using System;
using System.Collections.ObjectModel;

namespace NewPizzaManager
{
    public class CustomerViewModel : BaseViewModel
    {
        public BLL.CustomerModel Customer { get; set; }
        public ObservableCollection<BLL.OrderModel> Orders { get; set; }
        public ObservableCollection<OrderPerCustomerViewModel> Carts { get; set; }
        public decimal TotalPerCustomer { get; set; }

        public CustomerViewModel(int customer_id)
        {
            Customer = db.GetCustomer(customer_id);
            Orders = new ObservableCollection<BLL.OrderModel>(db.GetOrdersByCustomerID(Customer.ID));
            Carts = new ObservableCollection<OrderPerCustomerViewModel>();
            foreach(var item in Orders)
            {
                Carts.Add(new OrderPerCustomerViewModel(item));
                TotalPerCustomer += item.TotalPriceOrder;
            }
        }
    }

    public class OrderPerCustomerViewModel : BaseViewModel
    {
        public string PizzaName { get; set; }
        public string SizeName { get; set; }
        public Quantity Quantity { get; set; }
        public string Status { get; set; }
        public decimal TotalPrice { get; set; }

        public OrderPerCustomerViewModel(BLL.OrderModel order)
        {
            GetQuantity(order);
            GetStatus(order);
        }

        private void GetStatus(BLL.OrderModel order)
        {
            Status = db.GetStatus(order.Status_ID).Status;
        }

        private void GetQuantity(BLL.OrderModel order)
        {
            var pd = db.GetPizzaDetail(order.PizzaDetail_ID);
            PizzaName = db.GetPizza(pd.Pizza_ID).Name;
            SizeName = db.GetSize(db.GetDetail(pd.Detail_ID).Size_ID).SizeName;
            int quant = db.GetDetail(pd.Detail_ID).Quantity;
            switch(quant)
            {
                case 1:
                    Quantity = Quantity.Один;
                    break;
                case 2:
                    Quantity = Quantity.Два;
                    break;
                case 3:
                    Quantity = Quantity.Три;
                    break;
                case 4:
                    Quantity = Quantity.Четыре;
                    break;
                case 5:
                    Quantity = Quantity.Пять;
                    break;
                default: break;
            }
            TotalPrice = order.TotalPriceOrder;
        }
    }
}
