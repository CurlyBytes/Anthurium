using System;
using System.Collections.Generic;
using System.Text;

namespace SharedKernel.Events
{
    public interface IHaveDomainEvent
    {
        public List<DomainEvent> DomainEvents { get; set; }
    }
}
