using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class PizzaDetailReposSQL : IRepository<PizzaDetail>
    {
        private OrderPizzaEntity _dbcontext;

        public PizzaDetailReposSQL(OrderPizzaEntity dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public void Create(PizzaDetail item)
        {
            _dbcontext.PizzaDetails.Add(item);
        }

        public void Delete(int id)
        {
            var item = _dbcontext.PizzaDetails.Find(id);
            if (item != null)
                _dbcontext.PizzaDetails.Remove(item);
        }

        public PizzaDetail GetItem(int? id)
        {
            return _dbcontext.PizzaDetails.Find(id);
        }

        public List<PizzaDetail> GetList()
        {
            return _dbcontext.PizzaDetails.ToList();
        }

        public void Update(PizzaDetail item)
        {
            _dbcontext.Entry(item).State = System.Data.Entity.EntityState.Modified;
        }

        public bool IsSaved()
        {
            return _dbcontext.SaveChanges() > 0;
        }

        public PizzaDetail GetLastRecord()
        {
            return _dbcontext.PizzaDetails.OrderByDescending(i => i.ID).FirstOrDefault();
        }
    }
}
