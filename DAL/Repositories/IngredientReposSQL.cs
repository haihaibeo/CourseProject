using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class IngredientReposSQL : IRepository<Ingredient>
    {
        private OrderPizzaEntity _dbcontext;

        public IngredientReposSQL(OrderPizzaEntity dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public void Create(Ingredient item)
        {
            _dbcontext.Ingredients.Add(item);
        }

        public void Delete(int id)
        {
            var ingre = _dbcontext.Ingredients.Find(id);
            if (ingre != null)
                _dbcontext.Ingredients.Remove(ingre);
        }

        public Ingredient GetItem(int? id)
        {
            return _dbcontext.Ingredients.Find(id);
        }

        public List<Ingredient> GetList()
        {
            return _dbcontext.Ingredients.ToList();
        }

        public void Update(Ingredient item)
        {
            _dbcontext.Entry(item).State = System.Data.Entity.EntityState.Modified;
        }

        public bool IsSaved()
        {
            return _dbcontext.SaveChanges() > 0;
        }

        public Ingredient GetLastRecord()
        {
            return _dbcontext.Ingredients.OrderByDescending(i => i.ID).FirstOrDefault();
        }
    }
}
