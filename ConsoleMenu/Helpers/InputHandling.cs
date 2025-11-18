using ConsoleMenu.Controllers.Customers;
using PizzaLibrary.Exceptions;
using PizzaLibrary.Interfaces;
using PizzaLibrary.Models;

namespace ConsoleMenu.Helpers
{
    public static class InputHandling
    {
        private static string customerMenuChoices = "\t1.Try again" +
                                                    "\n\t2.Create new Customer" +
                                                    "\n\t3.Continue as guest" +
                                                    "\n\tQ.To quit" +
                                                    "\n\n\tChoose 1..3 or q to quit: ";

        private static string ReadChoice(string choices, string message)
        {
            Console.Clear();
            Console.WriteLine(message);
            Console.Write(choices);
            string choice = Console.ReadLine();
            Console.Clear();
            return choice.ToLower();
        }

        public static MenuItem? MenuItem(IMenuItemRepository menu)
        {
            MenuItem? theMenuItem = null;
            bool choiceFinalized = false;
            while (!choiceFinalized)
            {
                Console.Write("Select Menu Item no: ");
                try
                {
                    int chosenNumber = int.Parse(Console.ReadLine());
                    theMenuItem = menu.GetMenuItemByNo(chosenNumber);
                    if (theMenuItem == null)
                        throw new Exception();
                    choiceFinalized = true;
                }
                catch (Exception)
                {
                    Console.WriteLine($"No Menu Item found for input");
                    choiceFinalized = !YesOrNo("Try again? ");
                }
            }
            return theMenuItem;
        }
        public static Order? Order(IOrderRepository orders)
        {
            Order? theOrder = null;
            bool choiceFinalized = false;
            while (!choiceFinalized)
            {
                Console.Write("Select Order no: ");
                try
                {
                    int chosenNumber = int.Parse(Console.ReadLine());
                    theOrder = orders.GetOrderById(chosenNumber);
                    if (theOrder == null)
                        throw new Exception();
                    choiceFinalized = true;
                }
                catch (Exception)
                {
                    Console.WriteLine($"No Order found for input");
                    choiceFinalized = !YesOrNo("Try again? ");
                    theOrder = null;
                }
            }
            return theOrder;
        }

        public static int Amount()
        {
            int amount = 0;
            bool choiceFinalized = false;
            while (!choiceFinalized)
            {
                Console.Write("Select amount: ");
                try
                {
                    amount = int.Parse(Console.ReadLine());
                    if (amount < 1)
                        throw new ArgumentException($"Amount must be at least 1");
                    choiceFinalized = true;
                }
                catch (ArgumentException aex)
                {
                    Console.WriteLine(aex.Message);
                }
                catch (Exception)
                {
                    Console.WriteLine($"Input was not valid");
                }
            }
            return amount;
        }

        public static double Price()
        {
            double price = 0;
            bool choiceFinalized = false;
            while (!choiceFinalized)
            {
                Console.Write("Select price: ");
                try
                {
                    price = double.Parse(Console.ReadLine());
                    if (price <= 0)
                        throw new ArgumentException($"Price must be greater than 0");
                    choiceFinalized = true;
                }
                catch (ArgumentException aex)
                {
                    Console.WriteLine(aex.Message);
                }
                catch (Exception)
                {
                    Console.WriteLine($"Input was not valid");
                }
            }
            return price;
        }

        public static int Discount()
        {
            int discount = 0;
            bool validDiscount = false;
            while (!validDiscount)
            {
                Console.Write("Select VIP discount: ");
                try
                {
                    discount = int.Parse(Console.ReadLine());
                    if (discount < 1)
                        throw new TooLowDiscountException("Discount must be at least 1");
                    else if (discount > 25)
                        throw new TooHighDiscountException("Discount must at most 25");
                    validDiscount = true;
                }
                catch (TooLowDiscountException tldex)
                {
                    Console.WriteLine(tldex.Message);
                }
                catch (TooHighDiscountException thdex)
                {
                    Console.WriteLine(thdex.Message);
                }
                catch (Exception)
                {
                    Console.WriteLine("Input must be an integer in the range 1..25");
                }
            }
            return discount;
        }
        public static string RestrictedLengthString(string prompt, int minLength, int maxLength = 400)
        {
            string input = "";
            bool validString = false;
            while (!validString)
            {
                Console.Write(prompt);
                try
                {
                    input = Console.ReadLine();
                    if (input.Length < minLength)
                        throw new ArgumentException($"Input must be at least {minLength} characters long");
                    if (input.Length > maxLength)
                        throw new ArgumentException($"Input must be at most {maxLength} characters long");
                    validString = true;
                }
                catch (ArgumentException aex)
                {
                    Console.WriteLine(aex.Message);
                }
                catch (Exception)
                {
                    Console.WriteLine("Input was not valid");
                }
            }
            return input;
        }

