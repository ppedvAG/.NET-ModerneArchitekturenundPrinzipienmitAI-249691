namespace DesignPrinciples.ISP
{
    /// <summary>
    /// Super-Interface was mehrere Interfaces zusammenfasst
    /// *** Verstoß: Interface Segregation Principle (ISP) ***
    /// Warum? Unendlich viele Kombinationsmoeglichkeiten denkbar
    /// </summary>
    public interface IHuman : ICanCook, ICanEat, ICanRest
    {
    }
}