using ConsoleMenu.Creators;
using PizzaLibrary.Interfaces;
using PizzaLibrary.Models;

namespace ConsoleMenu.Controllers.MenuItems
{
    public class AddMenuItemController
    {
        private IMenuItemRepository _menuItemRepository;
        public MenuItem MenuItem { get; set; }
        public AddMenuItemController(IMenuItemRepository menuItemRepository)
        {
            MenuItem = MenuItemCreator.Create();
            _menuItemRepository = menuItemRepository;
        }

        public void AddMenuItem()
        {
            _menuItemRepository.AddMenuItem(MenuItem);
        }

    }
}
