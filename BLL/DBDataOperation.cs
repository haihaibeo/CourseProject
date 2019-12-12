using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL
{
    public class DBDataOperation : IDBDataOperation
    {
        IDatabaseRepository db;
        public DBDataOperation(IDatabaseRepository db)
        {
            this.db = db;
        }

        public List<PizzaModel> GetAllPizzas()
            => db.Pizzas.GetList().Select(pizza => new PizzaModel(pizza)).ToList();

        public List<OrderModel> GetAllOrders()
            => db.Orders.GetList().Select(i => new OrderModel(i)).ToList();

        public List<IngredientModel> GetAllIngres()
            => db.Ingredients.GetList().Select(i => new IngredientModel(i)).ToList();

        public List<ReceiptModel> GetAllReceipts() 
            => db.Receipts.GetList().Select(i => new ReceiptModel(i)).ToList();

        public List<CustomerModel> GetAllCustomers() 
            => db.Customers.GetList().Select(i => new CustomerModel(i)).ToList();

        public PizzaModel GetPizza(int ID) 
            => new PizzaModel(db.Pizzas.GetItem(ID));

        public CustomerModel GetCustomer(int ID) 
            => new CustomerModel(db.Customers.GetItem(ID));

        public IngredientModel GetIngredient(int ID) 
            => new IngredientModel(db.Ingredients.GetItem(ID));

        public List<BLL.IngredientModel> GetIngreFromPizza(PizzaModel pizza)
        {
            var ingres = new List<IngredientModel>();
            List<ReceiptModel> rcs = this.GetAllReceipts();

            foreach (var i in rcs)
            {
                if (i.Pizza_ID == pizza.ID)
                    ingres.Add(this.GetIngredient(i.Ingredient_ID));
            }
            return ingres;
        }

        public int AddNewCustomer(CustomerModel cust_model)
        {
            int id = -1;
            try
            {
                Customer cust = new Customer()
                {
                    Address = cust_model.Address,
                    Name = cust_model.Name,
                    Phone = cust_model.Phone
                };
                db.Customers.Create(cust);
                db.Save();
                List<CustomerModel> allCust = this.GetAllCustomers();
                foreach (var i in allCust)
                {
                    if (i.Name == cust_model.Name
                        && i.Address == cust_model.Address
                        && i.Phone == cust_model.Phone)
                        return i.ID;
                }

            }
            catch
            {

            }
            return id;
        }

        public void AddNewIngre(IngredientModel i)
        {
            db.Ingredients.Create(new Ingredient()
            {
                Name = i.Name,
                Cost = i.Cost
            });
        }

        public bool UpdateIngre(IngredientModel i)
        {
            DAL.Ingredient ingre = db.Ingredients.GetItem(i.ID);
            ingre.Name = i.Name;
            ingre.Name = i.Name;
            if (Save()) return true;
            else return false;
        }

        public bool Save()
        {
            if (db.Save() > 0)
                return true;
            else return false;
        }
    }
}
