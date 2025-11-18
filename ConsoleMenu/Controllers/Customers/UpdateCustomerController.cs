using ConsoleMenu.Helpers;
using PizzaLibrary.Exceptions;
using PizzaLibrary.Interfaces;
using PizzaLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleMenu.Controllers.Customers
{
    public class UpdateCustomerController
    {
        private ICustomerRepository _customers;
        public UpdateCustomerController(ICustomerRepository customers)
        {
            _customers = customers;
        }

        public void UpdateCustomerInfo()
        {
            bool customerUpdated = false;
            while (!customerUpdated)
            {
                try
                {
                    string mobile = InputHandling.RestrictedLengthString("Enter mobile of customer to update: ", 8, 8);
                    Customer customerToUpdate = _customers.GetCustomerByMobile(mobile);
                    if (customerToUpdate == null)
                        throw new CustomerDoesNotExist("No customer found.");

                    Console.WriteLine("Leave input blank for no change");
                    Console.Write("Name: ");
                    string updatedName = Console.ReadLine() ?? customerToUpdate.Name;

                    Console.Write("Address: ");
                    string updatedAddress = Console.ReadLine() ?? customerToUpdate.Address;
                    
                    bool clubMember = InputHandling.YesOrNo("Club member?");

                    Console.Write("Mobile: ");
                    string updatedMobile = Console.ReadLine() ?? customerToUpdate.Mobile;

                    _customers.UpdateCustomerInfo(mobile, updatedName, updatedAddress, clubMember, updatedMobile);
                    customerUpdated = true;

                }
                catch (CustomerDoesNotExist cdnex)
                {
                    Console.WriteLine(cdnex.Message);
                }
            }
        }
    }
}
