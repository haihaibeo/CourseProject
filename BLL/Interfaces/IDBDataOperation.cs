using System.Collections.Generic;

namespace BLL
{
    public interface IDBDataOperation
    {
        void AddNewIngre(IngredientModel i);
        void AddNewDetail(ref DetailModel detail);
        bool AddNewOrder(ref CustomerModel customer, ref List<PizzaDetailModel> carts);
        /// <summary>
        /// Delete user created pizza ONLY
        /// </summary>
        /// <param name="pizza_id"></param>
        void DeletePizzaUserCreated(int pizza_id);

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
        List<CategoryModel> GetAllCategories();
        List<IngredientModel> GetIngresInThisType(CategoryModel category);
        List<IngredientModel> GetIngresInThisType(int category_id);
        List<OrderModel> GetOrdersByCustomerID(int customer_id);
        List<StatusModel> GetAllStatus();
        List<PizzaDetailModel> GetAllPizzaDetails();

        CustomerModel GetCustomer(int ID);
        IngredientModel GetIngredient(int ID);
        SizeModel GetSize(int ID);
        float GetRatio(int Size_ID);
        PizzaModel GetPizza(int ID);
        DetailModel GetDetail(int ID);
        PizzaDetailModel GetCart(int ID);
        StatusModel GetStatus(int ID);
        PizzaDetailModel GetPizzaDetail(int ID);

        bool Save();
        bool UpdateIngre(IngredientModel i);
        bool MakeNewPizza(ref BLL.PizzaModel pz_m, List<BLL.IngredientModel> ingres);
    }
}