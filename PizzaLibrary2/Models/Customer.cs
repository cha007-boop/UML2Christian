using PizzaLibrary.Interfaces;

namespace PizzaLibrary.Models
{
    public class Customer: ICustomer, IComparable<Customer>
    {
        #region Constants

        #endregion

        #region Static Fields
        private static int _counter = 1;
        #endregion

        #region Instance Fields
        private int _id;
        #endregion

        #region Constructors
        public Customer(string name, string mobile, string address, bool clubMember = false)
        {
            _id = _counter++;
            Name = name;
            Mobile = mobile;
            Address = address;
            ClubMember = clubMember;
        }
        #endregion

        #region Properties
        public string Name { get; set; }
        public string Mobile { get; set; }
        public string Address { get; set; }
        public bool ClubMember { get; set; }
        public int Id { get { return _id; } }

        public int CompareTo(Customer? otherCustomer)
        {
            if (otherCustomer is null)
                return 1;
            return Id.CompareTo(otherCustomer.Id);
        }
        #endregion

        #region Methods

        public override string ToString()
        {
            return $"{Id} {Name} {Mobile} {Address} Is{(ClubMember? " ": " not ")}a Club member";
        }
        #endregion
    }

}
