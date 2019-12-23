using System.Collections.Generic;

namespace BLL
{
    public interface IDBDataOperation
    {
        int AddNewCustomer(CustomerModel cust_model);
        void AddNewIngre(IngredientModel i);
        int AddNewCart(DetailModel dt, int pizza_id);
        int AddNewDetail(DetailModel dt);
        void AddNewOrder(int pizza_id, int customer_id, decimal total);

        List<CustomerModel> GetAllCustomers();
        List<IngredientModel> GetAllIngres();
        List<OrderModel> GetAllOrders();
        List<PizzaModel> GetAllPizzas();
        List<ReceiptModel> GetAllReceipts();
        List<SizeModel> GetAllSize();
        List<DetailModel> GetAllDetails();
        List<IngredientModel> GetIngreFromPizza(PizzaModel pizza);
        List<IngredientModel> GetIngreFromPizza(int pizza_id);
        List<PizzaDetailModel> GetAllCarts();
        List<CategoryModel> GetCategories();

        CustomerModel GetCustomer(int ID);
        IngredientModel GetIngredient(int ID);
        SizeModel GetSize(int ID);
        float GetRatio(int Size_ID);
        PizzaModel GetPizza(int ID);
        DetailModel GetDetail(int ID);
        PizzaDetailModel GetCart(int ID);

        bool Save();
        bool UpdateIngre(IngredientModel i);
    }
}