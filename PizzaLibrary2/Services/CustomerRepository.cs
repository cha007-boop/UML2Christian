using PizzaLibrary.Data;
using PizzaLibrary.Exceptions;
using PizzaLibrary.Helpers;
using PizzaLibrary.Interfaces;
using PizzaLibrary.Models;
using System.Reflection;

namespace PizzaLibrary.Services
{
    public class CustomerRepository : ICustomerRepository
    {
        #region Constants

        #endregion

        #region Static Fields

        #endregion

        #region Instance Fields
        private Dictionary<string, Customer> _customers;
        #endregion

        #region Constructors
        public CustomerRepository()
        {
            _customers = MockData.CustomerData;
        }
        #endregion

        #region Properties
        public int Count
        {
            get { return _customers.Count; }
        }

        #endregion

        #region Methods
        public void AddCustomer(Customer customer)
        {
            if (_customers.ContainsKey(customer.Mobile))
                throw new CustomerMobileNumberExist($"Customer with phone number {customer.Mobile} already exists");
            else
                _customers.Add(customer.Mobile, customer);
        }

        public List<Customer> GetAll()
        {
            return _customers.Values.ToList();
        }

        public Customer? GetCustomerByMobile(string mobile)
        {
            return _customers.ContainsKey(mobile) ? _customers[mobile] : null;
        }

        public void PrintAllCustomers()
        {
            foreach (Customer customer in GetAll())
            {
                Console.WriteLine(customer);
            }
        }

        public void RemoveCustomer(string mobile)
        {
            _customers.Remove(mobile);
        }

        public void UpdateCustomerInfo(string mobile, string name, string address, string newMobile, bool clubMember)
        {
            if (_customers.ContainsKey(mobile))
            {
                _customers[mobile].Name = name;
                _customers[mobile].Address = address;
                _customers[mobile].ClubMember = clubMember;
                if (mobile != newMobile)
                {
                    _customers[mobile].Mobile = newMobile;
                    AddCustomer(_customers[mobile]);
                    RemoveCustomer(mobile);
                }
            }
            else
            {
                throw new CustomerDoesNotExist($"Customer with mobile number {mobile} not found.");
            }
        }
        #endregion

        #region Get methods

        public List<Customer> GetAllMembers()
        {   
            return Filter.FilterObj(GetAll(),new ClubMember());
            //return Filter.FilterObj(GetAll(), c => c.ClubMember);
        }
        
        public List<Customer> GetAllAddressMatch(string address)
        {
            return Filter.FilterObj(GetAll(),c => c.Address.ToLower().Contains(address.ToLower()));
        }
        #endregion
    }

}
