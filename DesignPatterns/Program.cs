using DesignPatterns.Adapter;
using DesignPatterns.BuilderPattern;
using DesignPatterns.Data;
using DesignPatterns.Decorator;
using DesignPatterns.Factory;
using DesignPatterns.Strategy;

namespace DesignPatterns
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Sonderzeichen darstellen
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Console.WriteLine("Factory Pattern:\nStandard-🍕 erzeugen");
            var shop = new PizzaShop();
            Pizza pizza = shop.CreateMargheritaPizza();
            Console.WriteLine(pizza);


            Console.WriteLine("\nBuilder Pattern:\nEigene 🍕 zusammenstellen");
            var builder = new PizzaConfigurator();
            var myPizza = builder
                .AddCheese(100)
                .AddHam()
                .AddMushrooms()
                .Build();
            Console.WriteLine(myPizza);

            Console.WriteLine("\nDecorator Pattern:\n🍕 fertig machen");
            Pizza boxedPizza = new BoxDecorator(new ExtraCheeseDecorator(myPizza));
            Console.WriteLine(boxedPizza);

            Console.WriteLine("\nStrategy Pattern:\n🍕 liefern lassen");
            var pizzaExpress = new PizzaExpress();
            pizzaExpress.Order("Margherita", 10340);

            Console.WriteLine("\nAdapter Pattern:\n🍕 in Pfanne zubereiten");
            Pizza panPizza = new PanPizzaAdapter(new PanPizza());
            Console.WriteLine(panPizza);

        }
    }
}
