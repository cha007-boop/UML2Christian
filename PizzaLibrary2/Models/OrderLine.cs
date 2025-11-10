using PizzaLibrary.Interfaces;

namespace PizzaLibrary.Models
{
    public class OrderLine : IOrderLine
    {
        #region Constants

        #endregion

        #region Static Fields

        #endregion

        #region Instance Fields
        private MenuItem _menuItem;
        private int _amount;
        private string _comment;
        private List<MenuItem> _extras;
        #endregion

        #region Constructors
        public OrderLine(MenuItem menuItem, int amount, string comment = "")
        {
            _menuItem = menuItem;
            _amount = amount;
            _comment = comment;
            _extras = new List<MenuItem>();
        }
        #endregion

        #region Properties
        public double TotalPrice
        {
            get
            {
                double totalPrice = _menuItem.Price;
                foreach (MenuItem extra in _extras)
                {
                    totalPrice += extra.Price;
                }
                totalPrice *= _amount;
                return totalPrice;
            }
        }
        private string ExtrasString
        {
            get { return string.Join(", ", _extras.Select(extra => extra.ToString())); }
        }
        #endregion

        #region Methods
        public void SetComment(string comment)
        {
            _comment = comment;
        }
        public void SetAmount(int amount)
        {
            _amount = amount;
            if (_amount < 0)
                _amount = 0;
        }
        public void increaseAmount()
        {
            _amount++;
        }
        public void decreaseAmount()
        {
            if (_amount - 1 >= 0)
            {
                _amount--;
            }

        }
        public void AddExtra(MenuItem extra)
        {
            if (extra.TheMenuType == MenuType.TILBEHØR)
                _extras.Add(extra);
        }
        public void RemoveExtra(MenuItem extra)
        {
            if (_extras.Contains(extra))
                _extras.Remove(extra);
        }
        public void ClearExtra()
        {
            _extras.Clear();
        }

        public override string ToString()
        {
            return $"{_amount} stk. {_menuItem} {(_comment.Length > 0 ? "comment: " + _comment : "")}" +
                   $"{(_extras.Count > 0 ? "\nExtra toppings: " + ExtrasString + "\n" : "\n")}" +
                   $"Total price: {TotalPrice} kr.";
        }
        #endregion
    }

}
