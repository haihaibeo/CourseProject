using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class ReceiptModel
    {
        public int ID { get; private set; }
        public int Pizza_ID { get; set; }
        public int Ingredient_ID { get; set; }

        public ReceiptModel(DAL.Receipt rc)
        {
            this.ID = rc.ID;
            this.Pizza_ID = rc.Pizza_ID;
            this.Ingredient_ID = rc.Ingredient_ID;
        }

        public ReceiptModel()
        {
                
        }
    }
}