        public static MenuType MenuTypeFromInt()
        {
            MenuType menuType = MenuType.PIZZECLASSSICHE; // Value to be overwritten
            MenuType[] menuTypes = Enum.GetValues<MenuType>();
            bool choiceFinalized = false;
            string menuTypesString = "";
            foreach (MenuType menuTypeEnum in menuTypes)
            {
                menuTypesString += $"\t{(int)menuTypeEnum + 1}. {menuTypeEnum}\n";
            }
            while (!choiceFinalized)
            {
                Console.WriteLine("Menu types:");
                Console.WriteLine(menuTypesString);
                Console.Write("Select Menu Type by number: ");
                try
                {
                    int input = int.Parse(Console.ReadLine());
                    if (input < 1 || input > menuTypes.Length)
                    {
                        Console.Clear();
                        throw new ArgumentException($"Input must be between 1 and {menuTypes.Length}");
                    }
                    menuType = menuTypes[input - 1];
                    choiceFinalized = true;
                }
                catch (ArgumentException aex)
                {
                    Console.WriteLine(aex.Message);
                }
                catch (Exception)
                {
                    Console.Clear();
                    Console.WriteLine($"Input was not valid");
                }
            }
            return menuType;
        }

        public static Customer? Customer(ICustomerRepository customers)
        {
            Customer? theCustomer = null;
            bool choiceFinalized = false;
            while (!choiceFinalized)
            {
                Console.Write("Select customer by mobile: ");
                try
                {
                    string mobile = Console.ReadLine();
                    theCustomer = customers.GetCustomerByMobile(mobile);
                    if (theCustomer == null)
                        throw new CustomerDoesNotExist("No Customers found for input");
                    choiceFinalized = true;
                }
                catch (Exception ex)
                {
                    //Console.WriteLine(ex.Message);
                    string choice = ReadChoice(customerMenuChoices, ex.Message);
                    while (choice != "q" && !choiceFinalized)
                    {
                        switch (choice)
                        {
                            case "1":
                                Customer(customers);
                                break;
                            case "2":
                                AddCustomerController addCustomerController = new AddCustomerController(customers);
                                addCustomerController.AddCustomer();
                                theCustomer = addCustomerController.Customer;
                                choiceFinalized = true;
                                break;
                            case "3":
                                theCustomer = new Customer("Guest", "00000000", "", false);
                                choiceFinalized = true;
                                break;
                            default:
                                Console.WriteLine("Choose number from 1..3 or q to quit: ");
                                break;

                        }
                    }
                    choiceFinalized = true;
                }
            }
            return theCustomer;
        }

        public static bool YesOrNo(string question)
        {
            string input = "";
            bool choiceFinalized = false;
            while (!choiceFinalized)
            {
                Console.Write($"{question} [ y / n ]: ");
                try
                {
                    input = Console.ReadLine().ToLower();
                    if (input[0] != 'y' && input[0] != 'n')
                        throw new ArgumentException($"Input was not 'y' or 'n'");
                    choiceFinalized = true;
                }
                catch (ArgumentException aex)
                {
                    Console.WriteLine(aex.Message);
                }
                catch (Exception)
                {
                    Console.WriteLine("Input was not valid");
                }
            }
            return input[0] == 'y';
        }
        public static string UpdateInfo(string oldInfo)
        {
            string newInfo = Console.ReadLine();
            return newInfo.Length == 0 ? oldInfo : newInfo;
        }
    }
}