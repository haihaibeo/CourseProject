using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class IngredientModel
    {
        public int ID { get; private set; }
        public string Name { get; set; }
        public decimal Cost { get; set; }

        public IngredientModel(DAL.Ingredient ingre)
        {
            this.ID = ingre.ID;
            this.Name = ingre.Name;
            this.Cost = ingre.Cost;
        }

        public IngredientModel()
        {
                
        }
    }
}
