using PizzaLibrary.Interfaces;

namespace PizzaLibrary.Models
{
    public class Order : IOrder
    {
        #region Constants
        private const int DeliveryFee = 40;
        private const double VAT = 0.25;
        #endregion

        #region Static Fields
        private static int _nextId = 1;
        #endregion

        #region Instance Fields
        private int _deliveryFee;
        #endregion

        #region Constructors
        public Order(Customer customer, bool isDelivered)
        {
            Id = _nextId++;
            Customer = customer;
            OrderTime = DateTime.Now;
            IsDelivered = isDelivered;
            OrderLines = new List<OrderLine>();
            _deliveryFee = IsDelivered ? DeliveryFee : 0;
        }
        #endregion

        #region Properties
        public int Id { get; }

        public List<OrderLine> OrderLines { get; }

        public Customer Customer { get; }
        public DateTime OrderTime { get; }
        public bool IsDelivered { get; set; }
        public string SimpleInfo
        {
            get { return $"{Id}\t{Customer.Name}\t{TotalPrice} kr.";}
        }
        public double TotalPrice
        {
            get
            {
                double total = 0;
                foreach (OrderLine orderLine in OrderLines)
                {
                    total += orderLine.TotalPrice;
                }
                total *= 1 + VAT;
                if (IsDelivered)
                {
                    total += DeliveryFee;
                }
                return total;
            }
        }
        #endregion

        #region Methods
        public void AddMenuItem(MenuItem menuItem, int amount = 1, string comment = "")
        {
            OrderLine orderLine = new OrderLine(menuItem, amount, comment);
            OrderLines.Add(orderLine);
        }

        public override string ToString()
        {
            string orderLines = "";
            foreach (OrderLine oLine in OrderLines)
            {
                orderLines += oLine + "\n";
            }


            return $"Ordernumber: {Id} is ordered {OrderTime}\n" +
                   $"by {Customer}\n" +
                   $"Order contains:\n" +
                   $"{orderLines}" +
                   $"\nThe total price including VAT is {TotalPrice} kr.\n" +
                   $"The order is{(IsDelivered ? "" : " not")} delivered";
        }
        #endregion
    }

}
