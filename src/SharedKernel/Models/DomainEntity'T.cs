using System;
using System.Collections.Generic;
using System.Text;

namespace SharedKernel.Models
{
    public abstract class DomainEntity_T<TEntity> : DomainEntity where TEntity : IHaveDomainEntity
    {
        public virtual void AssertAggregates()
        {
        }

        protected TEntity CreateShallowCopy() => (TEntity)MemberwiseClone();
    }
}
