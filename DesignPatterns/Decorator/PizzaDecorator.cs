using DesignPatterns.Data;

namespace DesignPatterns.Decorator
{
    public class PizzaDecorator : Pizza
    {
        public PizzaDecorator(Pizza pizza) : base(pizza.Name)
        {            
        }
    }

    public class PizzaDecoratorWithCastOverload
    {
        private readonly Pizza _pizza;

        public PizzaDecoratorWithCastOverload(Pizza pizza)
        {
            _pizza = pizza;
        }

        // Cast Operator ueberladen
        public static implicit operator Pizza(PizzaDecoratorWithCastOverload decorator)
        {
            return decorator._pizza;
        }
    }
}
