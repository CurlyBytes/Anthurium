using SharedKernel.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class CodeName : ValueObject
    {
        public string Code { get; private set; }

        public CodeName(string code)
        {
            //TODO: regex pattern of the CodeName of warehouse, Item code and vendor code
            //TODO: add custom exception here
            Code = Code ?? throw new ArgumentNullException(nameof(Code));
            
        }

        public override string ToString()
        {
           
            return Code;
        }

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return Code.ToUpper().Trim();
  
        }
    }
}
