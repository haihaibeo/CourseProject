using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class CategoryReposSQL : IRepository<Category>
    {
        private OrderPizzaEntity _dbContext;

        public CategoryReposSQL(OrderPizzaEntity db)
        {
            this._dbContext = db;
        }

        public void Create(Category item)
        {
            _dbContext.Categories.Add(item);
        }

        public void Delete(int id)
        {
            var item = _dbContext.Categories.Find(id);
            if (item != null)
                _dbContext.Categories.Remove(item);
        }

        public Category GetItem(int? id)
        {
            return _dbContext.Categories.Find(id);
        }

        public List<Category> GetList()
        {
            return _dbContext.Categories.ToList();
        }

        public bool IsSaved()
        {
            return _dbContext.SaveChanges() > 0;
        }

        public void Update(Category item)
        {
            _dbContext.Entry(item).State = System.Data.Entity.EntityState.Modified;
        }
    }
}
