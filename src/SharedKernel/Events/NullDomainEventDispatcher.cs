using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SharedKernel.Events
{
    public sealed class NullDomainEventDispatcher : IHaveDomainEventDispatcher
    {
        public Task PublishAsync<TEvent>(TEvent domainEvent) where TEvent : IHaveDomainEvent => Task.CompletedTask;
    }
}
