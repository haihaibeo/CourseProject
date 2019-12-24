using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class CustomerReposSQL : IRepository<Customer>
    {
        private OrderPizzaEntity _dbcontext;

        public CustomerReposSQL(OrderPizzaEntity dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public void Create(Customer item)
        {
            _dbcontext.Customers.Add(item);
        }

        public void Delete(int id)
        {
            var item = _dbcontext.Customers.Find(id);
            if (item != null)
                _dbcontext.Customers.Remove(item);
        }

        public Customer GetItem(int? id)
        {
            return _dbcontext.Customers.Find(id);
        }

        public List<Customer> GetList()
        {
            return _dbcontext.Customers.ToList();
        }

        public void Update(Customer item)
        {
            _dbcontext.Entry(item).State = System.Data.Entity.EntityState.Modified;
        }

        public bool IsSaved()
        {
            return _dbcontext.SaveChanges() > 0;
        }

        public Customer GetLastRecord()
        {
            return _dbcontext.Customers.OrderByDescending(i => i.ID).FirstOrDefault();
        }
    }
}
