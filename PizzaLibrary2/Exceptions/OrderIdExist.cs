using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaLibrary.Exceptions
{
    public class OrderIdExist : Exception
    {
        public OrderIdExist(string message)
            : base(message)
        {
        }
    }
}
