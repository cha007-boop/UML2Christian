using PizzaLibrary.Exceptions;
using PizzaLibrary.Helpers;
using PizzaLibrary.Interfaces;
using PizzaLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace PizzaLibrary.Services
{
    public class OrderRepository : IOrderRepository
    {
        private Dictionary<int, Order> _orders;

        public OrderRepository()
        {
            _orders = new Dictionary<int, Order>();
        }

        public void AddOrder(Order order)
        {
            if (_orders.ContainsKey(order.Id))
                throw new OrderIdExist($"order with Id {order.Id} already exists");
            else
                _orders.Add(order.Id, order);
        }

        public List<Order> GetAll()
        {
            return _orders.Values.ToList();
        }

        public Order? GetOrderById(int id)
        {
            return _orders.ContainsKey(id) ? _orders[id] : null;
        }

        public void PrintAllOrders()
        {
            Printer.PrintList(GetAll());
        }
        public void PrintAllOrdersSimple()
        {
            Printer.PrintList(GetAll().Select(o => o.SimpleInfo));
        }
        

        public void RemoveOrder(int id)
        {
            throw new NotImplementedException();
        }

        public void UpdateOrder(Order order)
        {
            throw new NotImplementedException();
        }
    }
}
