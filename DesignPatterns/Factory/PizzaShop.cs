using DesignPatterns.Data;

namespace DesignPatterns.Factory
{
    /// <summary>
    /// Factory Pattern: Erzeugen von Objekten kann mitunter kompliziert sein.
    /// Abstrahieren wir die Erzeugung von Objekten in eine Factory Klasse, 
    /// können wir das Erzeugen von Objekten vereinfachen.
    /// </summary>
    public class PizzaShop
    {
        public Pizza CreateMargheritaPizza()
        {
            var pizza = new Margherita();
            pizza.Prepare();
            pizza.Bake();
            return pizza;
        }

        public Pizza CreateSalamiPizza()
        {
            var pizza = new SalamiPizza();
            pizza.Prepare();
            pizza.Bake();
            return pizza;
        }

        public Pizza CreateByName(string name) => name switch
        {
            "Margherita" => CreateMargheritaPizza(),
            "Salami" => CreateSalamiPizza(),
            _ => throw new ArgumentException($"Unknown pizza: {name}")
        };
    }
}
