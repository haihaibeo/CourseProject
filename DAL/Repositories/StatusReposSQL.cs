using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class StatusReposSQL : IRepository<Status>
    {
        private OrderPizzaEntity _dbcontext;

        public StatusReposSQL(OrderPizzaEntity dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public void Create(Status item)
        {
            _dbcontext.Status.Add(item);
        }

        public void Delete(int id)
        {
            var item = _dbcontext.Status.Find(id);
            if (item != null)
                _dbcontext.Status.Remove(item);
        }

        public Status GetItem(int? id)
        {
            return _dbcontext.Status.Find(id);
        }

        public List<Status> GetList()
        {
            return _dbcontext.Status.ToList();
        }

        public void Update(Status item)
        {
            _dbcontext.Entry(item).State = System.Data.Entity.EntityState.Modified;
        }

        public bool IsSaved()
        {
            return _dbcontext.SaveChanges() > 0;
        }

        public Status GetLastRecord()
        {
            return _dbcontext.Status.OrderByDescending(i => i.ID).FirstOrDefault();
        }
    }
}
