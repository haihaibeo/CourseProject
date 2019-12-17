using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewPizzaManager
{
    public class OrderModel
    {
        public int ID { get; private set; }
        public int Customer_ID { get; set; }
        public int PizzaDetail_ID { get; set; }
        public decimal TotalPriceOrder { get; set; }

        public OrderModel(BLL.OrderModel model)
        {
            this.ID = model.ID;
            this.Customer_ID = model.Customer_ID;
            this.PizzaDetail_ID = model.PizzaDetail_ID;
            this.TotalPriceOrder = model.TotalPriceOrder;
        }
        public OrderModel()
        {

        }
    }
}
