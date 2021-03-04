using System;
using System.Collections.Generic;
using System.Text;

namespace SharedKernel.Rules
{
    public class BusinessRuleValidationException : Exception
    {
        public IHaveBusinessRule BrokenRule { get; }

        public string Details { get; }

        public BusinessRuleValidationException(IHaveBusinessRule brokenRule) : base(brokenRule.Message)
        {
            BrokenRule = brokenRule;
            this.Details = brokenRule.Message;
        }

        public override string ToString()
        {
            return $"{BrokenRule.GetType().FullName}: {BrokenRule.Message}";
        }
    }
}
