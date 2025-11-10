using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaLibrary.Interfaces
{
    public interface IFilterCondition<in T>
    {
        bool Condition(T obj);
    }
}
