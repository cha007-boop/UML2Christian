
using PizzaLibrary.Data;
using PizzaLibrary.Helpers;
using PizzaLibrary.Interfaces;
using PizzaLibrary.Models;

namespace PizzaLibrary.Services
{
    public class MenuItemRepository : IMenuItemRepository
    {
        #region Constants

        #endregion

        #region Static Fields

        #endregion

        #region Instance Fields
        private List<MenuItem> _menuItemList;
        #endregion

        #region Constructors
        public MenuItemRepository()
        {
            _menuItemList = MockData.MenuItemData;
        }
        #endregion

        #region Properties
        public int Count
        {
            get { return _menuItemList.Count; }
        }
        #endregion

        #region Methods
        public void AddMenuItem(MenuItem menuItem)
        {
            _menuItemList.Add(menuItem);
        }

        public List<MenuItem> GetAll()
        {
            return _menuItemList;
        }

        public MenuItem? GetMenuItemByNo(int no)
        {
            //return _menuItemList.Find(m => m.No == no);

            foreach (MenuItem menuItem in _menuItemList)
            {
                if (menuItem.No == no)
                    return menuItem;
            }
            return null;
        }

        /// <summary>
        /// Prints all MenuItem objects in repository
        /// </summary>
        public void PrintAllMenuItems()
        {
            //Console.WriteLine(string.Join("\n", _menuItemList));
            //Printer.PrintList(_menuItemList);


            foreach(MenuItem menuItem in _menuItemList)
            {
                Console.WriteLine(menuItem);
            }
        }

        /// <summary>
        /// Removes a menu item identified by its unique number from the menu list.
        /// </summary>
        /// <remarks>If the menu item with the specified number does not exist, no action is
        /// taken.</remarks>
        /// <param name="no">The unique number of the menu item to be removed. Must be a valid number corresponding to an existing menu
        /// item.</param>
        public void RemoveMenuItem(int no)
        {
            //_menuItemList.RemoveAll(m => m.No == no);
            
            MenuItem? menuItemToRemove = GetMenuItemByNo(no);

            if (menuItemToRemove != null)
                _menuItemList.Remove(menuItemToRemove);
            
        }
        /// <summary>
        /// Displays the menu items grouped by their type.
        /// </summary>
        /// <remarks>Iterates through all available menu types and prints each type's header followed by
        /// its associated menu items.</remarks>
        public void PrintMenu()
        {
            foreach (MenuType menuType in Enum.GetValues<MenuType>())
            {
                Console.WriteLine($"\n----- {menuType} -----");
                List<MenuItem> itemsOfType = GetAllOfType(menuType);
                Printer.PrintList(itemsOfType);
            }
        }
        #endregion

        #region Get Methods
        public List<MenuItem> GetAllOfType(MenuType menuType)
        {
            return Filter.FilterObj(GetAll(), m => m.TheMenuType == menuType);
        }

        public List<MenuItem> GetMostExpensive(List<MenuItem> menuItems)
        {
            double highestPrice = menuItems.Select(m => m.Price).Max();

            return Filter.FilterObj(menuItems, m => m.Price == highestPrice);
        }
        
        public List<MenuItem> GetMostExpensiveOfMenuType(MenuType menuType)
        {
            List<MenuItem> allOfType = GetAllOfType(menuType);
            return GetMostExpensive(allOfType);
        }

        public List<MenuItem> GetMostExpensivePizza()
        {
            return GetMostExpensiveOfMenuType(MenuType.PIZZECLASSSICHE);
        }

        public List<MenuItem> GetInPriceRange(double min, double max)
        {
            return Filter.FilterObj(GetAll(), m => m.Price >= min && m.Price <= max);
        }
        #endregion
    }

}
