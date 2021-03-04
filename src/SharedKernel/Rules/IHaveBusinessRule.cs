using System;
using System.Collections.Generic;
using System.Text;

namespace SharedKernel.Rules
{
    public interface IHaveBusinessRule
    {
        bool IsBroken();

        string Message { get; }
    }
}
