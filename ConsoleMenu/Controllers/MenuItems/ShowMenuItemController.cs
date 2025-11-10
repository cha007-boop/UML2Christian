using PizzaLibrary.Interfaces;

namespace ConsoleMenu.Controllers.MenuItems
{
    public class ShowMenuItemController
    {
        private IMenuItemRepository _menuItemRepository;
        public ShowMenuItemController(IMenuItemRepository menuItemRepository)
        {
            _menuItemRepository = menuItemRepository;
        }

        public void ShowAllMenuItems()
        {
            _menuItemRepository.PrintMenu();
        }
    }

}
