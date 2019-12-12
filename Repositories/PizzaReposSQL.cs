using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class PizzaReposSQL : IRepository<Pizza>
    {
        private PizzaDeliveryEntity _dbcontext;

        public PizzaReposSQL(PizzaDeliveryEntity dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public void Create(Pizza item)
        {
            _dbcontext.Pizzas.Add(item);
        }

        public void Delete(int id)
        {
            var pizza = _dbcontext.Pizzas.Find(id);
            if (pizza != null)
                _dbcontext.Pizzas.Remove(pizza);
        }

        public Pizza GetItem(int? id)
        {
            return _dbcontext.Pizzas.Find(id);
        }

        public List<Pizza> GetList()
        {
            return _dbcontext.Pizzas.ToList();
        }

        public void Update(Pizza item)
        {
            _dbcontext.Entry(item).State = System.Data.Entity.EntityState.Modified;
        }

        public bool IsSaved()
        {
            return _dbcontext.SaveChanges() > 0;
        }
    }
}
