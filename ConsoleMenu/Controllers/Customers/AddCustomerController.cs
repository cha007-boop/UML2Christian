using ConsoleMenu.Creators;
using PizzaLibrary.Interfaces;
using PizzaLibrary.Models;

namespace ConsoleMenu.Controllers.Customers
{
    public class AddCustomerController
    {
        private Customer _customer;
        private ICustomerRepository _customerRepository;
        public Customer Customer
        {
            get { return _customer; }
            set { _customer = value; }
        }

        public AddCustomerController(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;

            _customer = CustomerCreator.Create(_customerRepository);

        }

        public void AddCustomer()
        {
            _customerRepository.AddCustomer(Customer);
        }


    }

}
