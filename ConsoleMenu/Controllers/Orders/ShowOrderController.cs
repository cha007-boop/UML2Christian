using ConsoleMenu.Helpers;
using PizzaLibrary.Interfaces;
using PizzaLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleMenu.Controllers.Orders
{
    public class ShowOrderController
    {
        private IOrderRepository _orderRepository;
        public ShowOrderController(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public void ShowAllOrders()
        {
            _orderRepository.PrintAllOrdersSimple();
        }

        public Order? FindOrder()
        {
            Order? order = InputHandling.Order(_orderRepository);
            if (order != null)
            {
                Console.WriteLine(order);
            }
            return order;
        }
    }
}
