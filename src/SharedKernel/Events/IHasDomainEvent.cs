using System;
using System.Collections.Generic;
using System.Text;

namespace SharedKernel.Events
{
    public interface IHasDomainEvent
    {
        public List<DomainEvent> DomainEvents { get; set; }
    }
}
