using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class OrderReposSQL : IRepository<Order>
    {
        private OrderPizzaEntity _dbcontext;

        public OrderReposSQL(OrderPizzaEntity dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public void Create(Order item)
        {
            _dbcontext.Orders.Add(item);
        }

        public void Delete(int id)
        {
            var item = _dbcontext.Orders.Find(id);
            if (item != null)
                _dbcontext.Orders.Remove(item);
        }

        public Order GetItem(int? id)
        {
            return _dbcontext.Orders.Find(id);
        }

        public List<Order> GetList()
        {
            return _dbcontext.Orders.ToList();
        }

        public void Update(Order item)
        {
            _dbcontext.Entry(item).State = System.Data.Entity.EntityState.Modified;
        }

        public bool IsSaved()
        {
            return _dbcontext.SaveChanges() > 0;
        }

        public Order GetLastRecord()
        {
            return _dbcontext.Orders.OrderByDescending(i => i.ID).FirstOrDefault();
        }
    }
}
