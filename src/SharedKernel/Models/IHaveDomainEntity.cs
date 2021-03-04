using System;
using System.Collections.Generic;
using System.Text;

namespace SharedKernel.Models
{
    public interface IHaveDomainEntity
    {
        Guid Id { get; }
    }
}
