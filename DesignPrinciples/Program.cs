
using DesignPrinciples.DIP;
using DesignPrinciples.DIP.Payment;
using DesignPrinciples.DIP.Shopping;
using DesignPrinciples.ISP;
using Microsoft.Extensions.DependencyInjection;

namespace DesignPrinciples
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            SampleISP();

            SampleDIP();
        }

        #region ISP Interface Segregation Principle
        private static void SampleISP()
        {
            ICanEat bunny = new Creature("Bugs Bunny")
            {
                FavoriteFood = "Carrots 🥕🥕🥕"
            };
            bunny.Eat();

            IHuman jamieOliver = new Human("Jamie Oliver")
            {
                FavoriteFood = "Pasta 🍝🍝🍝"
            };
            PrepareFoodAndEat(jamieOliver);

            Creature duffy = CreateCreature<Creature>("Duffy", "🍕🍕🍕");
            duffy.Sleep();
        }

        private static void PrepareFoodAndEat_BadSample(IHuman human)
        {
            human.CookFood("Pasta 🍝🍝🍝");
            human.Eat();
            human.Sleep();
        }

        // Constraints fuer den generischen Typparameter T
        private static void PrepareFoodAndEat<T>(T human)
            where T : ICanCook, ICanEat, ICanRest
        {
            human.CookFood("Pasta 🍝🍝🍝");
            human.Eat();
            human.Sleep();
        }

        public static T CreateCreature<T>(string name, string food)
            where T : class, ICanEat, new()
        {
            var creature = new T();
            creature.FavoriteFood = food;
            return creature;
        }
        #endregion

        private static void SampleDIP()
        {
            var paymentMethod = new BankTransferPaymentService();
            var cart = new ShoppingCart(paymentMethod);

            cart.Checkout();


            // Mit Dependency Injection Package
            // Install-Package Microsoft.Extensions.DependencyInjection
            var provider = RegisterTypesOnInitialAppStartup();


            // Service Collection verwenden
            // Der sog. Dependency Tree wird automatisch aufgeloest, d.h. es wird der richtige IPaymentService verwendet
            var shoppingService = provider.GetService<IShoppingService>();
            shoppingService.Checkout();

            using (var scope = provider.CreateScope())
            {
                var cart1FromScope = scope.ServiceProvider.GetService<IShoppingService>();
                cart1FromScope.Checkout();

                // Hat dieselbe PaymentService Instanz
                var cart2FromScope = scope.ServiceProvider.GetService<IShoppingService>();
                cart2FromScope.Checkout();
            }

        }

        private static ServiceProvider RegisterTypesOnInitialAppStartup()
        {
            var container = new ServiceCollection();

            // 3 Varianten Dependencies zu registrieren

            // 1. Jedes mal neue Instanz erzeugen lassen
            container.AddTransient<IShoppingService, ShoppingCart>();

            // 2. Jedes Objekt innerhalb eines Scopes wiederverwenden
            container.AddScoped<IPaymentService, BankTransferPaymentService>();

            // 3. Ein Objekt einmalig fuer gesamte Lebenszeit der Applikation verwenden
            container.AddSingleton<AppSettings>();

            var provider = container.BuildServiceProvider();
            return provider;
        }
    }
}
