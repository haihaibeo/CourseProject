using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    interface IDatabaseRepository
    {
        IRepository<Customer> Customers { get; }
        IRepository<Detail> Details { get; }
        IRepository<Ingredient> Ingredients { get; }
        IRepository<Order> Orders { get; }
        IRepository<Pizza> Pizzas { get; }
        IRepository<PizzaDetail> PizzaDetails { get; }
        IRepository<PizzaType> PizzaTypes { get; }
        IRepository<Receipt> Receipts { get; }
        IRepository<Size> Sizes { get; }
        int Save();
    }
}
