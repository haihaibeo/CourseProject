using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL;

namespace TestBLL
{
    class Program
    {
        static void Main(string[] args)
        {
            OrderPizzaEntity context = new OrderPizzaEntity();
            DatabaseRepository ctx = new DatabaseRepository(context);

            BLL.DBDataOperation dbo = new BLL.DBDataOperation(ctx);
            IngredientModel ingre = new IngredientModel()
            {
                Name = "ingre 1",
                Cost = 20
            };
            dbo.AddNewIngre(ingre);
            dbo.Save();
            
               
        }
    }
}
