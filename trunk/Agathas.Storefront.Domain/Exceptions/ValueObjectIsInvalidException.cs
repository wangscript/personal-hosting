using System;

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
