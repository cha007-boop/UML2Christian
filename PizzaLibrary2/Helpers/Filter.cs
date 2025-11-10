using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PizzaLibrary.Interfaces;

namespace PizzaLibrary.Helpers
{
    public static class Filter
    {
        public static List<T> FilterObj<T>(List<T> objects, IFilterCondition<T> condition)
        {
            List<T> filteredObj = new List<T>();
            foreach (T obj in objects)
            {
                if (condition.Condition(obj))
                    filteredObj.Add(obj);
            }
            return filteredObj;
        }

        public static List<T> FilterObj<T>(List<T> objects, Func<T, bool> condition)
        {
            List<T> filteredObj = new List<T>();
            foreach (T obj in objects)
            {
                if (condition(obj))
                    filteredObj.Add(obj);
            }

            return filteredObj;
        }
    }
}
