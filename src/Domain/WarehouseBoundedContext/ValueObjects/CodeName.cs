using SharedKernel.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.WarehouseBoundedContext.ValueObjects
{
    public class CodeName : ValueObject
    {
        public string Code { get; private set; }

        public CodeName(string code)
        {
            //TODO: regex pattern of the CodeName of warehouse, Item code and vendor code
            //TODO: add custom exception here a custom exception
            //TODO: add unit test, refer to feedback service
            Code = code ?? throw new ArgumentNullException(nameof(code));

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
