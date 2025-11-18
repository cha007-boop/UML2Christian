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
        private CompanyInfo()
        {
            Name = "Big Mamma";
            Address = "Frederiksværksgade 4 3400 Hillerød";
            Phone = "40 12 40 03";
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
