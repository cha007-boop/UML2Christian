using PizzaLibrary.Interfaces;

namespace PizzaLibrary.Models
{
    public class MenuItem : IMenuItem
    {
        #region Constants

        #endregion

        #region Static Fields
        private static int _counter = 1;
        #endregion

        #region Instance Fields
        private int _no;
        #endregion

        #region Constructors
        public MenuItem(string name, double price, string description, MenuType menuType)
        {
            _no = _counter++;
            Name = name;
            Price = price;
            Description = description;
            TheMenuType = menuType;
        }
        #endregion

        #region Properties
        public string Name { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
        public int No { get { return _no; } }
        public MenuType TheMenuType { get; set; }
        #endregion

        #region Methods
        public override string ToString()
        {
            return $"{No} {Name} {Description} {Price} kr. {TheMenuType}";
        }
        #endregion
    }

}
