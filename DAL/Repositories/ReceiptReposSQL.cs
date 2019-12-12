
using System.Collections.Generic;
using System.Linq;

namespace DAL
{
    internal class ReceiptReposSQL : IRepository<Receipt>
    {
        private OrderPizzaEntity _dbcontext;

        public ReceiptReposSQL(OrderPizzaEntity dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public void Create(Receipt item)
        {
            _dbcontext.Receipts.Add(item);
        }

        public void Delete(int id)
        {
            var receipt = _dbcontext.Receipts.Find(id);
            if (receipt != null)
                _dbcontext.Receipts.Remove(receipt);
        }

        public Receipt GetItem(int? id)
        {
            return _dbcontext.Receipts.Find(id);
        }

        public List<Receipt> GetList()
        {
            return _dbcontext.Receipts.ToList();
        }

        public void Update(Receipt item)
        {
            _dbcontext.Entry(item).State = System.Data.Entity.EntityState.Modified;
        }

        public bool IsSaved()
        {
            return _dbcontext.SaveChanges() > 0;
        }
    }
}
