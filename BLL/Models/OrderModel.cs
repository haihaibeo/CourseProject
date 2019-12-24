using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class OrderModel
    {
        public int ID { get; private set; }
        public int Customer_ID { get; set; }
        public int PizzaDetail_ID { get; set; }
        public int Status_ID { get; set; }
        public decimal TotalPriceOrder { get; set; }

        public OrderModel(DAL.Order o)
        {
            this.ID = o.ID;
            this.Customer_ID = o.Customer_ID;
            this.PizzaDetail_ID = o.PizzaDetail_ID;
            this.TotalPriceOrder = o.TotalPriceOrder;
            this.Status_ID = o.Status_ID;
        }

        public OrderModel()
        {

        }
    }
}
