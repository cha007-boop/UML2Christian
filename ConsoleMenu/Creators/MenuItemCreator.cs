using ConsoleMenu.Helpers;
using PizzaLibrary.Models;

namespace ConsoleMenu.Creators
{
    public static class MenuItemCreator
    {
        public static MenuItem Create()
        {
            string name = InputHandling.RestrictedLengthString("Set name: ", 2);
            double price = InputHandling.Price();
            string description = InputHandling.RestrictedLengthString(name + " description: ", 5);
            MenuType menuType = InputHandling.MenuTypeFromInt();

            return new MenuItem(name, price, description, menuType);
        }
    }
}
