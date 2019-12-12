using System.Collections.Generic;

namespace BLL
{
    public interface IDBDataOperation
    {
        int AddNewCustomer(CustomerModel cust_model);
        void AddNewIngre(IngredientModel i);
        List<CustomerModel> GetAllCustomers();
        List<IngredientModel> GetAllIngres();
        List<OrderModel> GetAllOrders();
        List<PizzaModel> GetAllPizzas();
        List<ReceiptModel> GetAllReceipts();
        CustomerModel GetCustomer(int ID);
        IngredientModel GetIngredient(int ID);
        List<IngredientModel> GetIngreFromPizza(PizzaModel pizza);
        PizzaModel GetPizza(int ID);
        bool Save();
        bool UpdateIngre(IngredientModel i);
    }
}