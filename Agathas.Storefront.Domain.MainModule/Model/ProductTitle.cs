using System;
using Agathas.Storefront.Domain.Contracts;
using Agathas.Storefront.Domain.Entities;

namespace Agathas.Storefront.Domain.MainModule.Entities
{
    partial class ProductTitle : EntityBase<int>, IAggregateRoot
    {
        protected override void Validate()
        {
            throw new NotImplementedException();
        }
    }
}
