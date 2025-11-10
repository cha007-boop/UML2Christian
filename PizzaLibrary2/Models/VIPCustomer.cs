using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PizzaLibrary.Exceptions;

namespace PizzaLibrary.Models
{
    public class VIPCustomer : Customer
    {
        private int _discount;
        public VIPCustomer(string name, string mobile, string address, int discount)
            : base(name, mobile, address, true)
        {
            ValidationDiscount(discount);
            _discount = discount;
        }

        public int Discount
        {
            get { return _discount; }
            set
            {
                ValidationDiscount(value);
                _discount = value;
            }
        }

        public void ValidationDiscount(int discount)
        {
            switch (discount)
            {
                case < 1:
                    throw new TooLowDiscountException($"Discount must be at least 1, but was {discount}");
                case > 25:
                    throw new TooHighDiscountException($"Discount must be at most 25, but was {discount}");
                default:
                    break;
            }
        }

        public override string ToString()
        {
            return base.ToString() + $" VIP Customer with {Discount}% discount";
        }
    }
}
