using ConsoleMenu.Helpers;
using PizzaLibrary.Interfaces;
using PizzaLibrary.Models;

namespace ConsoleMenu.Creators
{
    public class OrderCreator
    {
        private IMenuItemRepository _menuItemRepository;
        private ICustomerRepository _customerRepository;

        public IMenuItemRepository MenuItemRepository
        {
            get { return _menuItemRepository; }
            set { _menuItemRepository = value; }
        }
        public ICustomerRepository CustomerRepository
        {
            get { return _customerRepository; }
            set { _customerRepository = value; }
        }

        public OrderCreator(IMenuItemRepository menuItemRepository, ICustomerRepository customerRepository)
        {
            _menuItemRepository = menuItemRepository;
            _customerRepository = customerRepository;
        }

        public Order? Create()
        {
            bool guest = InputHandling.YesOrNo("Checkout as guest? ");
            Customer? customer = guest ? new Customer("Guest", "00000000", "", false) : InputHandling.Customer(_customerRepository);
            if (customer == null)
                return null;
            bool isDelivered = InputHandling.YesOrNo("Is the order delivered? ");
            Order newOrder = new Order(customer, isDelivered);

            bool selectingItems = true;
            while (selectingItems)
            {
                UpdateCheckoutView(newOrder);
                newOrder.AddMenuItem(InputHandling.MenuItem(_menuItemRepository), InputHandling.Amount());
                UpdateCheckoutView(newOrder);
                selectingItems = InputHandling.YesOrNo("Add more items? ");
            }
            Console.Clear();
            OrderSummary(newOrder);

            return newOrder;
        }
        private void UpdateCheckoutView(Order order)
        {
            Console.Clear();
            _menuItemRepository.PrintMenu();
            OrderSummary(order);
        }

        public void OrderSummary(Order? order)
        {
            Console.WriteLine("Order Summary:");
            Console.WriteLine(order);
        }

    }
}
