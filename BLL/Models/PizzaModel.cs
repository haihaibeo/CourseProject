using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class PizzaModel
    {
        public int ID { get; private set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int PizzaType_ID { get; set; }

        public PizzaModel(DAL.Pizza p)
        {
            this.ID = p.ID;
            this.Name = p.Name;
            this.Price = p.Price;
            this.PizzaType_ID = p.PizzaType_ID;
        }

        public PizzaModel()
        {

        }
    }
}
