using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaLibrary.Models
{
    public class Beverage : MenuItem
    {
        public Beverage(string name, double price, string description) 
            :base(name, price, description, MenuType.DRIKKEVARER)
        {
            Alcohol = false;
        }

        public bool Alcohol { get; set; }
    }
}
