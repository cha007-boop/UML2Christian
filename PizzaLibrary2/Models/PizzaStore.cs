using PizzaLibrary.Services;
using PizzaLibrary.Helpers;

namespace PizzaLibrary.Models
{
    public class PizzaStore
    {
        #region Constants

        #endregion

        #region Static Fields

        #endregion

        #region Instance Fields
        MenuItemRepository _mRepo;
        CustomerRepository _cRepo;
        #endregion

        #region Constructors
        public PizzaStore()
        {
            _mRepo = new MenuItemRepository();
            _cRepo = new CustomerRepository();
        }
        #endregion

        #region Properties
        public MenuItemRepository Menu
        {
            get { return _mRepo; }
        }

        public CustomerRepository Customers
        {
            get { return _cRepo; }
        }
        #endregion

        #region Methods
        public void CreateOrder(Customer customer)
        {
            _mRepo.PrintMenu();
            Order order = new Order(customer, false);
            bool selectingItems = true;
            while (selectingItems)
            {
                order.AddMenuItem(Select.MenuItem(_mRepo), Select.Amount());
                Console.Write("Add more items? ");
                selectingItems = Select.YesOrNo();
            }
            Console.Write("Order is delivered? ");
            order.IsDelivered = Select.YesOrNo();

            Console.WriteLine("----------- Order summary -----------");
            Console.WriteLine(order);
            
        }
        #endregion
    }

}
