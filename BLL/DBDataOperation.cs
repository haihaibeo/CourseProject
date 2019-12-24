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

        public List<SizeModel> GetAllSize()
        {
            return db.Sizes.GetList().Select(i => new SizeModel(i)).ToList();
        }

        public PizzaModel GetPizza(int ID)
            => new PizzaModel(db.Pizzas.GetItem(ID));

        public CustomerModel GetCustomer(int ID)
            => new CustomerModel(db.Customers.GetItem(ID));

        public IngredientModel GetIngredient(int ID)
            => new IngredientModel(db.Ingredients.GetItem(ID));

        public StatusModel GetStatus(int ID)
            => new StatusModel(db.Status.GetItem(ID));

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

        public List<BLL.IngredientModel> GetIngreFromPizza(int pizza_id)
        {
            var ingres = new List<IngredientModel>();
            List<ReceiptModel> rcs = this.GetAllReceipts();

            foreach (var i in rcs)
            {
                if (i.Pizza_ID == pizza_id)
                    ingres.Add(this.GetIngredient(i.Ingredient_ID));
            }
            return ingres;
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

        public float GetRatio(int Size_ID)
        {
            return GetSize(Size_ID).Ratio;
        }

        public SizeModel GetSize(int ID)
        {
            return new SizeModel(db.Sizes.GetItem(ID));
        }

        public List<DetailModel> GetAllDetails()
        {
            return db.Details.GetList().Select(i => new DetailModel(i)).ToList();
        }

        public List<PizzaDetailModel> GetAllCarts()
        {
            return db.PizzaDetails.GetList().Select(i => new PizzaDetailModel(i)).ToList();
        }

        public DetailModel GetDetail(int ID)
        {
            return new DetailModel(db.Details.GetItem(ID));
        }

        public PizzaDetailModel GetCart(int ID)
        {
            return new PizzaDetailModel(db.PizzaDetails.GetItem(ID));
        }

        public List<CategoryModel> GetAllCategories()
        {
            return db.Categories.GetList().Select(i => new CategoryModel(i)).ToList();
        }

        public List<IngredientModel> GetIngresInThisType(CategoryModel category)
        {
            return GetIngresInThisType(category.ID);
        }

        public List<IngredientModel> GetIngresInThisType(int category_id)
        {
            var AllIngres = GetAllIngres();
            List<IngredientModel> IngresInThisType = new List<IngredientModel>();

            foreach(var ingre in AllIngres)
            {
                if (ingre.Category_ID == category_id)
                    IngresInThisType.Add(ingre);
            }
            return IngresInThisType;
        }

        public List<OrderModel> GetOrdersByCustomerID(int customer_id)
        {
            var customer = GetCustomer(customer_id);
            var orders = new List<OrderModel>();
            foreach (var item in GetAllOrders())
            {
                if (item.Customer_ID == customer.ID)
                    orders.Add(item);
            }
            return orders;
        }

        public bool MakeNewPizza(ref BLL.PizzaModel pz_m, List<BLL.IngredientModel> ingres)
        {
            try
            {
                DAL.Pizza pz = new DAL.Pizza();
                pz.Name = pz_m.Name;
                pz.Price = pz_m.Price;
                pz.PizzaType_ID = 2;

                db.Pizzas.Create(pz);
                db.Save();
                pz_m = new PizzaModel(db.Pizzas.GetLastRecord());

                foreach(var ingre in ingres)
                {
                    Receipt rc = new Receipt();
                    rc.Pizza_ID = pz_m.ID;
                    rc.Ingredient_ID = ingre.ID;
                    db.Receipts.Create(rc);
                }
            }
            catch { }

            if (db.Save() > 0) return true;
            else return false;
        }

        public void DeletePizzaUserCreated(int id)
        {
            var pizza = GetPizza(id);
            if (pizza.PizzaType_ID == 1)
                return;
         
            foreach(var item in GetAllReceipts())
            {
                if (item.Pizza_ID == pizza.ID)
                    db.Receipts.Delete(item.ID);
            }
            db.Pizzas.Delete(pizza.ID);
        }

        public bool AddNewOrder(ref CustomerModel customer,ref List<PizzaDetailModel> carts)
        {
            Customer cust = new Customer()
            {
                Name = customer.Name,
                Address = customer.Address,
                Phone = customer.Phone
            };
            db.Customers.Create(cust);
            if (Save() == false) return false;
            customer.ID = new CustomerModel(db.Customers.GetLastRecord()).ID;

            Order order = new Order();

            foreach (var item in carts)
            {
                PizzaDetail pd = new PizzaDetail()
                {
                    Detail_ID = item.Detail_ID,
                    Pizza_ID = item.Pizza_ID,
                };
                db.PizzaDetails.Create(pd);
                if (Save() == false) return false;
                item.ID = new PizzaDetailModel(db.PizzaDetails.GetLastRecord()).ID;
                order.PizzaDetail_ID = item.ID;
                order.Customer_ID = customer.ID;
                order.TotalPriceOrder = item.TotalPrice;
                order.Status_ID = 1;
                db.Orders.Create(order);
                if(!Save()) return false;
            }
            return true;
        }

        public void AddNewDetail(ref BLL.DetailModel detail)
        {
            List<DetailModel> details = new List<DetailModel>(GetAllDetails());
            foreach (var item in details)
            {
                if (item.Quantity == detail.Quantity && item.Size_ID == detail.Size_ID)
                {
                    detail.ID = item.ID;
                    return;
                }

            }
            Detail dt = new Detail()
            {
                Size_ID = detail.Size_ID,
                Quantity = detail.Quantity,
            };
            db.Details.Create(dt);
            db.Save();
            detail = new BLL.DetailModel(db.Details.GetLastRecord());
        }

        public List<StatusModel> GetAllStatus()
        {
            return db.Status.GetList().Select(i => new StatusModel(i)).ToList();
        }

        public PizzaDetailModel GetPizzaDetail(int ID)
        {
            return new PizzaDetailModel(db.PizzaDetails.GetItem(ID));
        }

        public List<PizzaDetailModel> GetAllPizzaDetails()
        {
            return db.PizzaDetails.GetList().Select(i => new PizzaDetailModel(i)).ToList();
        }
    }
}
