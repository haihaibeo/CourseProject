using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class PizzaTypeModel
    {
        public int ID { get; private set; }
        public string Type { get; set; }

        public PizzaTypeModel(DAL.PizzaType pt)
        {
            this.ID = pt.ID;
            this.Type = pt.Type;
        }

        public PizzaTypeModel()
        {
                
        }
    }
}
