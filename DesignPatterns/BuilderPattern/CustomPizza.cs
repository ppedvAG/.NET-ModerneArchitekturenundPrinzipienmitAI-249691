using DesignPatterns.Data;
using DesignPatterns.FactoryMethod;

namespace DesignPatterns.BuilderPattern
{
    public class CustomPizza : Pizza
    {
        public CustomPizza(IEnumerable<PizzaToppings> toppings) : base("Custom Pizza")
        {
            Toppings.AddRange(toppings);
        }
    }
}
