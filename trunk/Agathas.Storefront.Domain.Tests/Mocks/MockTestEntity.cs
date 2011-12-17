using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Agathas.Storefront.Domain.Tests.Mocks
{
    internal class MockTestEntity : EntityBase<int>
    {
        protected override void Validate()
        {
            AddBrokenRule(new BusinessRule("TestProp", "For Tests Causes"));
        }

    }
}
