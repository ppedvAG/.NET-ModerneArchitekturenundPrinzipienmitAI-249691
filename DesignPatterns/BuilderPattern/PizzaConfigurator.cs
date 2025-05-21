using DesignPatterns.Data;
using DesignPatterns.FactoryMethod;

namespace DesignPatterns.BuilderPattern
{
    /// <summary>
    /// Builder Pattern abstrahiert die Zusammenstellung von einem Objekt.
    /// </summary>
    public class PizzaConfigurator
    {
        private List<PizzaToppings> _toppings = [];

        public PizzaConfigurator AddCheese(int amountInGrams)
        {
            Console.WriteLine($"Adding {amountInGrams}g of cheese");
            _toppings.Add(PizzaToppings.Cheese);
            return this;
        }

        public PizzaConfigurator AddHam()
        {
            _toppings.Add(PizzaToppings.Ham);
            return this;
        }

        public PizzaConfigurator AddMushrooms()
        {
            _toppings.Add(PizzaToppings.Mushroom);
            return this;
        }

        public Pizza Build()
        {
            return new CustomPizza(_toppings);
        }
    }
}
