using DesignPatterns.Data;

namespace DesignPatterns.Decorator
{
    public class CuttingDecorator : Pizza
    {
        public CuttingDecorator(Pizza pizza) : base(pizza.Name)
        {
            
        }

        public override string Description => base.Description + ", geschnitten";
    }
}
