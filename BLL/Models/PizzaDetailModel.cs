using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class PizzaDetailModel
    {
        public int ID { get; set; }
        public int Pizza_ID { get; set; }
        public int Detail_ID { get; set; }
        public decimal TotalPrice { get; set; }

        public PizzaDetailModel(DAL.PizzaDetail pd)
        {
            this.ID = pd.ID;
            this.Pizza_ID = pd.Pizza_ID;
            this.Detail_ID = pd.Detail_ID;
            this.TotalPrice = pd.TotalPricePizza;
        }

        public PizzaDetailModel()
        {
                
        }
    }
}
