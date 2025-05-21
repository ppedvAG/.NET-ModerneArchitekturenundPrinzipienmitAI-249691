using DesignPatterns.FactoryMethod;

namespace DesignPatterns.Data
{
    public abstract class Pizza
    {
        public List<PizzaToppings> Toppings { get; } = [];
        public string Name { get; }

        public virtual string Description => $"{Name} mit {string.Join(", ", Toppings)}";

        protected Pizza(string name)
        {
            Name = name;
        }

        public void Prepare()
        {
            Console.WriteLine($"{Name} vorbereiten...");
        }

        public void Bake()
        {
            Console.WriteLine($"{Name} in Steinofen backen...");
        }

        public override string ToString() => Description;
    }
}
