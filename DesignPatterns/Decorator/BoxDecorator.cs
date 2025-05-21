using DesignPatterns.Data;

namespace DesignPatterns.Decorator
{
    public class BoxDecorator : Pizza
    {
        public BoxDecorator(Pizza pizza) : base(pizza.Name)
        {
            
        }

        public override string Description => base.Description + ", in Schachtel verpackt";
    }
}
