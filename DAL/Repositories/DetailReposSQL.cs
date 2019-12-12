using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DetailReposSQL : IRepository<Detail>
    {
        private OrderPizzaEntity _dbcontext;

        public DetailReposSQL(OrderPizzaEntity dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public void Create(Detail item)
        {
            _dbcontext.Details.Add(item);
        }

        public void Delete(int id)
        {
            var item = _dbcontext.Details.Find(id);
            if (item != null)
                _dbcontext.Details.Remove(item);
        }

        public Detail GetItem(int? id)
        {
            return _dbcontext.Details.Find(id);
        }

        public List<Detail> GetList()
        {
            return _dbcontext.Details.ToList();
        }

        public void Update(Detail item)
        {
            _dbcontext.Entry(item).State = System.Data.Entity.EntityState.Modified;
        }

        public bool IsSaved()
        {
            return _dbcontext.SaveChanges() > 0;
        }
    }
}
