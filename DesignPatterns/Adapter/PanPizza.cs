using DesignPatterns.Data;

namespace DesignPatterns.Adapter
{
    public class PanPizza
    {
        public string Name => "NY Style Pfannen-Pizza";

        public void PutOilInPan()
        {
            Console.WriteLine("Oel in Pfanne geben");
        }

        public void FryInPan()
        {
            Console.WriteLine("Pizza in Pfanne zubereiten");
        }
    }

    public class PanPizzaAdapter : Pizza
    {
        private readonly PanPizza _panPizza;

        public PanPizzaAdapter(PanPizza panPizza) : base(panPizza.Name)
        {
            _panPizza = panPizza;
        }

        // Mit new koennen wir auch Methoden ueberschreiben, die nicht als virtuel markiert sind.
        public new void Bake()
        {
            _panPizza.PutOilInPan();
            _panPizza.FryInPan();
        }
    }
}
