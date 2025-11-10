using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaLibrary.Helpers
{
    public static class UserInput
    {
        public static int Int()
        {
            string input = Console.ReadLine();
            int no = int.Parse(input);
            return no;
        }


    }
}
