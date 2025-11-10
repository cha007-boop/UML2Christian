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
            Console.Write("Set name: ");
            string customerName = Console.ReadLine();
            while (!customerCreated)
            {
                try
                {
                    Console.Write("Set phone number: ");
                    string mobile = Console.ReadLine();
                    if (customerRepository.GetCustomerByMobile(mobile) != null)
                    {
                        throw new CustomerMobileNumberExist($"Customer with mobile {mobile} already exists.");
                    }
                    Console.Write("Set address: ");
                    string address = Console.ReadLine();
                    bool isClubMember = InputHandling.YesOrNo("Wish to be a club member? ");
                    customer = new Customer(customerName, mobile, address, isClubMember);
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
