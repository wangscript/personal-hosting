using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Agathas.Storefront.Domain.Exceptions
{
    public class ValueObjectIsInvalidException : Exception
    {
        public ValueObjectIsInvalidException(string message)
            : base(message)
        {

        }
    }

  
}
