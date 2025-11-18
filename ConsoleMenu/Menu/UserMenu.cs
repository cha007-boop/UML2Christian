using ConsoleMenu.Controllers.Customers;
using ConsoleMenu.Controllers.MenuItems;
using ConsoleMenu.Controllers.Orders;
using ConsoleMenu.Helpers;
using PizzaLibrary.Services;

namespace ConsoleMenu.Menu
{
    public class UserMenu
    {
        private static string mainMenuChoices = "\t1.Menu" +
                                                "\n\t2.Customer" +
                                                "\n\t3.Order" +
                                                "\n\tQ.Quit" +
                                                "\n\n\tIndtast valg:";

        private static string customerMenuChoices = "\t1.Display Customers" +
                                                    "\n\t2.Add Customer" +
                                                    "\n\t3.Update Customer" +
                                                    "\n\tQ.Quit" +
                                                    "\n\n\tYour choice: ";

        private static string menuItemChoices = "\t1.Display Menu" +
                                                "\n\t2.Add MenuItem" +
                                                "\n\tQ.Quit" +
                                                "\n\n\tYour choice: ";

        private static string orderChoices = "\t1.Display Orders" +
                                                    "\n\t2.Display Order (input id)" +
                                                    "\n\t3.Create Order" +
                                                    "\n\tQ.Quit" +
                                                    "\n\n\tYour choice: ";

        private CustomerRepository _customerRepository = new CustomerRepository();
        private MenuItemRepository _menuItemRepository = new MenuItemRepository();
        private OrderRepository _orderRepository = new OrderRepository();
        private static string ReadChoice(string choices)
        {
            Console.Clear();
            Console.WriteLine("\x1b[3J");
            Console.Clear();
            Console.Write(choices);
            string choice = Console.ReadLine();
            Console.Clear();
            return choice.ToLower();
        }
        public void ShowMenu()
        {
            string theChoice = ReadChoice(mainMenuChoices);
            while (theChoice != "q")
            {
                switch (theChoice)
                {
                    case "1":
                        ShowMenuItemMenu();
                        break;
                    case "2":
                        ShowCustomerMenu();
                        break;
                    case "3":
                        ShowOrderMenu();
                        break;
                    default:
                        Console.WriteLine("Choose number from 1..3 or q to quit");
                        break;
                }
                theChoice = ReadChoice(mainMenuChoices);
            }
        }
        public void ShowMenuItemMenu()
        {
            string theChoice = ReadChoice(customerMenuChoices);
            while (theChoice != "q")
            {
                switch (theChoice)
                {
                    case "1":
                        Console.WriteLine("Choice 1");
                        ShowMenuItemController showMenuItemController = new ShowMenuItemController(_menuItemRepository);
                        showMenuItemController.ShowAllMenuItems();
                        Console.ReadLine();
                        break;
                    case "2":
                        Console.WriteLine("Choice 6");
                        AddMenuItemController addMenuItem = new AddMenuItemController(_menuItemRepository);
                        addMenuItem.AddMenuItem();
                        break;
                    default:
                        Console.WriteLine("Choose number from 1..2 or q to go back");
                        break;
                }
                theChoice = ReadChoice(customerMenuChoices);
            }
        }

        public void ShowCustomerMenu()
        {
            string theChoice = ReadChoice(menuItemChoices);
            while (theChoice != "q")
            {
                switch (theChoice)
                {
                    case "1":
                        Console.WriteLine("Choice 1");
                        _customerRepository.PrintAllCustomers();
                        Console.ReadLine();
                        break;
                    case "2":
                        Console.WriteLine("Choice 2");
                        AddCustomerController addCustomerController = new AddCustomerController(_customerRepository);
                        addCustomerController.AddCustomer();
                        break;
                    case "3":
                        Console.WriteLine("Choice 3");
                        UpdateCustomerController updater = new UpdateCustomerController(_customerRepository);
                        updater.UpdateCustomerInfo();
                        break;
                    default:
                        Console.WriteLine("Choose number from 1..3 or q to go back");
                        break;
                }
                theChoice = ReadChoice(menuItemChoices);
            }
        }
        public void ShowOrderMenu()
        {
            string theChoice = ReadChoice(orderChoices);
            while (theChoice != "q")
            {
                switch (theChoice)
                {
                    case "1":
                        Console.WriteLine("Choice 1");
                        _orderRepository.PrintAllOrdersSimple();
                        Console.ReadLine();
                        break;
                    case "2":
                        Console.WriteLine("Choice 2");
                        ShowOrderController showOrderController = new ShowOrderController(_orderRepository);
                        showOrderController.FindOrder();
                        Console.ReadLine();
                        break;
                    case "3":
                        Console.WriteLine("Choice 7");
                        AddOrderController addOrderController = new AddOrderController(_orderRepository, _menuItemRepository, _customerRepository);
                        addOrderController.AddOrder();
                        if (addOrderController.Order != null)
                            InputHandling.YesOrNo("Continue to checkout? ");
                        break;
                    default:
                        Console.WriteLine("Choose number from 1..3 or q to go back");
                        break;
                }
                theChoice = ReadChoice(orderChoices);
            }
        }
    }

}
