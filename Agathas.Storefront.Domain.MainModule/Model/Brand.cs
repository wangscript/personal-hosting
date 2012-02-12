using System;
using Agathas.Storefront.Domain.Entities;
using Agathas.Storefront.Domain.MainModule.Contracts;

namespace Agathas.Storefront.Domain.MainModule.Entities
{
    public partial class Brand : EntityBase<int>, IProductAttribute
    {
        protected override void Validate()
        {
            throw new NotImplementedException();
        }
    }
}
