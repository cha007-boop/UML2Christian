using PizzaLibrary.Models;
using PizzaLibrary.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaLibrary.Helpers
{
    public static class Select
    {
        public static MenuItem MenuItem(MenuItemRepository menu)
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
                        throw new ArgumentException($"Chosen no. is not on the menu");
                    choiceFinalized = true;
                }
                catch (ArgumentNullException anex)
                {
                    Console.WriteLine(anex.Message);
                }
                catch (FormatException)
                {
                    Console.WriteLine($"Input was not an integer");
                }
                catch (OverflowException oex)
                {
                    Console.WriteLine(oex.Message);
                }
                catch (ArgumentException aex)
                {
                    Console.WriteLine(aex.Message);
                }
            }
            return theMenuItem;
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
                catch (ArgumentNullException anex)
                {
                    Console.WriteLine(anex.Message);
                }
                catch (FormatException)
                {
                    Console.WriteLine($"Input was not an integer");
                }
                catch (OverflowException oex)
                {
                    Console.WriteLine(oex.Message);
                }
                catch (ArgumentException aex)
                {
                    Console.WriteLine(aex.Message);
                }
            }
            return amount;
        }
        public static bool YesOrNo()
        {
            string input = "";
            bool choiceFinalized = false;
            while (!choiceFinalized)
            {
                Console.Write("[ y / n ]: ");
                try
                {
                    input = Console.ReadLine();
                    if (input.ToLower() != "y" && input.ToLower() != "n")
                        throw new ArgumentException($"Input was not 'y' or 'n'");
                    choiceFinalized = true;
                }
                catch (ArgumentException aex)
                {
                    Console.WriteLine(aex.Message);
                }
            }
            return (input == "y");
        }
    }
}
