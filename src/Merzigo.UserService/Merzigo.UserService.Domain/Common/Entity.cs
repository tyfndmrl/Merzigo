using System.ComponentModel.DataAnnotations.Schema;

namespace Merzigo.UserService.Domain.Common;

public abstract class Entity
{
    private readonly List<BaseEvent> _domainEvents = new();

    [NotMapped]
    public IReadOnlyCollection<BaseEvent> DomainEvents => _domainEvents.AsReadOnly();

    public void AddDomainEvent(BaseEvent domainEvent)
    {
        _domainEvents.Add(domainEvent);
    }

    public void RemoveDomainEvent(BaseEvent domainEvent)
    {
        _domainEvents.Remove(domainEvent);
    }

    public void ClearDomainEvents()
    {
        _domainEvents.Clear();
    }
}

public abstract class Entity<TKey> : Entity
    where TKey : notnull
{
    protected Entity()
    {
        Id = default!;
    }

    protected Entity(TKey id)
    {
        Id = id;
    }

    public virtual TKey Id { get; set; }
}
