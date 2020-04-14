using System;
using System.Collections.Generic;

namespace ObserverDesignPatternConsole
{
      interface IMarket
    {
        void Update(Product product);
    } 
    abstract class Product
    {
        private double price;
        List<IMarket> Markets = new List<IMarket>();
        public Product(double _price)
        {
            price = _price;
        }
        public void Attach(IMarket market)
        {
            Markets.Add(market);
        }
        public void Deattach(IMarket market)
        {
            Markets.Remove(market);
        }
        public void Notify()
        {
            foreach (IMarket market in Markets)
            {
                market.Update(this);
            }
            Console.WriteLine("");
        }
        public double priceperpound
        {
            get { return price; }
            set
            {
                if (price != value)
                    price = value;
                Notify();
            }
        }

    }


    class Chocolate : Product
    {
        public Chocolate(double price) : base(price) { }
    }
    class Market : IMarket
    {
        private string Name;
        private double price;
        public Market(string _Name,double _price)
        {
            Name = _Name;
            price = _price;
        }
        public void Update(Product product)
        {
            Console.WriteLine("Notify: In " + Name + " the price of " + product.GetType().Name +
                "was changed with " + product.priceperpound);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Chocolate chocolate = new Chocolate(2);
            chocolate.Attach(new Market("Market1", 1));
            chocolate.Attach(new Market("Market2", 2));
            chocolate.Attach(new Market("Market3", 3));
            chocolate.Attach(new Market("Market4", 4));
            chocolate.priceperpound = 5;
            chocolate.priceperpound = 6;
            chocolate.priceperpound = 7;
            chocolate.priceperpound = 8;
            Console.ReadKey();
        }
    }
}
