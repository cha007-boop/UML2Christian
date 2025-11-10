using ConsoleMenu.Creators;
using ConsoleMenu.Helpers;
using PizzaLibrary.Interfaces;
using PizzaLibrary.Models;

namespace ConsoleMenu.Controllers.Orders
{
    public class AddOrderController
    {
        private IOrderRepository _orderRepository;
        private Order? _order;
        private OrderCreator _orderCreator;
        public Order? Order
        {
            get { return _order; }
            set { _order = value; }
        }

        public AddOrderController(IOrderRepository orderRepository,
                                  IMenuItemRepository menuItemRepository,
                                  ICustomerRepository customerRepository)
        {
            _orderRepository = orderRepository;
            _orderCreator = new OrderCreator(menuItemRepository, customerRepository);
            _order = _orderCreator.Create();
        }

        public void AddOrder()
        {
            Console.Clear();
            _orderCreator.OrderSummary(Order);
            if (Order == null)
            {
                Console.WriteLine("Order creation cancelled.");
                return;
            }
            bool addOrder = InputHandling.YesOrNo("Add order to the system? ");
            if (addOrder)
                _orderRepository.AddOrder(Order);
        }
    }
}
