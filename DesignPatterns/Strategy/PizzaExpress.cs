using DesignPatterns.Data;
using DesignPatterns.Factory;

namespace DesignPatterns.Strategy
{
    /// <summary>
    /// Mit dem Strategy Pattern koennen wir Verhalten zur Laufzeit dynamisch beeinflussen.
    /// Typischer Anwendungsfall waere ein Plugin-Pattern, wo wir die konkrete Implementierung nicht kennen.
    /// </summary>
    public class PizzaExpress
    {
        public IVehicle DeliveryStrategy { get; set; }

        public void Order(string name, int distanceInMeters)
        {
            var pizza = new PizzaShop().CreateByName(name);

            SelectDeliveryStrategy(distanceInMeters);

            Deliver(pizza);
        }

        private void Deliver(Pizza pizza)
        {
            Console.WriteLine($"{pizza.Name} mit {DeliveryStrategy.Name} wird geliefert.");
        }

        private void SelectDeliveryStrategy(int distanceInMeters)
        {
            if (distanceInMeters < 1000)
            {
                DeliveryStrategy = new Bike("Drahtesel 3003");
            } 
            else if (distanceInMeters < 10000)
            {
                DeliveryStrategy = new Car("Fiat Punto");
            }
            else
            {
                DeliveryStrategy = new Drone("DJI Mavic 2");
            }
        }
    }
}
