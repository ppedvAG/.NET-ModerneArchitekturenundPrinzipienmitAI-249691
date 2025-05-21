using DesignPatterns.FactoryMethod;

namespace DesignPatterns.Data
{
    public class Magherita : Pizza
    {
        public Magherita() : base("Magherita") 
        { 
            Toppings.Add(PizzaToppings.TomatoSauce); 
            Toppings.Add(PizzaToppings.Cheese); 
        }
    }
}
