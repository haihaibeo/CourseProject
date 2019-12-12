using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class SizeReposSQL : IRepository<Size>
    {
        private OrderPizzaEntity _dbcontext;

        public SizeReposSQL(OrderPizzaEntity dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public void Create(Size item)
        {
            _dbcontext.Sizes.Add(item);
        }

        public void Delete(int id)
        {
            var item = _dbcontext.Sizes.Find(id);
            if (item != null)
                _dbcontext.Sizes.Remove(item);
        }

        public Size GetItem(int? id)
        {
            return _dbcontext.Sizes.Find(id);
        }

        public List<Size> GetList()
        {
            return _dbcontext.Sizes.ToList();
        }

        public void Update(Size item)
        {
            _dbcontext.Entry(item).State = System.Data.Entity.EntityState.Modified;
        }

        public bool IsSaved()
        {
            return _dbcontext.SaveChanges() > 0;
        }
    }
}
