using EventSourcing.Events;

namespace EventSourcing.Data
{
    public class InMemoryEventStore
    {
        private readonly Dictionary<Guid, SortedList<DateTime, DomainEvent>> _eventStore = [];
        private readonly Dictionary<Guid, IEntity> _entityProjections = [];

        public void Append<T>(DomainEvent ev)
            where T : class, IEntity, new()
        {
            if (!_eventStore.ContainsKey(ev.StreamId))
            {
                _eventStore[ev.StreamId] = [];
            }

            ev.CreatedAtUtc = DateTime.UtcNow;

            _eventStore[ev.StreamId].Add(ev.CreatedAtUtc, ev);

            // Projektion aufbauen
            _entityProjections[ev.StreamId] = GetEntity<T>(ev.StreamId)!;
        }

        public T? GetEntity<T>(Guid streamId)
            where T : class, IEntity, new()
        {
            if (_eventStore.ContainsKey(streamId))
            {
                return _eventStore[streamId].Aggregate(new T(), (entity, pair) =>
                {
                    entity.Apply(pair.Value);
                    return entity;
                });
            }
            return null;
        }

        public T? GetEntityView<T>(Guid id)
            where T : class
        {
            return _entityProjections.GetValueOrDefault(id) as T;
        }
    }
}
