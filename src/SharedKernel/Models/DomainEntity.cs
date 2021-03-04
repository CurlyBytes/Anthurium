using SharedKernel.Events;
using SharedKernel.Rules;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SharedKernel.Models
{
    public abstract class DomainEntity : IEquatable<DomainEntity>, IHaveDomainEntity
    {
        private static IHaveDomainEventDispatcher dispatcher = new NullDomainEventDispatcher();

        private readonly List<IHaveDomainEvent> domainEvents = new List<IHaveDomainEvent>();

        public IReadOnlyCollection<IHaveDomainEvent> DomainEvents => domainEvents?.AsReadOnly();

        // Slightly breaking the rules here by having a public setter.
        public Guid Id { get; private set; }
        private DomainEntity(Guid id)
        {
            Id = id;
        }

        public void AddDomainEvent(IHaveDomainEvent eventItem)
        {
            domainEvents.Add(eventItem);
        }

        public void ClearDomainEvents() => domainEvents?.Clear();

        public async Task DispatchDomainEventsAsync()
        {
            foreach (var domainEvent in domainEvents)
            {
                await dispatcher.PublishAsync(domainEvent);
            }
            ClearDomainEvents();
        }

        public bool Equals(DomainEntity other) => other == null ? false : Id.Equals(other.Id);

        public override bool Equals(object other) => other is DomainEntity entity && entity != null ? Equals(entity) : base.Equals(other);

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }

        public void RemoveDomainEvent(IHaveDomainEvent eventItem) => domainEvents?.Remove(eventItem);

        internal static void WireUpDispatcher(IHaveDomainEventDispatcher dispatcher) => DomainEntity.dispatcher = dispatcher;

        protected static void CheckRule(IHaveBusinessRule rule)
        {
            if (rule.IsBroken())
            {
                throw new BusinessRuleValidationException(rule);
            }
        }
    }
}
