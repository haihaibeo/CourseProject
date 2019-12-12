using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DBReposSQL : IDatabaseRepository
    {
        private OrderPizzaEntity _db;
        private CustomerReposSQL customerReposSQL;
        private DetailReposSQL detailReposSQL;
        private IngredientReposSQL ingredientReposSQL;
        private OrderReposSQL orderReposSQL;
        private PizzaReposSQL pizzaReposSQL;
        private PizzaDetailReposSQL pizzaDetailReposSQL;
        private PizzaTypeReposSQL pizzaTypeReposSQL;
        private ReceiptReposSQL receiptReposSQL;
        private SizeReposSQL sizeReposSQL;

        public DBReposSQL(OrderPizzaEntity db)
        {
            this._db = db;
        }

        public IRepository<Customer> Customers
        {
            get
            {
                if (customerReposSQL == null) customerReposSQL = new CustomerReposSQL(_db);
                return customerReposSQL;
            }
        }

        public IRepository<Detail> Details
        {
            get
            {
                if (detailReposSQL == null) detailReposSQL = new DetailReposSQL(_db);
                return detailReposSQL;
            }
        }

        public IRepository<Ingredient> Ingredients
        {
            get
            {
                if (ingredientReposSQL == null) ingredientReposSQL = new IngredientReposSQL(_db);
                return ingredientReposSQL;
            }
        }

        public IRepository<Order> Orders
        {
            get
            {
                if (orderReposSQL == null) orderReposSQL = new OrderReposSQL(_db);
                return orderReposSQL;
            }
        }

        public IRepository<Pizza> Pizzas
        {
            get
            {
                if (pizzaReposSQL == null) pizzaReposSQL = new PizzaReposSQL(_db);
                return pizzaReposSQL;
            }
        }

        public IRepository<PizzaDetail> PizzaDetails
        {
            get
            {
                if (pizzaDetailReposSQL == null) pizzaDetailReposSQL = new PizzaDetailReposSQL(_db);
                return pizzaDetailReposSQL;
            }
        }

        public IRepository<PizzaType> PizzaTypes
        {
            get
            {
                if (pizzaTypeReposSQL == null) pizzaTypeReposSQL = new PizzaTypeReposSQL(_db);
                return pizzaTypeReposSQL;
            }
        }

        public IRepository<Receipt> Receipts
        {
            get
            {
                if (receiptReposSQL == null) receiptReposSQL = new ReceiptReposSQL(_db);
                return receiptReposSQL;
            }
        }

        public IRepository<Size> Sizes
        {
            get
            {
                if (sizeReposSQL == null) sizeReposSQL = new SizeReposSQL(_db);
                return sizeReposSQL;
            }
        }

        public int Save()
        {
            return _db.SaveChanges();
        }
    }
}
