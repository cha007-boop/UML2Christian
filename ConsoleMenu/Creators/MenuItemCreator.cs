using ConsoleMenu.Helpers;
using PizzaLibrary.Models;

namespace ConsoleMenu.Creators
{
    public static class MenuItemCreator
    {
        public static MenuItem Create()
        {
            Console.Write("Set name: ");
            string pizzaName = Console.ReadLine();
            double pizzaPrice = InputHandling.Price();
            Console.WriteLine("Set description");
            string pizzaDescription = Console.ReadLine();
            MenuType menuType = InputHandling.MenuTypeFromInt();

            return new MenuItem(pizzaName, pizzaPrice, pizzaDescription, menuType);
        }
    }
}
