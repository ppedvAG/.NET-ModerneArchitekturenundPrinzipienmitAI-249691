using DesignPatterns.FactoryMethod;

namespace DesignPatterns.Data
{
    public class SalamiPizza : Pizza
    {
        public SalamiPizza() : base("Salami") 
        { 
            Toppings.Add(PizzaToppings.TomatoSauce); 
            Toppings.Add(PizzaToppings.Cheese); 
            Toppings.Add(PizzaToppings.Salami); 
        }
    }
}
