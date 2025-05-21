namespace DesignPrinciples.ISP
{
    public interface ICanEat
    {
        string FavoriteFood { get; set; }

        void Eat();
    }
}