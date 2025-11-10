using PizzaLibrary.Models;

namespace PizzaLibrary.Interfaces
{
    public interface IOrder
    {
        Customer Customer { get; }
        int Id { get; }
        bool IsDelivered { get; set; }
        List<OrderLine> OrderLines { get; }
        DateTime OrderTime { get; }
        double TotalPrice { get; }
    }
}