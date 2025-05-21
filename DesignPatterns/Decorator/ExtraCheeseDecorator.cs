using DesignPatterns.Data;
using DesignPatterns.FactoryMethod;

namespace DesignPatterns.Decorator
{
    public class ExtraCheeseDecorator : PizzaDecorator
    {
        public ExtraCheeseDecorator(Pizza pizza) : base(pizza)
        {
            pizza.Toppings.AddRange([PizzaToppings.Cheese,PizzaToppings.Cheese,PizzaToppings.Cheese]);
        }
    }
}
