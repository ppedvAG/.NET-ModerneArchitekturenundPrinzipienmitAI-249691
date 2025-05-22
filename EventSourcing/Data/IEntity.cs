namespace EventSourcing.Data
{
    public interface IEntity : IMaterializable
    {
        public Guid Id { get; }
    }
}
