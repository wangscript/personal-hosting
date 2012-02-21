using System;
using Agathas.Storefront.Domain.Contracts;
using Agathas.Storefront.Domain.Entities;

namespace Agathas.Storefront.Domain.MainModule.Entities
{
    public partial class Product:EntityBase<int>, IAggregateRoot
    {
        protected override void Validate()
        {
            throw new NotImplementedException();
        }
    }
}
