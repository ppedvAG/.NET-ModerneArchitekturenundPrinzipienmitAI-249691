using DesignPatterns.FactoryMethod;

namespace DesignPatterns.Data
{
    public class Margherita : Pizza
    {
        public Margherita() : base("Magherita") 
        { 
            Toppings.Add(PizzaToppings.TomatoSauce); 
            Toppings.Add(PizzaToppings.Cheese); 
        }
    }
}
