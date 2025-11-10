using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PizzaLibrary.Models;

namespace PizzaLibrary.Interfaces
{
    public interface IOrderRepository
    {
        List<Order> GetAll();
        void AddOrder(Order order);
        void UpdateOrder(Order order);
        Order? GetOrderById(int id);
        void RemoveOrder(int id);
        void PrintAllOrders();
        void PrintAllOrdersSimple();
    }
}
