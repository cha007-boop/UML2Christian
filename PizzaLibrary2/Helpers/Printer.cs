using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaLibrary.Helpers
{
    public static class Printer
    {
        public static void PrintList<T>(IEnumerable<T> list)
        {
            if (!list.Any())
            {
                Console.WriteLine("No items");
                return;
            }
            Console.WriteLine(string.Join("\n", list));
        }
    }
}
