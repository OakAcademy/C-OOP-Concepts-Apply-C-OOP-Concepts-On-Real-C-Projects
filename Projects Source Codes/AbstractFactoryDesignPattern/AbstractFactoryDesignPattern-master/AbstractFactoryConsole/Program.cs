using System;

namespace AbstractFactoryConsole
{
    class Program
    {
        abstract class Burger { }
        abstract class Dessert { }
        abstract class RecipeFactory
        {
            public abstract Burger CreateBurger();
            public abstract Dessert createDessert();
        }
        class SteaakBurger : Burger { }
        class CreamBluer : Dessert { }
        class AdultCuisineFactory : RecipeFactory
        {
            public override Burger CreateBurger()
            {
                return new SteaakBurger();
            }

            public override Dessert createDessert()
            {
                return new CreamBluer();
            }
        }

        class KidBurger : Burger { }
        class IceCream : Dessert { }
        class KidCuisineFactory : RecipeFactory
        {
            public override Burger CreateBurger()
            {
                return new KidBurger();
            }

            public override Dessert createDessert()
            {
                return new IceCream();
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Who are you?");
            Console.WriteLine("A- Adult");
            Console.WriteLine("K- Kid");
            char result = Console.ReadKey().KeyChar;
            RecipeFactory factory = new AdultCuisineFactory();
            switch (result)
            {
                case 'A':
                    factory = new AdultCuisineFactory();
                    break;
                case 'K':
                    factory = new KidCuisineFactory();
                    break;
                default:
                    break;
            }

            var burger = factory.CreateBurger();
            var dessert = factory.createDessert();

            Console.WriteLine("");
            Console.WriteLine("Burger: " + burger.GetType().Name);
            Console.WriteLine("Dessert: " + dessert.GetType().Name);
        }
    }
}
