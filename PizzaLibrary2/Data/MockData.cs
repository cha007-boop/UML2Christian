using PizzaLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaLibrary.Data
{
    public static class MockData
    {
        #region Instance fields
        private static Dictionary<string, Customer> _customerData =
            new Dictionary<string, Customer>()
            {
            { "12121212", new Customer("Mikkel", "12121212", "Street 123") },
            { "13131313", new Customer("Charlotte", "13131313", "Avenue 321") },
            { "14141414", new Customer("Carina", "14141414", "High Street 234") },
            { "15151515", new Customer("Muhammed", "15151515", "North Street 345") },
            { "00000000", new Customer("Guest", "00000000", "Guest") }
            };

        private static List<MenuItem> _menuItemData =
            new List<MenuItem>()
            {
            new MenuItem("Margherita", 85, "Tomat, ost", MenuType.PIZZECLASSSICHE),
            new MenuItem("Vesuvio", 95, "Tomat, ost & skinke", MenuType.PIZZECLASSSICHE),
            new MenuItem("Capricciosa", 98, "Tomat, ost, skinke & champignon", MenuType.PIZZECLASSSICHE),
            new MenuItem("Calzone", 98, "Indbagt pizza med tomat, ost, skinke & champignon", MenuType.PIZZECLASSSICHE),
            new MenuItem("Quattro Stagioni", 98, "Tomat, ost, skinke, champignon, rejer & paprika", MenuType.PIZZECLASSSICHE),
            new MenuItem("Marinara", 97, "Tomat, ost, rejer, muslinger & hvidløg", MenuType.PIZZECLASSSICHE),
            new MenuItem("Vegetariana", 98, "Tomat, ost & grønsager", MenuType.PIZZECLASSSICHE),
            new MenuItem("Italiana", 97, "Tomat, ost, løg & kødsauce", MenuType.PIZZECLASSSICHE)

            };
        #endregion

        #region Properties
        public static Dictionary<string, Customer> CustomerData
        {
            get { return _customerData; }
        }


        public static List<MenuItem> MenuItemData
        {
            get { return _menuItemData; }
        }
        #endregion
    }
}
