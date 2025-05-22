using EventSourcing.Events;

namespace EventSourcing.Data
{
    public interface IMaterializable
    {
        void Apply(DomainEvent ev);
    }
}