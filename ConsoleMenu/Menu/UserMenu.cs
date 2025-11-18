using ConsoleMenu.Controllers.Customers;
using ConsoleMenu.Controllers.MenuItems;
using ConsoleMenu.Controllers.Orders;
using ConsoleMenu.Helpers;
using PizzaLibrary.Services;

namespace ConsoleMenu.Menu
{
    public class UserMenu
    {
        private static string mainMenuChoices = "\t1.Display Menu" +
                                                "\n\t2.Customer" +
                                                "\n\t3.Display orders" +
                                                "\n\t4.Show order (input id)" +
                                                "\n\t5.Add MenuItem" +
                                                "\n\t6.Create order" +
                                                "\n\tQ.Quit" +
                                                "\n\n\tIndtast valg:";

        private static string customerMenuChoices = "\t1.Display Customers" +
                                                    "\n\t2.Add Customer" +
                                                    "\n\t3.Update Customer" +
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
                        Console.WriteLine("Choice 1");
                        ShowMenuItemController showMenuItemController = new ShowMenuItemController(_menuItemRepository);
                        showMenuItemController.ShowAllMenuItems();
                        Console.ReadLine();
                        break;
                    case "2":
                        ShowCustomerMenu();
                        break;
                    case "3":
                        Console.WriteLine("Choice 3");
                        _orderRepository.PrintAllOrdersSimple();
                        Console.ReadLine();
                        break;
                    case "4":
                        Console.WriteLine("Choice 4");
                        ShowOrderController showOrderController = new ShowOrderController(_orderRepository);
                        showOrderController.FindOrder();
                        Console.ReadLine();
                        break;
                    case "5":
                        Console.WriteLine("Choice 6");
                        AddMenuItemController addMenuItem = new AddMenuItemController(_menuItemRepository);
                        addMenuItem.AddMenuItem();
                        break;
                    case "6":
                        Console.WriteLine("Choice 7");
                        AddOrderController addOrderController = new AddOrderController(_orderRepository, _menuItemRepository, _customerRepository);
                        addOrderController.AddOrder();
                        if (addOrderController.Order != null)
                            InputHandling.YesOrNo("Continue to checkout? ");
                        break;

                    default:
                        Console.WriteLine("Choose number from 1..6 or q to quit");
                        break;
                }
                theChoice = ReadChoice(mainMenuChoices);
            }
        }
        public void ShowCustomerMenu()
        {
            string theChoice = ReadChoice(customerMenuChoices);
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
                theChoice = ReadChoice(customerMenuChoices);
            }
        }

    }

}
