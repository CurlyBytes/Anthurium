using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SharedKernel.Events
{
    public interface IHaveDomainEventDispatcher
    {
        Task PublishAsync<TEvent>(TEvent domainEvent) where TEvent : IHaveDomainEvent;
    }
}
