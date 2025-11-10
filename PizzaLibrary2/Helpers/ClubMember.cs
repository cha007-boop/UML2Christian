using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PizzaLibrary.Interfaces;
using PizzaLibrary.Models;

namespace PizzaLibrary.Helpers
{
    public class ClubMember : IFilterCondition<Customer>
    {
        public bool Condition(Customer customer)
        {
            return customer.ClubMember;
        }
    }
}
