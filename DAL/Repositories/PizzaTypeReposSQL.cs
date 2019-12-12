
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    internal class PizzaTypeReposSQL : IRepository<PizzaType>
    {
        private OrderPizzaEntity _dbcontext;

        public PizzaTypeReposSQL(OrderPizzaEntity dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public void Create(PizzaType item)
        {
            _dbcontext.PizzaTypes.Add(item);
        }

        public void Delete(int id)
        {
            var pizzaType = _dbcontext.PizzaTypes.Find(id);
            if (pizzaType != null)
                _dbcontext.PizzaTypes.Remove(pizzaType);
        }

        public PizzaType GetItem(int? id)
        {
            return _dbcontext.PizzaTypes.Find(id);
        }

        public List<PizzaType> GetList()
        {
            return _dbcontext.PizzaTypes.ToList();
        }

        public void Update(PizzaType item)
        {
            _dbcontext.Entry(item).State = System.Data.Entity.EntityState.Modified;
        }

        public bool IsSaved()
        {
            return _dbcontext.SaveChanges() > 0;
        }
    }
}
