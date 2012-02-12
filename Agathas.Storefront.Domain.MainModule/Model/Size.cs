using System;
using Agathas.Storefront.Domain.Entities;
using Agathas.Storefront.Domain.MainModule.Contracts;

namespace Agathas.Storefront.Domain.MainModule.Entities
{
    partial class Size : EntityBase<int>, IProductAttribute
    {
        protected override void Validate()
        {
            throw new NotImplementedException();
        }
    }
}
