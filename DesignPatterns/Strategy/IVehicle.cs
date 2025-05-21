namespace DesignPatterns.Strategy
{
    public interface IVehicle
    {
        string Name { get; }
    }

    public record Car(string Name) : IVehicle;
    public record Bike(string Name) : IVehicle;
    public record Drone(string Name) : IVehicle;
}
