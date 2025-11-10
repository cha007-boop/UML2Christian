using PizzaLibrary.Models;

namespace PizzaLibrary.Interfaces
{
    public interface IOrderLine
    {
        double TotalPrice { get; }

        void decreaseAmount();
        void increaseAmount();
        void SetAmount(int amount);
        void SetComment(string comment);
        void AddExtra(MenuItem menuItem);
        void RemoveExtra(MenuItem menuItem);
        void ClearExtra();
        string ToString();
    }
}