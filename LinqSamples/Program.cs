using LinqSamples.Data;
using LinqSamples.Extensions;
using System.Text;

namespace LinqSamples
{
    internal class Program
    {
        static void Main(string[] args)
        {

            IEnumerable<Car> testdata = Car.Generate(100);

            LinqSamples(testdata);

            // Klassischer Aufruf einer statischen Methode
            ConsoleExtension.ToConsole(testdata.Take(10));

            // Aufruf der statischen Methode als Extension-Methode
            testdata.Take(10)
                .ToConsole();


            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }

        private static void LinqSamples(IEnumerable<Car> vehicles)
        {
            Console.WriteLine("Top 10 Vehicles");
            vehicles.Take(10)
                .ToList()
                .ForEach(Console.WriteLine);

            var avgerageSpeed = vehicles.Take(10).Average(v => v.TopSpeed);
            var maxSpeed = vehicles.Take(10).Max(v => v.TopSpeed);
            var minSpeed = vehicles.Take(10).Min(v => v.TopSpeed);
            Console.WriteLine($"Average Speed: {avgerageSpeed} km/h, Max Speed: {maxSpeed} km/h, Min Speed: {minSpeed} km/h");

            // Exception wenn Liste leer ist
            Console.WriteLine("First vehicle: " + vehicles.First());

            // Default-Wert wenn Liste leer ist (bei Objekten null, bei Int 0)
            Console.WriteLine("Last vehicle: " + vehicles.LastOrDefault());

            // Wenn bei Single mehr als ein Element vorkommt fliegt eine Exception
            // Nach dem Prinzip Fail Fast: Fehler sollten so frueh wie moeglich erkannt werden statt sie zu vergraben
            Console.WriteLine("Single vehicle: " + vehicles.Single(x => x.Id.Equals(1716506328008267969)));


            Console.WriteLine("\n\nAlle Fahrzeuge mit einem rotem Frabton");
            vehicles.Where(v => v.Color.ToString().Contains("Red"))
                .ToList()
                .ForEach(Console.WriteLine);

            Console.WriteLine("\n\nAutos nach TopSpeed und Model sortieren");
            vehicles
                .OrderByDescending(v => v.TopSpeed)
                .ThenBy(v => v.Model)
                .Take(10)
                .ToList()
                .ForEach(Console.WriteLine);

            Console.WriteLine("\n\nAutos nach Treibstoffart gruppieren");
            var groups = vehicles.GroupBy(v => v.Fuel);
            groups.Select(g => new { Fuel = g.Key, Count = g.Count() })
                .OrderByDescending(g => g.Count)
                .ToList()
                .ForEach(g => Console.WriteLine($"{g.Count} Autos mit {g.Fuel} als Treibstoff"));

            Console.WriteLine("\n\nProjektion einer Verschachtelung abflachen");
            new List<Car[]>
            {
                vehicles.Take(5).ToArray(),
                vehicles.Skip(5).Take(5).ToArray(),
                vehicles.Skip(10).Take(5).ToArray()
            }.SelectMany(v => v)
                .ToList()
                .ForEach(Console.WriteLine);

            var startValue = new StringBuilder();
            var sb = vehicles.Aggregate(startValue, (sb, v) => sb.AppendLine(v.ToString()));
            Console.WriteLine(sb.ToString());

            Console.WriteLine("\n\nAutos nach Hersteller gruppieren");
            var dictionary = vehicles.Take(20)
                .Select(c => new { c.Brand, Vehicle = c })
                .GroupBy(c => c.Brand)
                .ToDictionary(g => g.Key, g => g.Select(c => c.Vehicle).ToList());

            foreach (var brand in dictionary.Keys)
            {
                Console.WriteLine($"Autos von {brand}:");
                dictionary[brand].ForEach(Console.WriteLine);
            }
        }
    }
}
