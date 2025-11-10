using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaLibrary.Models
{
    public class CompanyInfo
    {
        // Singleton class for CompanyInfo
        private static CompanyInfo? _instance = null;
        private static readonly object _lock = new object();
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string City { get; set; }
        private CompanyInfo()
        {
            Name = "Default Pizza Company";
            Address = "123 Pizza St.";
            Phone = "555-1234";
            City = "Pizzatown";
        }
        public static CompanyInfo GetInstance()
        {
            if (_instance == null)
            {
                lock (_lock)
                {
                    if (_instance == null)
                    {
                        _instance = new CompanyInfo();
                    }
                }
            }
            return _instance;
        }

    }
}
