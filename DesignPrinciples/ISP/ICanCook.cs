namespace DesignPrinciples.ISP
{
    public interface ICanCook
    {
        void CookFood<T>(T ingredients);
    }
}