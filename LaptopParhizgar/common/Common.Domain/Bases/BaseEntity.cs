using System.ComponentModel.DataAnnotations.Schema;

namespace Common.Domain.Bases;

public class BaseEntity
{
    public long Id { get; set; }
    public DateTime CreationDate { get; set; } = DateTime.Now;

    private readonly List<BaseDomainEvent> _domainEvents = new List<BaseDomainEvent>();
    [NotMapped]
    public List<BaseDomainEvent> DomainEvents => _domainEvents;

    public void AddDomainEvent(BaseDomainEvent EventItem)
    {
        _domainEvents.Add(EventItem);
    }

    public void RemoveDomainEvent(BaseDomainEvent EventItem)
    {
        _domainEvents.Remove(EventItem);
    }
}