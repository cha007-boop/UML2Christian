using ConsoleMenu.Helpers;
using PizzaLibrary.Exceptions;
using PizzaLibrary.Interfaces;
using PizzaLibrary.Models;

namespace ConsoleMenu.Creators
{
    public static class CustomerCreator
    {
        public static Customer Create(ICustomerRepository customerRepository)
        {
            bool customerCreated = false;
            Customer customer = null;
            bool VIP = InputHandling.YesOrNo("Create as VIP? ");
            string customerName = InputHandling.RestrictedLengthString("Set customer name: ", 3);
            while (!customerCreated)
            {
                try
                {
                    string mobile = InputHandling.RestrictedLengthString("Set mobile number: ", 8, 8);
                    if (customerRepository.GetCustomerByMobile(mobile) != null)
                    {
                        throw new CustomerMobileNumberExist($"Customer with mobile {mobile} already exists.");
                    }
                    string address = InputHandling.RestrictedLengthString("Set address: ", 1);
                    if (VIP)
                    {
                        int discount = InputHandling.Discount();
                        customer = new VIPCustomer(customerName, mobile, address, discount);
                    }
                    else
                    {
                        bool isClubMember = InputHandling.YesOrNo("Wish to be a club member? ");
                        customer = new Customer(customerName, mobile, address, isClubMember);
                    }
                    customerCreated = true;
                }
                catch (CustomerMobileNumberExist cmne)
                {
                    Console.WriteLine(cmne.Message);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An error occurred while creating the customer: {ex.Message}");
                }
            }
            return customer;
        }
    }
}
