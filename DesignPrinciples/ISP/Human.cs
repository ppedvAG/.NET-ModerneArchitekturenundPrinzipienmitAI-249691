namespace DesignPrinciples.ISP
{
    public class Human : Creature, IHuman
    {
        public Human(string name) : base(name)
        {
        }

        public void CookFood<T>(T ingredients)
        {
            Console.WriteLine($"{Name} is cooking with {ingredients}");
        }
    }
}
